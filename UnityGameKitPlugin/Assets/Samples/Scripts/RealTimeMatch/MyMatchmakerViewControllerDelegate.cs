using System;
using HovelHouse.GameKit;
using UnityEngine;

public class MyMatchmakerViewControllerDelegate : MatchmakerViewControllerDelegate
{
    public Action<GKMatch> OnMatchFound;

    public override void matchmakerViewController_didFindMatch(GKMatchmakerViewController viewController, GKMatch match)
    {
        viewController.Dismiss();
        OnMatchFound?.Invoke(match);
    }
    
    public override void matchmakerViewControllerWasCancelled(GKMatchmakerViewController viewController)
    {
        Debug.Log("was cancelled");
        viewController.Dismiss();
    }

    public override void matchmakerViewController_didFailWithError(GKMatchmakerViewController viewController, NSError error)
    {
        Debug.Log("did fail with error");
        viewController.Dismiss();
    }
}
