using System;
using System.Text;
using HovelHouse.GameKit;
using UnityEngine;

public class RealTimeChatMatchDelegate : MatchDelegate
{
    public Action<byte[]> OnDataRecieved;
    
    public override void match_didReceiveData_fromRemotePlayer(byte[] data, string player)
    {
        base.match_didReceiveData_fromRemotePlayer(data, player);
    }

    public override void match_didReceiveData_forRecipient_fromRemotePlayer(byte[] data, string recipientGamePlayerID,
        string playerGamePlayerID)
    {
        base.match_didReceiveData_forRecipient_fromRemotePlayer(data, recipientGamePlayerID, playerGamePlayerID);
    }
}
public class Sample_RealTimeMatch : MonoBehaviour
{
    public MatchmakingView MatchmakingView;
    public RealTimeChatView ChatView;

    private GKMatch match;
    
    // To demo the capabilities of real time matches, we're going to create a simple peer-to-peer chat room
    void Start()
    {
        MatchmakingView.OnFindMatch = OnFindMatch;
        ChatView.OnSendMessage = OnSendMessage;
        ChatView.OnSendMessageToPlayer = OnSendMessageToPlayer;
    }

    void OnFindMatch(int minPlayer, int maxPlayers)
    {
        // To start matchmaking - create a matchmaking request, and pass it as a parameter to the matchmaker view
        // controller
        var matchRequest = new GKMatchRequest();
        matchRequest.MinPlayers = (ulong) minPlayer;
        matchRequest.MaxPlayers = (ulong) maxPlayers;
        matchRequest.InviteMessage = "Let's play a game";

        var matchmakingView = new GKMatchmakerViewController(matchRequest);
        matchmakingView.Present();
        
        // To respond to UI events from the matchmaker view, subclass MatchmakerViewControllerDelegate and override
        // it's event handlers. We create a pass-trough delegate object that's a little easier to use.
        var matchmakingViewDelegate = new MyMatchmakerViewControllerDelegate();
        matchmakingViewDelegate.OnMatchFound = OnMatchFound;
    }

    private void OnMatchFound(GKMatch match)
    {
        MatchmakingView.gameObject.SetActive(false);
        ChatView.gameObject.SetActive(true);
        
        // Again, in order to receive notification of events in the real-time match, we have to subclass the 
        // MatchDelegate and override it's methods. We create a pass-through delegate object with events that we're
        // interested in
        var matchDelegate = new RealTimeChatMatchDelegate();
        matchDelegate.OnDataRecieved = OnDataReceived;
        match.Delegate = matchDelegate;
        
        this.match = match;
    }

    // Sends a (public) message to the entire chat-room
    private void OnSendMessage(string msg)
    {
        // You can send a message over the reliable channel, and the message will be re-sent until it is received
        // by all peers. You can also use the unreliable channel. Unreliable messages will not be re-sent and may be
        // dropped, but are much faster. You'll want to use the unreliable channel for things like sending object
        // snapshots

        var msgBytes = Encoding.UTF8.GetBytes($"public:{msg}");
        match.SendDataToAllPlayers(msgBytes, GKMatchSendDataMode.Reliable);
    }

    // Sends a private message to specific player
    private void OnSendMessageToPlayer(GKPlayer player, string msg)
    {
        // convert the message to a byte array
        var msgBytes = Encoding.UTF8.GetBytes($"private:{msg}");
        match.SendDataToPlayers(msgBytes, new []{player}, GKMatchSendDataMode.Reliable);
    }

    private void OnDataReceived(byte[] data)
    {
        var msg = System.Text.Encoding.UTF8.GetString(data);
    }
}
