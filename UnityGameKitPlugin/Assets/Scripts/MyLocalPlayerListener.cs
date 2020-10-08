using HovelHouse.GameKit;

public class MyLocalPlayerListener : LocalPlayerListener
{
    public override void player_didAcceptInvite(GKPlayer player, GKInvite invite)
    {
        var mmvc = new GKMatchmakerViewController(invite);
        mmvc.Present();
    }
}
