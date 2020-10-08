using System.Collections;
using HovelHouse.GameKit;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameClient : MonoBehaviour
{
    public byte playerId;
    public GKMatch match;
    public MyMatchDelegate matchDelegate;
    
    private IEnumerator Start()
    {
        // assign a match delegate to get notified of data other player's send
        // you'll need to create your own class and derive from MatchDelegate
        matchDelegate = new MyMatchDelegate();
        match.Delegate = matchDelegate;
        
        //send a random byte to all players every second
        while (true)
        {
            yield return new WaitForSeconds(1f);

            var randomByte = (byte) Random.Range(byte.MinValue, byte.MaxValue);
            
            Debug.Log($"sending byte: {randomByte} to all players");
            match.SendDataToAllPlayers(
                new byte[] { randomByte },
                GKMatchSendDataMode.Unreliable);
        }
    }
}
