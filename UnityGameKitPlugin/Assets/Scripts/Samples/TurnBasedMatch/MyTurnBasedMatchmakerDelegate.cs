using System;
using HovelHouse.GameKit;
using UnityEngine;

public class MyTurnBasedMatchmakerDelegate : GKTurnBasedMatchmakerViewControllerDelegate
{
    public Action<GKTurnBasedMatch> OnMatchSelected;
    
    public override void turnBasedMatchmakerViewControllerWasCancelled(GKTurnBasedMatchmakerViewController viewController)
    {
        // this is invoked when the user hits the cancel button on the matchmaker view, you should dismiss the view when
        // this happens, if you don't the UI stays up, and you'll soft-lock the application
        viewController.Dismiss();
    }

    public override void turnBasedMatchmakerViewController_didFailWithError(GKTurnBasedMatchmakerViewController viewController,
        NSError error)
    {
        if(error != null)
            Debug.LogError($"error creating turn based match. Reason: {error.LocalizedDescription}");
        
        viewController.Dismiss();
    }
}
