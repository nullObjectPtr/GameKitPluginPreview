//
//  TurnBasedEventListener.cs
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
    public class TurnBasedEventListener : UnmanagedObject
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif
        
        [DllImport(dll)]
        private static extern IntPtr TurnBasedEventListener_init(out IntPtr exceptionPtr);
            
        [DllImport(dll)]
        private static extern void TurnBasedEventListener_Dispose(HandleRef handle);
            
        #endregion
        
        private static Dictionary<Int64,TurnBasedEventListener> classInstances =
            new Dictionary<Int64,TurnBasedEventListener>();
            
        private readonly SynchronizationContext synchronizationContext;
    
        internal static TurnBasedEventListener GetInstance(IntPtr ptr)
        {
            return classInstances[ptr.ToInt64()];
        }
        
        public TurnBasedEventListener()
        {
            var ptr = TurnBasedEventListener_init(
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


        
        [MonoPInvokeCallback(typeof(TurnBasedEventListener_player_receivedExchangeCancellation_forMatch))]
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
        
        [MonoPInvokeCallback(typeof(TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch))]
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
        
        [MonoPInvokeCallback(typeof(TurnBasedEventListener_player_receivedExchangeRequest_forMatch))]
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
        
        [MonoPInvokeCallback(typeof(TurnBasedEventListener_player_didRequestMatchWithOtherPlayers))]
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
        
        [MonoPInvokeCallback(typeof(TurnBasedEventListener_player_matchEnded))]
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
        
        [MonoPInvokeCallback(typeof(TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive))]
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
        
        [MonoPInvokeCallback(typeof(TurnBasedEventListener_player_wantsToQuitMatch))]
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
        
        public virtual void player_matchEnded(
            GKPlayer player,
            GKTurnBasedMatch match)
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
                TurnBasedEventListener_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~TurnBasedEventListener()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        
    }
}
