using System;
using HovelHouse.GameKit;
using UnityEngine;

public class RealTimeChatMatchDelegate : MatchDelegate
{
    public Action<byte[], string> OnDataRecieved;
    public Action<byte[], string> OnDataReceivedForRecipient;
    public Action<GKPlayer, GKPlayerConnectionState> OnPlayerChangedConnectionState;

    public override void match_player_didChangeConnectionState(GKMatch match, GKPlayer player, GKPlayerConnectionState state)
    {
        OnPlayerChangedConnectionState?.Invoke(player, state);
    }

    public override void match_didReceiveData_fromRemotePlayer(byte[] data, string playerAlias)
    {
        Debug.Log("Data Recieved");
        OnDataRecieved?.Invoke(data, playerAlias);
    }

    public override void match_didReceiveData_forRecipient_fromRemotePlayer(byte[] data, string recipientId,
        string senderId)
    {
        Debug.Log("Data Recieved for Recipient");
        OnDataReceivedForRecipient?.Invoke(data, senderId);
    }
}