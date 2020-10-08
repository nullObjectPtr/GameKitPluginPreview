//
//  GameKitInitializer.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/22/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

using System;
using System.Runtime.InteropServices;

namespace HovelHouse.GameKit
{
    
    // MatchDelegate

    public delegate void MatchDelegate_match_player_didChangeConnectionState(
            IntPtr ptr,
            IntPtr match, 
            IntPtr player, 
            long state);
    public delegate void MatchDelegate_match_didFailWithError(
            IntPtr ptr,
            IntPtr match, 
            IntPtr error);
        public delegate void MatchDelegate_match_didReceiveData_fromRemotePlayer(
            IntPtr ptr,
            IntPtr data,
	    int dataLength, 
            IntPtr player);    
        
        public delegate void MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer(
            IntPtr ptr,
            IntPtr data,
	        int dataLength, 
            IntPtr recipient, 
            IntPtr player);
        
        public delegate bool MatchDelegate_match_shouldReinviteDisconnectedPlayer(
            IntPtr ptr,
            IntPtr match, 
            IntPtr player);
    
    // MatchmakerViewControllerDelegate

    public delegate void MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr match);
    public delegate void MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled(
            IntPtr ptr,
            IntPtr viewController);
    public delegate void MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr error);
    public delegate void MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr player);
    public delegate void MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr[] players,
			int playersCount);
    
    // LocalPlayerListener

    public delegate void LocalPlayerListener_player_didAcceptInvite(
            IntPtr ptr,
            IntPtr player, 
            IntPtr invite);
    public delegate void LocalPlayerListener_player_didReceiveChallenge(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge);
    public delegate void LocalPlayerListener_player_wantsToPlayChallenge(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge);
    public delegate void LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge, 
            IntPtr friendPlayer);
    public delegate void LocalPlayerListener_player_matchEnded(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match);
    public delegate void LocalPlayerListener_player_didRequestMatchWithRecipients(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] recipientPlayers,
			int recipientPlayersCount);
    public delegate void LocalPlayerListener_player_didCompleteChallenge_issuedByFriend(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge, 
            IntPtr friendPlayer);
    public delegate void LocalPlayerListener_player_receivedExchangeCancellation_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr exchange, 
            IntPtr match);
    public delegate void LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] replies,
			int repliesCount, 
            IntPtr exchange, 
            IntPtr match);
    public delegate void LocalPlayerListener_player_receivedExchangeRequest_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr exchange, 
            IntPtr match);
    public delegate void LocalPlayerListener_player_didRequestMatchWithOtherPlayers(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] playersToInvite,
			int playersToInviteCount);
    public delegate void LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match, 
            bool didBecomeActive);
    public delegate void LocalPlayerListener_player_wantsToQuitMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match);
    
    // ChallengeListener

    public delegate void ChallengeListener_player_didReceiveChallenge(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge);
    public delegate void ChallengeListener_player_wantsToPlayChallenge(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge);
    public delegate void ChallengeListener_player_didCompleteChallenge_issuedByFriend(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge, 
            IntPtr friendPlayer);
    public delegate void ChallengeListener_player_issuedChallengeWasCompleted_byFriend(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge, 
            IntPtr friendPlayer);
    
    // TurnBasedEventListener

    public delegate void TurnBasedEventListener_player_receivedExchangeCancellation_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr exchange, 
            IntPtr match);
    public delegate void TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] replies,
			int repliesCount, 
            IntPtr exchange, 
            IntPtr match);
    public delegate void TurnBasedEventListener_player_receivedExchangeRequest_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr exchange, 
            IntPtr match);
    public delegate void TurnBasedEventListener_player_didRequestMatchWithOtherPlayers(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] playersToInvite,
			int playersToInviteCount);
    public delegate void TurnBasedEventListener_player_matchEnded(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match);
    public delegate void TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match, 
            bool didBecomeActive);
    public delegate void TurnBasedEventListener_player_wantsToQuitMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match);
    
    // GKTurnBasedMatchmakerViewControllerDelegate

    public delegate void GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled(
            IntPtr ptr,
            IntPtr viewController);
    public delegate void GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr error);
    



    public class GameKitInitializer
    {
        // MatchDelegate
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchDelegate_match_player_didChangeConnectionState(
            MatchDelegate_match_player_didChangeConnectionState del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchDelegate_match_didFailWithError(
            MatchDelegate_match_didFailWithError del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchDelegate_match_didReceiveData_fromRemotePlayer(
            MatchDelegate_match_didReceiveData_fromRemotePlayer del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer(
            MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchDelegate_match_shouldReinviteDisconnectedPlayer(
            MatchDelegate_match_shouldReinviteDisconnectedPlayer del);
        
        // MatchmakerViewControllerDelegate
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch(
            MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled(
            MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError(
            MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept(
            MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers(
            MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers del);
        
        // LocalPlayerListener
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_didAcceptInvite(
            LocalPlayerListener_player_didAcceptInvite del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_didReceiveChallenge(
            LocalPlayerListener_player_didReceiveChallenge del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_wantsToPlayChallenge(
            LocalPlayerListener_player_wantsToPlayChallenge del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend(
            LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_matchEnded(
            LocalPlayerListener_player_matchEnded del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_didRequestMatchWithRecipients(
            LocalPlayerListener_player_didRequestMatchWithRecipients del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_didCompleteChallenge_issuedByFriend(
            LocalPlayerListener_player_didCompleteChallenge_issuedByFriend del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeCancellation_forMatch(
            LocalPlayerListener_player_receivedExchangeCancellation_forMatch del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
            LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeRequest_forMatch(
            LocalPlayerListener_player_receivedExchangeRequest_forMatch del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_didRequestMatchWithOtherPlayers(
            LocalPlayerListener_player_didRequestMatchWithOtherPlayers del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive(
            LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_LocalPlayerListener_player_wantsToQuitMatch(
            LocalPlayerListener_player_wantsToQuitMatch del);
        
        // ChallengeListener
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_ChallengeListener_player_didReceiveChallenge(
            ChallengeListener_player_didReceiveChallenge del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_ChallengeListener_player_wantsToPlayChallenge(
            ChallengeListener_player_wantsToPlayChallenge del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_ChallengeListener_player_didCompleteChallenge_issuedByFriend(
            ChallengeListener_player_didCompleteChallenge_issuedByFriend del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_ChallengeListener_player_issuedChallengeWasCompleted_byFriend(
            ChallengeListener_player_issuedChallengeWasCompleted_byFriend del);
        
        // TurnBasedEventListener
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeCancellation_forMatch(
            TurnBasedEventListener_player_receivedExchangeCancellation_forMatch del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
            TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeRequest_forMatch(
            TurnBasedEventListener_player_receivedExchangeRequest_forMatch del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_TurnBasedEventListener_player_didRequestMatchWithOtherPlayers(
            TurnBasedEventListener_player_didRequestMatchWithOtherPlayers del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_TurnBasedEventListener_player_matchEnded(
            TurnBasedEventListener_player_matchEnded del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive(
            TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_TurnBasedEventListener_player_wantsToQuitMatch(
            TurnBasedEventListener_player_wantsToQuitMatch del);
        
        // GKTurnBasedMatchmakerViewControllerDelegate
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled(
            GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled del);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void RegisterDelegateFor_GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError(
            GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError del);
        
        

        public static void Init()
        {
            RegisterDelegateFor_MatchDelegate_match_player_didChangeConnectionState(
                MatchDelegate.match_player_didChangeConnectionState);
                RegisterDelegateFor_MatchDelegate_match_didFailWithError(
                MatchDelegate.match_didFailWithError);
                RegisterDelegateFor_MatchDelegate_match_didReceiveData_fromRemotePlayer(
                MatchDelegate.match_didReceiveData_fromRemotePlayer);
                RegisterDelegateFor_MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer(
                MatchDelegate.match_didReceiveData_forRecipient_fromRemotePlayer);
                RegisterDelegateFor_MatchDelegate_match_shouldReinviteDisconnectedPlayer(
                MatchDelegate.match_shouldReinviteDisconnectedPlayer);
                
                RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch(
                MatchmakerViewControllerDelegate.matchmakerViewController_didFindMatch);
                RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled(
                MatchmakerViewControllerDelegate.matchmakerViewControllerWasCancelled);
                RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError(
                MatchmakerViewControllerDelegate.matchmakerViewController_didFailWithError);
                RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept(
                MatchmakerViewControllerDelegate.matchmakerViewController_hostedPlayerDidAccept);
                RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers(
                MatchmakerViewControllerDelegate.matchmakerViewController_didFindHostedPlayers);
                
                RegisterDelegateFor_LocalPlayerListener_player_didAcceptInvite(
                LocalPlayerListener.player_didAcceptInvite);
                RegisterDelegateFor_LocalPlayerListener_player_didReceiveChallenge(
                LocalPlayerListener.player_didReceiveChallenge);
                RegisterDelegateFor_LocalPlayerListener_player_wantsToPlayChallenge(
                LocalPlayerListener.player_wantsToPlayChallenge);
                RegisterDelegateFor_LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend(
                LocalPlayerListener.player_issuedChallengeWasCompleted_byFriend);
                RegisterDelegateFor_LocalPlayerListener_player_matchEnded(
                LocalPlayerListener.player_matchEnded);
                RegisterDelegateFor_LocalPlayerListener_player_didRequestMatchWithRecipients(
                LocalPlayerListener.player_didRequestMatchWithRecipients);
                RegisterDelegateFor_LocalPlayerListener_player_didCompleteChallenge_issuedByFriend(
                LocalPlayerListener.player_didCompleteChallenge_issuedByFriend);
                RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeCancellation_forMatch(
                LocalPlayerListener.player_receivedExchangeCancellation_forMatch);
                RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
                LocalPlayerListener.player_receivedExchangeReplies_forCompletedExchange_forMatch);
                RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeRequest_forMatch(
                LocalPlayerListener.player_receivedExchangeRequest_forMatch);
                RegisterDelegateFor_LocalPlayerListener_player_didRequestMatchWithOtherPlayers(
                LocalPlayerListener.player_didRequestMatchWithOtherPlayers);
                RegisterDelegateFor_LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive(
                LocalPlayerListener.player_receivedTurnEventForMatch_didBecomeActive);
                RegisterDelegateFor_LocalPlayerListener_player_wantsToQuitMatch(
                LocalPlayerListener.player_wantsToQuitMatch);
                
                RegisterDelegateFor_ChallengeListener_player_didReceiveChallenge(
                ChallengeListener.player_didReceiveChallenge);
                RegisterDelegateFor_ChallengeListener_player_wantsToPlayChallenge(
                ChallengeListener.player_wantsToPlayChallenge);
                RegisterDelegateFor_ChallengeListener_player_didCompleteChallenge_issuedByFriend(
                ChallengeListener.player_didCompleteChallenge_issuedByFriend);
                RegisterDelegateFor_ChallengeListener_player_issuedChallengeWasCompleted_byFriend(
                ChallengeListener.player_issuedChallengeWasCompleted_byFriend);
                
                RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeCancellation_forMatch(
                TurnBasedEventListener.player_receivedExchangeCancellation_forMatch);
                RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
                TurnBasedEventListener.player_receivedExchangeReplies_forCompletedExchange_forMatch);
                RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeRequest_forMatch(
                TurnBasedEventListener.player_receivedExchangeRequest_forMatch);
                RegisterDelegateFor_TurnBasedEventListener_player_didRequestMatchWithOtherPlayers(
                TurnBasedEventListener.player_didRequestMatchWithOtherPlayers);
                RegisterDelegateFor_TurnBasedEventListener_player_matchEnded(
                TurnBasedEventListener.player_matchEnded);
                RegisterDelegateFor_TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive(
                TurnBasedEventListener.player_receivedTurnEventForMatch_didBecomeActive);
                RegisterDelegateFor_TurnBasedEventListener_player_wantsToQuitMatch(
                TurnBasedEventListener.player_wantsToQuitMatch);
                
                RegisterDelegateFor_GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled(
                GKTurnBasedMatchmakerViewControllerDelegate.turnBasedMatchmakerViewControllerWasCancelled);
                RegisterDelegateFor_GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError(
                GKTurnBasedMatchmakerViewControllerDelegate.turnBasedMatchmakerViewController_didFailWithError);
                
                
        }
    }
}

