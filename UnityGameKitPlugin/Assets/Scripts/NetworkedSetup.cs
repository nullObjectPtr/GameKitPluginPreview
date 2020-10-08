using System.Linq;
using HovelHouse.GameKit;
using UnityEngine;

public class NetworkedSetup : MonoBehaviour
{
    public GameClient client;
    private MatchFinding matchFinding;

    void Awake()
    {
        if(client == null)
            throw new MissingReferenceException(nameof(client));
     
        Debug.Log("Running network setup..");
        
        // Must be called before you can use any GameKit delegates
        GameKitInitializer.Init();
        
        matchFinding = new MatchFinding();
        matchFinding.OnMatchReady = StartGame;
    }

    void StartGame(GKMatch match)
    {
        Debug.Log("starting match");
        client.match = match;
        client.playerId = DeterminePlayerId(match);
        client.gameObject.SetActive(true);
    }

    private byte DeterminePlayerId(GKMatch match)
    {
        // the players array does NOT contain the local player
        // so we need to do awkward thing to figure out who is 
        // player1 and player2
        var localPlayer = GKLocalPlayer.LocalPlayer;
        
        var players = match.Players.ToList();
        players.Add(localPlayer);

        // Doc's say alias is unique, so OK to use as a key I guess?
        var orderedPlayers = players
            .OrderBy(x => x.Alias)
            .ToList();

        var idx = orderedPlayers.IndexOf(localPlayer);
        return (byte) idx;
    }
}
