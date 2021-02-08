using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HovelHouse.GameKit;
using UnityEngine;

public class RockPaperScissorsMatch
{
    public GKTurnBasedMatch gkMatch { get; private set; }
    
    public readonly RockPaperScissorsGameState GameState;

    public int Round => GameState.round;

    // Convenience method for knowing if it's our turn or not
    public bool IsMyTurn => gkMatch.CurrentParticipant.Player == GKLocalPlayer.LocalPlayer;
    
    // Convenience method for knowing if the match is over or not
    public bool IsOver => gkMatch.Participants.All(participant => participant.MatchOutcome != GKTurnBasedMatchOutcome.None);

    public GKTurnBasedParticipant LocalPlayerParticipant => 
        gkMatch.Participants
            .FirstOrDefault(participant => participant.Player == GKLocalPlayer.LocalPlayer);

    // Convenience method for determining who the other player is. In a 2 player game, it's just the other player
    // One of the players in the participants array will be us, so just choose the other
    public GKTurnBasedParticipant OtherParticipant => gkMatch.Participants
        .FirstOrDefault(participant => participant.Player != GKLocalPlayer.LocalPlayer);

    public int LocalPlayerIndex => gkMatch.Participants[0].Player == GKLocalPlayer.LocalPlayer ? 0 : 1;

    public RockPaperScissorsMatch(GKTurnBasedMatch match)
    {
        gkMatch = match ?? throw new ArgumentNullException(nameof(match));
        GameState = new RockPaperScissorsGameState();

        if (match.MatchData != null && match.MatchData.Length > 0)
            DeserializeGameState(match);
        
        Debug.Log(GameState);
    }

    public bool BothPlayersTookTurns()
    {
        return GameState.BothPlayersTookTurns();
    }

    private void EndTurn()
    {
        Debug.Log($"end turn with game state of:\n {GameState}");
        // Serialize game state to byte array and send it to other players. Multiple ways of doing this
        // you could also convert it to a json string and convert that to a byte array.
        var matchData = GameState.toByteArray();
        
        // Figure out who takes the next turn. 
        var nextTurnParticipant = new[] {OtherParticipant};
        gkMatch.EndTurnWithNextParticipants(nextTurnParticipant, 0, matchData, (error) =>
        {
            if (error != null)
            {
                Debug.LogError($"error sending turn data: {error.LocalizedDescription}");
            }
            else
            {
                Debug.Log("Turn sent successfully");
            }
        });
    }
    
    public void EndMatch(RockPaperScissorsGameState GameState)
    {
        // Apple says you MUST set an outcome for each player before the current player ends the match
        // and ONLY the current player can end the match
        // I'm not even sure why they enforce this
        // This could be easily handled by the programmer in their custom GameState
        // It's just a lot of extra headache to do things this way

        var p1 = gkMatch.Participants[0];
        var p2 = gkMatch.Participants[1];
        var p1Score = GameState.score[0];
        var p2Score = GameState.score[1];

        if (p1Score == p2Score)
        {
            p1.MatchOutcome = GKTurnBasedMatchOutcome.Tied;
            p2.MatchOutcome = GKTurnBasedMatchOutcome.Tied;
        }
        else
        {
            p1.MatchOutcome = p1Score > p2Score ? GKTurnBasedMatchOutcome.Won : GKTurnBasedMatchOutcome.Lost;
            p2.MatchOutcome = p2Score > p1Score ? GKTurnBasedMatchOutcome.Won : GKTurnBasedMatchOutcome.Lost;
        }
    
        gkMatch.EndMatchInTurnWithMatchData(GameState.toByteArray(), (error) =>
        {
            if (error != null)
            {
                Debug.LogError($"Failed to end match: {error.LocalizedDescription}");
            }
            else
            {
                Debug.Log("Match has ended");
            }
        });
    }

