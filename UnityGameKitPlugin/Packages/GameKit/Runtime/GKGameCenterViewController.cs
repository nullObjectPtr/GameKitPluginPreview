//
//  GKGameCenterViewController.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace HovelHouse.GameKit
{
    /// <summary>
    /// 
    /// </summary>
    public class GKGameCenterViewController : GKViewController, IDisposable
    {
        #region dll

        // Class Methods
        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKGameCenterViewController_initWithState(
            long state, 
            out IntPtr exceptionPtr
            );
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKGameCenterViewController_initWithAchievementID(
            string achievementID, 
            out IntPtr exceptionPtr
            );
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKGameCenterViewController_initWithLeaderboard_playerScope(
            IntPtr leaderboard, 
            long playerScope, 
            out IntPtr exceptionPtr
            );
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKGameCenterViewController_initWithLeaderboardID_playerScope_timeScope(
            string leaderboardID, 
            long playerScope, 
            long timeScope, 
            out IntPtr exceptionPtr
            );
        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKGameCenterViewController_registerDidFinish(HandleRef thisPtr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKGameCenterViewController_unregisterDidFinish(HandleRef thisPtr);


        #endregion

        internal GKGameCenterViewController(IntPtr ptr) : base(ptr) {}

        private Action _didFinish;
        public Action DidFinish
        {
            get { return _didFinish; }
            set
            {
                if (value != null)
                {
                    Debug.Log("setting did finish");
                    classInstances[Handle.Handle] = this;
                    GKGameCenterViewController_registerDidFinish(Handle);
                }
                else
                {
                    classInstances.Remove(Handle.Handle);
                    GKGameCenterViewController_unregisterDidFinish(Handle);
                }

                _didFinish = value;
            }
        }
        
        
        public GKGameCenterViewController(
            GKGameCenterViewControllerState state
            )
        {
            
            IntPtr ptr = GKGameCenterViewController_initWithState(
                (long) state, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        
        public GKGameCenterViewController(
            string achievementID
            )
        {
            
            IntPtr ptr = GKGameCenterViewController_initWithAchievementID(
                achievementID, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        
        public GKGameCenterViewController(
            GKLeaderboard leaderboard, 
            GKLeaderboardPlayerScope playerScope
            )
        {
            
            IntPtr ptr = GKGameCenterViewController_initWithLeaderboard_playerScope(
                leaderboard != null ? HandleRef.ToIntPtr(leaderboard.Handle) : IntPtr.Zero, 
                (long) playerScope, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        
        public GKGameCenterViewController(
            string leaderboardID, 
            GKLeaderboardPlayerScope playerScope, 
            GKLeaderboardTimeScope timeScope
            )
        {
            
            IntPtr ptr = GKGameCenterViewController_initWithLeaderboardID_playerScope_timeScope(
                leaderboardID, 
                (long) playerScope, 
                (long) timeScope, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        private static Dictionary<IntPtr,GKGameCenterViewController> classInstances =
            new Dictionary<IntPtr,GKGameCenterViewController>();
        
        [MonoPInvokeCallback(typeof(GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish))]
        public static void gameCenterViewControllerDidFinish(
            IntPtr ptr)
        {
            Debug.Log("GameCenterViewControllerDidFinish");
            try 
            {
                Debug.Log("gameCenterViewControllerDidFinish");
                var inst = classInstances[ptr];
                inst.DidFinish?.Invoke();
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKGameCenterViewController_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKGameCenterViewController Dispose");
                GKGameCenterViewController_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKGameCenterViewController()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public new void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        
    }
}
