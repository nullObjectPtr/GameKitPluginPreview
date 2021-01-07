using System;
using System.Text;
using HovelHouse.GameKit;
using UnityEngine;

public class Sample_RealTimeMatch : MonoBehaviour
{
    public MatchmakingView MatchmakingView;
    public RealTimeChatView ChatView;

    private GKMatch match;
    
    // To demo the capabilities of real time matches, we're going to create a simple peer-to-peer chat room
    void Start()
    {
        MatchmakingView.OnFindMatch = OnFindMatch;

        ChatView.OnCloseClick = OnClose;
        ChatView.OnSendMessage = OnSendMessage;
        ChatView.OnSendMessageToPlayer = OnSendMessageToPlayer;
    }

    void OnFindMatch(int minPlayers, int maxPlayers)
    {
        if(minPlayers < 2)
            throw new ArgumentOutOfRangeException(nameof(minPlayers));
        if(maxPlayers < 2)
            throw new ArgumentOutOfRangeException(nameof(maxPlayers));
        
        // To start matchmaking - create a matchmaking request, and pass it as a parameter to the matchmaker view
        // controller
        var matchRequest = new GKMatchRequest();
        matchRequest.MinPlayers = (ulong) minPlayers;
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
        matchDelegate.OnPlayerChangedConnectionState = OnPlayerConnectionStateChanged;
        match.Delegate = matchDelegate;
        
        this.match = match;
    }

    private void OnClose()
    {
        match.Disconnect();
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
        ChatView.AddMessage(msg);
    }

    private void OnPlayerConnectionStateChanged(GKPlayer player, GKPlayerConnectionState connectionState)
    {
        var connectionStatus = connectionState == GKPlayerConnectionState.Connected 
            ? "connected" : "disconnected";
        ChatView.AddMessage($"{player.DisplayName} has {connectionStatus}");
    }
}
