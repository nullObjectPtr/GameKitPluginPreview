using System;
using HovelHouse.GameKit;

public class MyLocalPlayerDelegate : LocalPlayerListener
{
    public event Action<GKPlayer, GKTurnBasedExchange, GKTurnBasedMatch> OnExchangeRequest;
    public event Action<GKPlayer, GKTurnBasedExchangeReply[], GKTurnBasedExchange, GKTurnBasedMatch> OnExchangeReply;
    public event Action<GKPlayer, GKTurnBasedExchange, GKTurnBasedMatch> OnExchangeCancelled;
    public event Action<GKPlayer, GKTurnBasedMatch, bool> OnReceivedTurnEvent;
    public event Action<GKPlayer, GKPlayer[]> OnRequestMatchWithOtherPlayers;
    public event Action<GKPlayer, GKPlayer[]> OnRequestMatchWithRecipients;
    public event Action<GKPlayer, GKTurnBasedMatch> OnMatchEnded;
    public event Action<GKPlayer, GKTurnBasedMatch> OnWantsToQuit;
    
    public override void player_receivedExchangeRequest_forMatch(GKPlayer player, GKTurnBasedExchange exchange, GKTurnBasedMatch match)
    {
        OnExchangeRequest?.Invoke(player, exchange, match);
    }

    public override void player_receivedExchangeReplies_forCompletedExchange_forMatch(GKPlayer player, GKTurnBasedExchangeReply[] replies,
        GKTurnBasedExchange exchange, GKTurnBasedMatch match)
    {
        OnExchangeReply?.Invoke(player, replies, exchange, match);
    }

    public override void player_receivedExchangeCancellation_forMatch(GKPlayer player, GKTurnBasedExchange exchange,
        GKTurnBasedMatch match)
    {
        OnExchangeCancelled?.Invoke(player, exchange, match);
    }

    public override void player_didRequestMatchWithOtherPlayers(GKPlayer player, GKPlayer[] playersToInvite)
    {
        OnRequestMatchWithOtherPlayers?.Invoke(player, playersToInvite);
    }

    public override void player_didRequestMatchWithRecipients(GKPlayer player, GKPlayer[] recipientPlayers)
    {
        OnRequestMatchWithRecipients?.Invoke(player, recipientPlayers);
    }

    public override void player_matchEnded(GKPlayer player, GKTurnBasedMatch match)
    {
        OnMatchEnded?.Invoke(player, match);
    }

    public override void player_wantsToQuitMatch(GKPlayer player, GKTurnBasedMatch match)
    {
        OnWantsToQuit?.Invoke(player, match);
    }

    public override void player_receivedTurnEventForMatch_didBecomeActive(GKPlayer player, GKTurnBasedMatch match, bool didBecomeActive)
    {
        OnReceivedTurnEvent?.Invoke(player, match, didBecomeActive);
    }
}
