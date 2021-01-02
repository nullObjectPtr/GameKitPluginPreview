using System.IO;
using HovelHouse.GameKit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The view for a single match
/// </summary>
public class MatchView : MonoBehaviour
{
    public Button RockButton;
    public Button PaperButton;
    public Button ScissorsButton;
    public TextMeshProUGUI RoundTextMesh;
    public TextMeshProUGUI ResultTextMesh;
    
    private GKTurnBasedMatch match;
    private readonly RockPaperScissorsGameState GameState = new RockPaperScissorsGameState();

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
    }

    public void SetMatch(GKTurnBasedMatch match, MyLocalPlayerDelegate localPlayerListener)
    {
        Debug.Log("Match View - SetMatch");
        this.match = match;

        // Get notified when the state of the match changes
        localPlayerListener.OnReceivedTurnEvent = OnReceivedTurnEvent;

        DeserializeGameState();

        Debug.Log("done deserializing saved game state");
        
        Redraw();
    }

    private void OnReceivedTurnEvent(GKPlayer player, GKTurnBasedMatch match, bool didBecomeActive)
    {
        // We may have gotten a turn event for a match we're not currently playing, so filter those out
        if (match != this.match)
            return;
        
        Debug.Log($"Received turn event for match with id {match.MatchID}");
        
        // Deserialize the new game state
        DeserializeGameState();
        
        Debug.Log(GameState.ToString());
        
        // See if we just finished a round
        Redraw();
        
        // Advance to the next round if both players have taken turns
        if (GameState.BothPlayersTookTurns())
        {
            GameState.NextRound();
        }
        
        // Check if game has ended
        if (GameState.round >= 3)
        {
            match.EndMatchInTurnWithMatchData(SerializeGameState(), (error) =>
            {
                if (error != null)
                {
                    Debug.LogError($"Failde to end match: {error.LocalizedDescription}");
                }
                else
                {
                    Debug.Log("Match has ended");
                }
            });
        }
    }

    // Converts the byte-array inside the match object to more structured data
    // Do this every-time the game state changes
    private void DeserializeGameState()
    {
        // We might not have any match data ready if we just started the game
        if (match.MatchData != null && match.MatchData.Length > 0)
        {
            var memoryStream = new MemoryStream(match.MatchData);
            var binaryReader = new BinaryReader(memoryStream);
            GameState.Deserialize(binaryReader);
        }
    }

    private byte[] SerializeGameState()
    {
        var memoryStream = new MemoryStream();
        var writer = new BinaryWriter(memoryStream);
        GameState.Serialize(writer);
        return memoryStream.ToArray();
    }

    private void Redraw()
    {
        // it's our turn if we're the player in the current participant object
        var isOurTurn = match.CurrentParticipant.Player == GKLocalPlayer.LocalPlayer;
        Interactable = isOurTurn;

        RoundTextMesh.text = $"Round: {GameState.round}";

        if (GameState.BothPlayersTookTurns())
        {
            var player1 = match.Participants[0].Player;
            var player2 = match.Participants[1].Player;
            ResultTextMesh.text = $"{player1.Alias} chooses {GameState.moves[0]} {player2.Alias} chooses {GameState.moves[1]}\nScore is {GameState.score[0]} to {GameState.score[1]}";
        }
    }

    private void OnMoveClicked(string move)
    {
        Interactable = false;
        Debug.Log($"Took turn: {move}");

        // Update game state
        ResolveTurn(move);
        
        // Serialize game state to byte array and send it to other players. Multiple ways of doing this
        // you could also convert it to a json string and convert that to a byte array.
        var matchData = SerializeGameState();
        
        // Figure out who takes the next turn. In a 2 player game, it's just the other player
        // Quick hack for determining who the other player is
        // One of the players in the participants array will be us, so just choose the other

        Debug.Log($"num participants: {match.Participants.Length}");
        
        var otherParticipant = match.Participants[0].Player == GKLocalPlayer.LocalPlayer
            ? (match.Participants.Length > 0 ? match.Participants[1] : null)    // the other participant may not exist yet
            : match.Participants[0];
        
        Debug.Log($"other participants: {otherParticipant} player {otherParticipant.Player}");

        var nextParticipants = otherParticipant == null
            ? new GKTurnBasedParticipant[] { }
            : new[] {otherParticipant}; 
        
        match.EndTurnWithNextParticipants(nextParticipants, 0, matchData, (error) =>
        {
            if (error != null)
            {
                Debug.LogError("error sending turn data");
            }
            else
            {
                Debug.Log("Sent turn");
            }
        });
    }

    private void ResolveTurn(string turn)
    {
        if (GameState.BothPlayersTookTurns())
        {
            Debug.Log("Turns cleared");
            GameState.ClearTurns();
        }

        // A hacky way of checking if were player 1 or 2
        // player1 will always write to the first index of the moves array
        // so if it's empty when its our turn to move we're player1
        var isPlayer1 = string.IsNullOrEmpty(GameState.moves[0]);

        Debug.Log($"Is Player 1 ? {isPlayer1}");
        if (isPlayer1)
        {
            GameState.moves[0] = turn;
        }
        else
        {
            GameState.moves[1] = turn;
            
            var player1Move = GameState.moves[0];
            var player2Move = GameState.moves[1];
            var didTie = player1Move == player2Move;
            
            if (didTie)
                return;
            
            var player2DidWin = (player1Move == "Rock" && player2Move == "Paper")
                         || (player1Move == "Paper" && player2Move == "Scissors")
                         || (player1Move == "Scissors" && player2Move == "Rock");

            if (player2DidWin)
                GameState.score[0]++;
            else
                GameState.score[1]++;
        }
    }
}