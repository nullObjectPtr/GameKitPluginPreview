using System;
using HovelHouse.GameKit;

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
        viewController.Dismiss();
    }

    public override void matchmakerViewController_didFailWithError(GKMatchmakerViewController viewController, NSError error)
    {
        viewController.Dismiss();
    }
}
