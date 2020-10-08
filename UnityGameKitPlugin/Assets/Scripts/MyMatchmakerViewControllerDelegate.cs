using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HovelHouse.GameKit;
using UnityEngine;

public class MyMatchmakerViewControllerDelegate : MatchmakerViewControllerDelegate
{
    public Action<GKMatch> OnMatchReady;
    public override void matchmakerViewController_didFindMatch(
        GKMatchmakerViewController viewController, 
        GKMatch match)
    {
        Debug.Log("Did find match");
        Debug.Log($"expected player count: {match.ExpectedPlayerCount}");

        if (match.ExpectedPlayerCount == 0)
        {
            var playerNames = match.Players.Select(p => p.DisplayName).ToArray();
            Debug.Log($"players: {String.Join(",", playerNames)}");
            viewController.Dismiss();
            
            OnMatchReady?.Invoke(match);
        }
    }

    public override void matchmakerViewController_didFailWithError(
        GKMatchmakerViewController viewController, 
        NSError error)
    {
        Debug.LogError(error);
        viewController.Dismiss();
    }

    public override void matchmakerViewControllerWasCancelled(GKMatchmakerViewController viewController)
    {
        Debug.LogError("match was cancelled");
        viewController.Dismiss();
    }

    public override void matchmakerViewController_hostedPlayerDidAccept(GKMatchmakerViewController viewController, GKPlayer player)
    {
        Debug.Log("Uhh");
        viewController.Dismiss();
    }
}
