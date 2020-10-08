using HovelHouse.GameKit;
using UnityEngine;

public class MyMatchDelegate : MatchDelegate
{
    public MyMatchDelegate()
    {
    }
    public override void match_didReceiveData_fromRemotePlayer(byte[] bytes, string player)
    {
        if(bytes.Length > 0)
            Debug.Log($"got {bytes[0]} from {player}");
    }

    public override void match_didReceiveData_forRecipient_fromRemotePlayer(byte[] bytes, string recipient,
        string player)
    {
        if(bytes.Length > 0)
            Debug.Log($"got {bytes[0]} from {player}");
    }
}
