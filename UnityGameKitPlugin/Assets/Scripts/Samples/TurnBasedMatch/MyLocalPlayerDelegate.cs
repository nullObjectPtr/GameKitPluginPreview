using System;
using HovelHouse.GameKit;

public class MyLocalPlayerDelegate : LocalPlayerListener
{
    public Action<GKPlayer, GKTurnBasedExchange, GKTurnBasedMatch> OnExchangeRequest;
    public Action<GKPlayer, GKTurnBasedExchangeReply[], GKTurnBasedExchange, GKTurnBasedMatch> OnExchangeReply;
    public Action<GKPlayer, GKTurnBasedExchange, GKTurnBasedMatch> OnExchangeCancelled;
    public Action<GKPlayer, GKTurnBasedMatch, bool> OnReceivedTurnEvent;
    public Action<GKPlayer, GKPlayer[]> OnRequestMatchWithOtherPlayers;
    public Action<GKPlayer, GKPlayer[]> OnRequestMatchWithRecipients;
    public Action<GKPlayer, GKTurnBasedMatch> OnMatchEnded;
    public Action<GKPlayer, GKTurnBasedMatch> OnWantsToQuit;
    
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
