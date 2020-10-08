using UnityEngine;
using HovelHouse.GameKit;
using System;

public class MatchFinding : object
{
    public Action<GKMatch> OnMatchReady;
    
    // Start is called before the first frame update
    public MatchFinding()
    {
        // Matchmaking cannot begin until the local player has been authenticated
        // by game center
        
        GKLocalPlayer.LocalPlayer.AuthenticateHandler = (view, error) =>
        {
            Debug.Log("Authenticate Handler Called");
            Debug.Log($"Player Authenticated? {GKLocalPlayer.LocalPlayer.Authenticated}");
        
            if (error != null)
            {
                Debug.LogError($"Authenticate error: {error.LocalizedDescription}");
            }
            
            // Show the game center login screen if it was passed to this callback
            // this indicates the player needs to authenticate
            if (view != null)
            {
                view.Show();
            }
            
            // Once we authenticate, start looking for a match
            // You have to register a listener object to the local player in order to accept
            // matchmaking invites. To get the matchmaking screen to show, construct a new
            // instance of the matchmaking view with the invite that was recieved in the
            // player_didAcceptInvite callback
            // 
            else if(GKLocalPlayer.LocalPlayer.Authenticated)
            {
                GKLocalPlayer.LocalPlayer.RegisterListener(new MyLocalPlayerListener());
                CreateMatch();
            }
        };
    }
    
    private void CreateMatch()
    {
        Debug.Log("Creating match request");
                            
        var matchRequest = new GKMatchRequest();
        matchRequest.MinPlayers = 2;
        matchRequest.MaxPlayers = 2;
        matchRequest.InviteMessage = "Lets play a game";
        
        // Make a listener object that handles updates to the match request
        var mmvcd = new MyMatchmakerViewControllerDelegate();
        mmvcd.OnMatchReady = (match) => OnMatchReady?.Invoke(match);
        
        // Show the matchmaking screen, pass it in our match request
        // the view controller delegate will get updates when the match request
        // object is update. See the delegate to see how matches are started when
        // there are enough players
        
        var vc = new GKMatchmakerViewController(matchRequest);
        vc.MatchmakerDelegate = mmvcd;
        vc.Present();
    }
}
