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
        private static extern IntPtr GKGameCenterViewController_GetPropGameCenterDelegate(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKGameCenterViewController_SetPropGameCenterDelegate(HandleRef ptr, IntPtr gameCenterDelegate, out IntPtr exceptionPtr);

        

        #endregion

        internal GKGameCenterViewController(IntPtr ptr) : base(ptr) {}
        
        
        
        
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
        
        


        
        
        
        /// <value>GameCenterDelegate</value>
        public GKGameCenterControllerDelegate GameCenterDelegate
        {
            get
            {
                IntPtr gameCenterDelegate = GKGameCenterViewController_GetPropGameCenterDelegate(Handle);
                return gameCenterDelegate == IntPtr.Zero ? null : new GKGameCenterControllerDelegate(gameCenterDelegate);
            }
            set
            {
                GKGameCenterViewController_SetPropGameCenterDelegate(Handle, value != null ? HandleRef.ToIntPtr(value.Handle) : IntPtr.Zero, out IntPtr exceptionPtr);
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
