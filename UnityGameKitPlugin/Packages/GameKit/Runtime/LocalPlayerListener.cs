//
//  LocalPlayerListener.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace HovelHouse.GameKit
{
    /// <summary>
    /// 
    /// </summary>
    public class LocalPlayerListener : UnmanagedObject
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif
        
        [DllImport(dll)]
        private static extern IntPtr LocalPlayerListener_init(out IntPtr exceptionPtr);
            
        [DllImport(dll)]
        private static extern void LocalPlayerListener_Dispose(HandleRef handle);
            
        #endregion
        
        private static Dictionary<Int64,LocalPlayerListener> classInstances =
            new Dictionary<Int64,LocalPlayerListener>();
            
        private readonly SynchronizationContext synchronizationContext;
    
        internal static LocalPlayerListener GetInstance(IntPtr ptr)
        {
            return classInstances[ptr.ToInt64()];
        }
        
        public LocalPlayerListener()
        {
            var ptr = LocalPlayerListener_init(
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
            synchronizationContext = SynchronizationContext.Current;
            classInstances[ptr.ToInt64()] = this;
        }


        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_didAcceptInvite))]
        public static void player_didAcceptInvite(
            IntPtr ptr,
            IntPtr player, 
            IntPtr invite)
        {
            try 
            {
                Debug.Log("player_didAcceptInvite");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_didAcceptInvite(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    invite == IntPtr.Zero ? null : new GKInvite(invite));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_didReceiveChallenge))]
        public static void player_didReceiveChallenge(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge)
        {
            try 
            {
                Debug.Log("player_didReceiveChallenge");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_didReceiveChallenge(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    challenge == IntPtr.Zero ? null : new GKChallenge(challenge));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_wantsToPlayChallenge))]
        public static void player_wantsToPlayChallenge(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge)
        {
            try 
            {
                Debug.Log("player_wantsToPlayChallenge");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_wantsToPlayChallenge(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    challenge == IntPtr.Zero ? null : new GKChallenge(challenge));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend))]
        public static void player_issuedChallengeWasCompleted_byFriend(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge, 
            IntPtr friendPlayer)
        {
            try 
            {
                Debug.Log("player_issuedChallengeWasCompleted_byFriend");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_issuedChallengeWasCompleted_byFriend(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    challenge == IntPtr.Zero ? null : new GKChallenge(challenge),
                    friendPlayer == IntPtr.Zero ? null : new GKPlayer(friendPlayer));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_matchEnded))]
        public static void player_matchEnded(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match)
        {
            try 
            {
                Debug.Log("player_matchEnded");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_matchEnded(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_didRequestMatchWithRecipients))]
        public static void player_didRequestMatchWithRecipients(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] recipientPlayers,
			int recipientPlayersCount)
        {
            try 
            {
                Debug.Log("player_didRequestMatchWithRecipients");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_didRequestMatchWithRecipients(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    recipientPlayers == null ? null : recipientPlayers.Select(x => new GKPlayer(x)).ToArray());
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_didCompleteChallenge_issuedByFriend))]
        public static void player_didCompleteChallenge_issuedByFriend(
            IntPtr ptr,
            IntPtr player, 
            IntPtr challenge, 
            IntPtr friendPlayer)
        {
            try 
            {
                Debug.Log("player_didCompleteChallenge_issuedByFriend");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_didCompleteChallenge_issuedByFriend(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    challenge == IntPtr.Zero ? null : new GKChallenge(challenge),
                    friendPlayer == IntPtr.Zero ? null : new GKPlayer(friendPlayer));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_receivedExchangeCancellation_forMatch))]
        public static void player_receivedExchangeCancellation_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr exchange, 
            IntPtr match)
        {
            try 
            {
                Debug.Log("player_receivedExchangeCancellation_forMatch");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_receivedExchangeCancellation_forMatch(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    exchange == IntPtr.Zero ? null : new GKTurnBasedExchange(exchange),
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch))]
        public static void player_receivedExchangeReplies_forCompletedExchange_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] replies,
			int repliesCount, 
            IntPtr exchange, 
            IntPtr match)
        {
            try 
            {
                Debug.Log("player_receivedExchangeReplies_forCompletedExchange_forMatch");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_receivedExchangeReplies_forCompletedExchange_forMatch(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    replies == null ? null : replies.Select(x => new GKTurnBasedExchangeReply(x)).ToArray(),
                    exchange == IntPtr.Zero ? null : new GKTurnBasedExchange(exchange),
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_receivedExchangeRequest_forMatch))]
        public static void player_receivedExchangeRequest_forMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr exchange, 
            IntPtr match)
        {
            try 
            {
                Debug.Log("player_receivedExchangeRequest_forMatch");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_receivedExchangeRequest_forMatch(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    exchange == IntPtr.Zero ? null : new GKTurnBasedExchange(exchange),
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_didRequestMatchWithOtherPlayers))]
        public static void player_didRequestMatchWithOtherPlayers(
            IntPtr ptr,
            IntPtr player, 
            IntPtr[] playersToInvite,
			int playersToInviteCount)
        {
            try 
            {
                Debug.Log("player_didRequestMatchWithOtherPlayers");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_didRequestMatchWithOtherPlayers(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    playersToInvite == null ? null : playersToInvite.Select(x => new GKPlayer(x)).ToArray());
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive))]
        public static void player_receivedTurnEventForMatch_didBecomeActive(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match, 
            bool didBecomeActive)
        {
            try 
            {
                Debug.Log("player_receivedTurnEventForMatch_didBecomeActive");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_receivedTurnEventForMatch_didBecomeActive(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match),
                    didBecomeActive);
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(LocalPlayerListener_player_wantsToQuitMatch))]
        public static void player_wantsToQuitMatch(
            IntPtr ptr,
            IntPtr player, 
            IntPtr match)
        {
            try 
            {
                Debug.Log("player_wantsToQuitMatch");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.player_wantsToQuitMatch(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        
        
        public virtual void player_didAcceptInvite(
            GKPlayer player,
            GKInvite invite)
        {
            
        }
        
        public virtual void player_didReceiveChallenge(
            GKPlayer player,
            GKChallenge challenge)
        {
            
        }
        
        public virtual void player_wantsToPlayChallenge(
            GKPlayer player,
            GKChallenge challenge)
        {
            
        }
        
        public virtual void player_issuedChallengeWasCompleted_byFriend(
            GKPlayer player,
            GKChallenge challenge,
            GKPlayer friendPlayer)
        {
            
        }
        
        public virtual void player_matchEnded(
            GKPlayer player,
            GKTurnBasedMatch match)
        {
            
        }
        
        public virtual void player_didRequestMatchWithRecipients(
            GKPlayer player,
            GKPlayer[] recipientPlayers)
        {
            
        }
        
        public virtual void player_didCompleteChallenge_issuedByFriend(
            GKPlayer player,
            GKChallenge challenge,
            GKPlayer friendPlayer)
        {
            
        }
        
        public virtual void player_receivedExchangeCancellation_forMatch(
            GKPlayer player,
            GKTurnBasedExchange exchange,
            GKTurnBasedMatch match)
        {
            
        }
        
        public virtual void player_receivedExchangeReplies_forCompletedExchange_forMatch(
            GKPlayer player,
            GKTurnBasedExchangeReply[] replies,
            GKTurnBasedExchange exchange,
            GKTurnBasedMatch match)
        {
            
        }
        
        public virtual void player_receivedExchangeRequest_forMatch(
            GKPlayer player,
            GKTurnBasedExchange exchange,
            GKTurnBasedMatch match)
        {
            
        }
        
        public virtual void player_didRequestMatchWithOtherPlayers(
            GKPlayer player,
            GKPlayer[] playersToInvite)
        {
            
        }
        
        public virtual void player_receivedTurnEventForMatch_didBecomeActive(
            GKPlayer player,
            GKTurnBasedMatch match,
            bool didBecomeActive)
        {
            
        }
        
        public virtual void player_wantsToQuitMatch(
            GKPlayer player,
            GKTurnBasedMatch match)
        {
            
        }
        

        
        private bool disposedValue = false; // To detect redundant calls
        
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                LocalPlayerListener_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~LocalPlayerListener()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        
    }
}
