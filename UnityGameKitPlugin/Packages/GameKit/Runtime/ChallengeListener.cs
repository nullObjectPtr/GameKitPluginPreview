//
//  ChallengeListener.cs
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
    public class ChallengeListener : UnmanagedObject
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif
        
        [DllImport(dll)]
        private static extern IntPtr ChallengeListener_init(out IntPtr exceptionPtr);
            
        [DllImport(dll)]
        private static extern void ChallengeListener_Dispose(HandleRef handle);
            
        #endregion
        
        private static Dictionary<Int64,ChallengeListener> classInstances =
            new Dictionary<Int64,ChallengeListener>();
            
        private readonly SynchronizationContext synchronizationContext;
    
        internal static ChallengeListener GetInstance(IntPtr ptr)
        {
            return classInstances[ptr.ToInt64()];
        }
        
        public ChallengeListener()
        {
            var ptr = ChallengeListener_init(
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
            classInstances[ptr.ToInt64()] = this;
        }


        
        [MonoPInvokeCallback(typeof(ChallengeListener_player_didReceiveChallenge))]
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
        
        [MonoPInvokeCallback(typeof(ChallengeListener_player_wantsToPlayChallenge))]
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
        
        [MonoPInvokeCallback(typeof(ChallengeListener_player_didCompleteChallenge_issuedByFriend))]
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
        
        [MonoPInvokeCallback(typeof(ChallengeListener_player_issuedChallengeWasCompleted_byFriend))]
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
        
        public virtual void player_didCompleteChallenge_issuedByFriend(
            GKPlayer player,
            GKChallenge challenge,
            GKPlayer friendPlayer)
        {
            
        }
        
        public virtual void player_issuedChallengeWasCompleted_byFriend(
            GKPlayer player,
            GKChallenge challenge,
            GKPlayer friendPlayer)
        {
            
        }
        

        
        private bool disposedValue = false; // To detect redundant calls
        
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                ChallengeListener_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~ChallengeListener()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        
    }
}
