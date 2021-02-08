using System.Linq;
using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A sample of a turn based match. Apple has designed a really terrible API for this. Doing even simple things is
/// convoluted and confusing. Buckle up, it's going to be a bumpy ride.
/// </summary>
public class Sample_TurnBasedMatch : AbstractSample
{
    public RockPaperScissorsGameView gameView;       // The view that handles playing a game
    public Button playButton;                        // Shows apples turn-based match UI
    public int numRounds;                            // Number of rounds a single game takes
    
    private MyLocalPlayerDelegate myLocalPlayerListener;            // An object that gets events about turn-based matches
    private GKTurnBasedMatchmakerViewController matchmakerView;     // Apples turn based match UI
    private bool matchmakerViewIsShowing;                           // A bool we need to determine if the turn based match view needs to be closed

    void Awake()
    {
        playButton.onClick.AddListener(OnPlayClick);
    }
    
    protected override void Run()
    {
        // First thing - set up a delegate object to receive events for turned based matches on the local player
        // If you ask me, the local player is the wrong place to receive these events, but that's how apple has it set
        // up
        var localPlayer = GKLocalPlayer.LocalPlayer;
        if (myLocalPlayerListener == null)
        {
            myLocalPlayerListener = new MyLocalPlayerDelegate();
            myLocalPlayerListener.OnWantsToQuit += OnWantsToQuit;
            myLocalPlayerListener.OnReceivedTurnEvent += OnReceivedTurnEvent;
            localPlayer.RegisterListener(myLocalPlayerListener);
        }

        // Enable the UI
        playButton.interactable = true;
    }

    protected override void OnBackClick()
    {
        gameView.Dismiss();
        base.OnBackClick();
    }

    private void OnReceivedTurnEvent(GKPlayer player, GKTurnBasedMatch match, bool didBecomeActive)
    {
        // this is the event we receive when we click on the match in the matchmaking UI
        // this event is ALSO called in a variety of other circumstances
        // It's actually impossible to tell if this event was fired because of UI interaction, or one of these other 
        // circumstances.
        
        // Try to determine if we got this event because we click on the UI in the turn based matchmaker
        if (matchmakerViewIsShowing)
        {
            // Close the matchmaker UI
            matchmakerView.Dismiss();

            matchmakerViewIsShowing = false;
            
            // Show the in-game UI for this match
            OnMatchSelected(match);
        }
    }

    // A player may request to quit from the match UI in game-center. This is triggered when they do so, but you
    // don't have to allow it. In our case, we will end the match immediately. You should provide a mechanism for
    // Quitting a match without needing to load the UI for your match
    private void OnWantsToQuit(GKPlayer player, GKTurnBasedMatch match)
    {
        RockPaperScissorsMatch.ForfeitMatch(match);
    }
    
    private void OnPlayClick()
    {
        Debug.Log("Creating new match request");
        
        // The match view will show in-progress matches. But if the user wants to start a new match, the matchRequest
        // contains the matchmaking parameters. Create a match request object which defines how matchmaking is done
        // See PlayerAttributes for more fine-grained control over matchmaking
        var matchRequest = new GKMatchRequest {MinPlayers = 2, MaxPlayers = 2};
        
        // In order to even present the view controller, you need to set the delegate property. This is a requirement
        // for showing the UI. Subclass GKTurnBasedMatchmakerDelegate and override it's event handlers to dismiss the UI
        // when a match is cancelled, or couldn't be created. If you don't the UI will stay up, but will become
        // unresponsive, causing a soft-lock for the player.
        //
        // When a match is clicked in the UI, the GKLocalPlayer will receive a
        // "turnEvent" for the match you clicked on (even-though no one has taken a turn yet).
        // But these events are also triggered for other matches in progress 
        // So there isn't really anyway to tell if the event that you received was the result of you clicking on
        // the UI or not. You'll need to put in some kind of heuristic to try to determine this.
        // 
        // This is just terrible API design on Apple's part. It's subject to race conditions and operational ambiguity.
        // It's pretty much a guaranteed bug
        // 
        // See the post about it on the developer forums:
        // https://developer.apple.com/forums/thread/40309
        // 
        
        matchmakerView = new GKTurnBasedMatchmakerViewController(matchRequest);
        var myTurnBasedMatchmakerDelegate = new MyTurnBasedMatchmakerDelegate();
        matchmakerView.TurnBasedMatchmakerDelegate = myTurnBasedMatchmakerDelegate;
        matchmakerView.Present();
        matchmakerViewIsShowing = true;
    }

    private void OnMatchSelected(GKTurnBasedMatch match)
    {
        // We won't know if were just starting a game, or picking up a game in progress in this callback
        // The API has no direct method of determining if were starting a new game
        // The best way to determine this is to check to see if the match we're playing has any game data
        // yet. If not, it's a new game.
        // Otherwise, it's a game in progress

        Debug.Log("On match selected. Loading match data");
        
        // Since the player may have closed the app between turns, when they want to play a match in progress
        // download the current game state for it. 
        // Apple docs say this is necessary, even-though the match object contains a property that holds this data
        // https://developer.apple.com/documentation/gamekit/gkturnbasedmatch?language=objc
        match.LoadMatchDataWithCompletionHandler((data, error) =>
        {
            if (error == null)
            {
                // If the data is null or empty, treat this like a new game and set the initial conditions for the match
                
                // there isn't an convenient API method for setting the initial game-state.
                // In a turn based match - data can only be set when it's the current player's turn, or using exchanges
                // We use "SaveCurrentTurnWithMatchData" to set the initial gamestate, without advancing the turn. Ugly.
                
                // Apple may not want you to use matchData for data that stays constant during a session (like numRounds)
                // But mixing in another service (say CloudKit) to handle this makes for really messy code.
                // IMHO this is again...poor API design
                
                // Oh, and BTW, your match won't be eligible for matchmaking until the local player takes their first turn
                // so....good luck if you have a game in which you need all players present and accounted for before 
                // you can start a round. 

                if (data == null || data.Length == 0)
                {
                    Debug.Log("setting up a new game...");
                    var initialGameState = new RockPaperScissorsGameState(numRounds);
                    match.SaveCurrentTurnWithMatchData(initialGameState.toByteArray(), nsError =>
                    {
                        if (nsError != null)
                        {
                            Debug.Log($"error setting up gamestate: {nsError.LocalizedDescription}");
                        }
                        else
                        {
                            Debug.Log($"set initial match state. Showing game UI...");
                            gameView.ShowViewForMatch(match, myLocalPlayerListener);
                        }
                    });
                }
                
                // If the data is not null, then we should assume we're resuming a match that's already in progress
                else
                {
                    // Events for matches are triggered on the LocalPlayerListener (for any match in progress)
                    // Which is...again...very poor API design, so pass in the LocalPlayerListener to the UI too
                    // so it can act on these events
                    Debug.Log("resuming a game in progress...");
                    gameView.ShowViewForMatch(match, myLocalPlayerListener);
                }
            }
            else
            {
                Debug.LogError("failed to fetch match data", this);
                LogNSError(error);
            }
        });
    }
}
