using HovelHouse.GameKit;
using UnityEngine;

public class Sample_TurnBasedMatch : AbstractSample
{
    public MatchListView listView;
    private MyLocalPlayerDelegate myLocalPlayerListener;
    private GKTurnBasedMatchmakerViewController matchmakerView;
    private bool matchmakerViewIsShowing;

    void Awake()
    {
        listView.OnNewMatch = OnNewMatch;
    }
    
    protected override void OnAuthenticated()
    {
        LoadInProgressMatches();
    }
    
    private void LoadInProgressMatches()
    {
        // First thing - set up a delegate object to receive events for turned based matches on the local player
        // If you ask me, the local player is the wrong place to receive these events, but that's how apple has it set
        // up
        var localPlayer = GKLocalPlayer.LocalPlayer;
        myLocalPlayerListener = new MyLocalPlayerDelegate();
        localPlayer.RegisterListener(myLocalPlayerListener);
        
        Debug.Log("Loading in progress matches");
        GKTurnBasedMatch.LoadMatchesWithCompletionHandler((matches, error) =>
        {
            if (error != null)
            {
                LogNSError(error);
                return;
            }

            // matches will be null instead of empty if there are no matches in progress
            var numMatches = matches?.Length ?? 0;
            Debug.Log($"there are {numMatches} matches in progress");
            
            // make the UI intractable
            listView.SetMatches(matches);
        });
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
            
            // Show the in-game UI for this match
            OnMatchSelected(match);
        }
    }

    private void OnNewMatch()
    {
        Debug.Log("Creating new match request");
        
        // Create a match request object which defines how matchmaking is done
        // See PlayerAttributes for more fine-grained control over matchmaking
        var matchRequest = new GKMatchRequest {MinPlayers = 2, MaxPlayers = 2};
        
        // In order to even present the view controller, you need to set the delegate property. This is a requirement
        // for showing the UI. Subclass GKTurnBasedMatchmakerDelegate and override it's event handlers to dismiss the UI
        // when a match is cancelled, or couldn't be created. If you don't the UI will stay up, but will become
        // unresponsive, causing a soft-lock for the player.
        // 
        // We're also going to hook into the deprecated "didFindMatch" event to determine when the turn based match is
        // ready to start. 
        // 
        // Why are we using a deprecated method?
        // Apple deprecated this function without a suitable replacement. The non-deprecated way of handling this is 
        // fundamentally broken. When a match is clicked in the UI, the GKLocalPlayer will receive a
        // "turnEvent" for the match you clicked on (even-though no one has taken a turn yet).
        // But these events are also just triggered by other players from other matches.
        // So there isn't really anyway to tell if the event that you received was the result of you clicking on
        // the UI or not. You'll need to put in some kind of heuristic to try to determine this.
        // 
        // This is just terrible API design on Apple's part. It's subject to race conditions and operational ambiguity.
        // It's pretty much a guaranteed bug
        // 
        // See the post about it on the developer forums:
        // https://developer.apple.com/forums/thread/40309
        // 
        
        myLocalPlayerListener.OnReceivedTurnEvent = OnReceivedTurnEvent;
        
        matchmakerView = new GKTurnBasedMatchmakerViewController(matchRequest);
        var myTurnBasedMatchmakerDelegate = new MyTurnBasedMatchmakerDelegate();
        matchmakerView.TurnBasedMatchmakerDelegate = myTurnBasedMatchmakerDelegate;
        matchmakerView.Present();
        matchmakerViewIsShowing = true;
        
        // We added a delegate method to our MatchmakerDelegate that gets fired when the match is created
        // Hook into that to continue forward as if we'd clicked on an in-progress match
        myTurnBasedMatchmakerDelegate.OnMatchSelected = OnMatchSelected;
    }

    private void OnMatchSelected(GKTurnBasedMatch match)
    {
        // Since the player may have closed the app between turns, when they want to play a match in progress
        // download the current game state for it. 
        // Apple docs say this is necessary, even-though the match object contains a property that holds this data
        // https://developer.apple.com/documentation/gamekit/gkturnbasedmatch?language=objc
        
        Debug.Log("On match selected. Loading match data");
        match.LoadMatchDataWithCompletionHandler((data, error) =>
        {
            Debug.Log("Loaded match data");
            if (error == null)
            {
                // Match data is loaded, show the UI
                // Events for matches are triggered on the LocalPlayerListener (for any match in progress)
                // Which is...again...very poor API design, so pass in the LocalPlayerListener to the UI too
                // so it can act on these events
                listView.ShowMatchView(match, myLocalPlayerListener);
            }
            else
            {
                Debug.LogError("failed to fetch match data. Reason: " + error.LocalizedDescription);
            }
        });
    }
}