    public static void ForfeitMatch(GKTurnBasedMatch match)
    {
        // If you quit, you have to call different methods depending on whether or not it's your turn
        // If it's your turn, it's your responsibliity to update the match state, and say who the next player is
        var isMyTurn = match.CurrentParticipant.Player == GKLocalPlayer.LocalPlayer;

        // It's possible the other participant quit out of turn. If we attempted to pass the turn to them, we would fail
        // to quit with an error because they would be an 'invalid participant'


        if (isMyTurn)
        {
            // In a match with > 2 players we do this
            //
            // match.ParticipantQuitInTurnWithOutcome(
            //     GKTurnBasedMatchOutcome.Quit, 
            //     nextParticipants, 
            //     0, match.MatchData,
            //     error =>
            //     {
            //         if(error != null)
            //             Debug.LogError($"Failed to quit. {error.LocalizedDescription}");
            //     });
            
            // But once a terminal condition has been reached due to quitting, the last player capable of determining
            // the final outcome of the match needs to end it. So in our case, we just end the match.

            var p1 = match.Participants[0];
            var p2 = match.Participants[1];
            
            if (p1 == GKLocalPlayer.LocalPlayer)
            {
                p1.MatchOutcome = GKTurnBasedMatchOutcome.Quit;
                p2.MatchOutcome = GKTurnBasedMatchOutcome.Won;
            }
            else
            {
                p1.MatchOutcome = GKTurnBasedMatchOutcome.Won;
                p2.MatchOutcome = GKTurnBasedMatchOutcome.Quit;
            }
            
            match.EndMatchInTurnWithMatchData(match.MatchData, error =>
            {
                if(error != null)
                    Debug.Log($"failed to end match. Reason: {error.LocalizedDescription}");
            });
        }
        else
        {
            match.ParticipantQuitOutOfTurnWithOutcome(GKTurnBasedMatchOutcome.Quit, (error) =>
            {
                Debug.LogError($"failed to quit match {match.MatchID}. Reason: {error.LocalizedDescription}");
            });
        }
    }
    public void Forfeit()
    {
        ForfeitMatch(gkMatch);
    }

    public void TakeTurn(string turn)
    {
        GameState.moves[LocalPlayerIndex] = turn;

        // Update score when both players take turns
        if (GameState.BothPlayersTookTurns())
        {
            var player1Move = GameState.moves[0];
            var player2Move = GameState.moves[1];
            var didTie = player1Move == player2Move;

            var player2DidWin = player1Move == "Rock" && player2Move == "Paper"
                                || player1Move == "Paper" && player2Move == "Scissors"
                                || player1Move == "Scissors" && player2Move == "Rock";

            if (player2DidWin)
                GameState.score[0]++;
            else if(!didTie)
                GameState.score[1]++;
        }
        
        EndTurn();
    }
    public void ProcessOtherPlayerTurn(GKTurnBasedMatch otherMatch)
    {
        // Check to see if the other player quit out-of-turn by looking at their match outcome
        // Because they quit out of turn, it's out job to clean-up the match
        // This is the only way I know of to check when a player quits. There is no event on the match object, nor
        // does there appear to be an event on the LocalPlayerDelegate
        if (OtherParticipant.MatchOutcome != GKTurnBasedMatchOutcome.None)
        {
            Debug.Log("Other player has forfeited");
            LocalPlayerParticipant.MatchOutcome = GKTurnBasedMatchOutcome.Won;
            gkMatch.EndMatchInTurnWithMatchData(gkMatch.MatchData, error =>
            {
                Debug.LogError($"Failed to end match {error.LocalizedDescription}");
            });
        }
        
        // Deserialize the new game state
        // Do NOT deserialize our cached version of GKMatch (this.gkMatch) it won't contain the up-to-date MatchData
        // In other words, this.gkMatch.MatchData != match.MatchData
        // AND this.gkMatch.MatchID = match.MatchID
        // Same match! different data!
        // Seems like OUR match only has local edits. Is that documented anywhere? Nope!
        // Beating a dead horse here, but GameKit is a terrible API.

        // never do this
        //         DeserializeGameState(gkMatch);

        gkMatch = otherMatch;
        DeserializeGameState(otherMatch);
        Debug.Log(GameState);
        
        AdvanceRound();
    }
    
    public void AdvanceRound()
    {
        // Advance to next round if needed
        if (GameState.BothPlayersTookTurns() && GameState.round < GameState.numRounds)
        {
            Debug.Log("Advance Round");
            GameState.ClearTurns();
            GameState.NextRound();
        }
        
        if (GameState.round >= GameState.numRounds)
        {
            if(IsMyTurn){ EndMatch(GameState); }
        }
    }

    
    // Converts the byte-array inside the match object to more structured data
    // Do this every-time the game state changes
    private void DeserializeGameState(GKTurnBasedMatch match)
    {
        var memoryStream = new MemoryStream(match.MatchData);
        var binaryReader = new BinaryReader(memoryStream);
        GameState.Deserialize(binaryReader);
    }
}
