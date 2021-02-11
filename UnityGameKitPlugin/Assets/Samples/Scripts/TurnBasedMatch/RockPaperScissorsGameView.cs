using System;
using HovelHouse.GameKit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The view for a single match
/// GameKit's turn based match API runs all logic on the game client. There's no server to help enforce game logic
/// and be a central authority. The Apple API is designed to enforce that the gamestate stays cohesive across all clients
/// As a result of this, expect to to have to jump through a lot of hoops to manage the game state.
///
/// The state management in this example is a bit of a mess, but it demonstrates the use of the API properly. You'll
/// want to do better in a real game. 
/// </summary>
public class RockPaperScissorsGameView : MonoBehaviour
{
    public Button RockButton;
    public Button PaperButton;
    public Button ScissorsButton;
    public Button ForfeitButton;

    public TextMeshProUGUI TurnTextMesh;
    public TextMeshProUGUI RoundTextMesh;
    public TextMeshProUGUI ResultTextMesh;

    private MyLocalPlayerDelegate _localPlayerDelegate;
    private RockPaperScissorsMatch rpsMatch;
    
    private bool _interactable;
    private bool Interactable
    {
        get => _interactable;
        set
        {
            _interactable = value;
            RockButton.interactable = value;
            PaperButton.interactable = value;
            ScissorsButton.interactable = value;
        }
    }

    void Awake()
    {
        RockButton.onClick.AddListener(() => OnMoveClicked("Rock"));
        PaperButton.onClick.AddListener(() => OnMoveClicked("Paper"));
        ScissorsButton.onClick.AddListener(() => OnMoveClicked("Scissors"));
        ForfeitButton.onClick.AddListener(OnForfeitClick);
    }

    public void ShowViewForMatch(GKTurnBasedMatch gkMatch, MyLocalPlayerDelegate localPlayerListener)
    {
        // Wrap the match object in a controller to make things easier
        rpsMatch = new RockPaperScissorsMatch(gkMatch);
                     
        // Get notified when the state of the match changes
        _localPlayerDelegate = localPlayerListener ?? throw new ArgumentNullException(nameof(localPlayerListener));
        _localPlayerDelegate.OnReceivedTurnEvent += OnReceivedTurnEvent;
        
        rpsMatch.AdvanceRound();
        
        Redraw();

        // Show the game view
        gameObject.SetActive(true);
    }

    public void Dismiss()
    {
        if (_localPlayerDelegate != null)
        {
            _localPlayerDelegate.OnReceivedTurnEvent -= OnReceivedTurnEvent;
        }

        // Hide the view
        gameObject.SetActive(false);
    }

    private void OnReceivedTurnEvent(GKPlayer player, GKTurnBasedMatch gkmatch, bool didBecomeActive)
    {
        Debug.Log($"Received turn event for match with id {gkmatch.MatchID}. Current match is {this.rpsMatch.gkMatch.MatchID}");

        // A player can have multiple turn-based matches active, and this event can be triggered for any of them
        // We may have gotten a turn event for a match we're not currently playing, so filter those out
        // Again, really poor API design by apple
        if (gkmatch.MatchID != rpsMatch.gkMatch.MatchID) { return; }

        rpsMatch.ProcessOtherPlayerTurn(gkmatch);

        // See if we just finished a round
        Redraw();
    }

    private void Redraw()
    {
        // it's our turn if we're the player in the current participant object
        Interactable = rpsMatch.IsMyTurn && rpsMatch.IsOver == false;

        RoundTextMesh.text = $"Round: {rpsMatch.Round + 1}";
        
        if (rpsMatch.BothPlayersTookTurns())
        {
            var player1 = rpsMatch.gkMatch.Participants[0].Player;
            var player2 = rpsMatch.gkMatch.Participants[1].Player;
            ResultTextMesh.text = $"{player1.Alias} chooses {rpsMatch.GameState.moves[0]}\n{player2.Alias} chooses {rpsMatch.GameState.moves[1]}\nScore is {rpsMatch.GameState.score[0]} to {rpsMatch.GameState.score[1]}";
        }

        if (rpsMatch.IsOver)
        {
            TurnTextMesh.text = "game is over";
        }
        else if (rpsMatch.IsMyTurn)
        {
            TurnTextMesh.text = "select your move...";
        }
        else
        {
            TurnTextMesh.text = "waiting for opponent...";
        }
    }

    private void OnMoveClicked(string move)
    {
        Interactable = false;

        rpsMatch.TakeTurn(move);
        
        Redraw();

        rpsMatch.AdvanceRound();
    }

    private void OnForfeitClick()
    {
        rpsMatch.Forfeit();
        Dismiss();
    }
}