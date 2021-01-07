using System;
using HovelHouse.GameKit;

public class RealTimeChatMatchDelegate : MatchDelegate
{
    public Action<byte[]> OnDataRecieved;
    public Action<byte[], string> OnDataReceivedForRecipient;
    public Action<GKPlayer, GKPlayerConnectionState> OnPlayerChangedConnectionState;

    public override void match_player_didChangeConnectionState(GKMatch match, GKPlayer player, GKPlayerConnectionState state)
    {
        OnPlayerChangedConnectionState?.Invoke(player, state);
    }

    public override void match_didReceiveData_fromRemotePlayer(byte[] data, string player)
    {
        OnDataRecieved?.Invoke(data);
    }

    public override void match_didReceiveData_forRecipient_fromRemotePlayer(byte[] data, string recipientGamePlayerID,
        string playerGamePlayerID)
    {
        OnDataReceivedForRecipient?.Invoke(data, playerGamePlayerID);
    }
}