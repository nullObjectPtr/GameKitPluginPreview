//
//  GKMatchmakerViewController.cs
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
    public class GKMatchmakerViewController : GKViewController, IDisposable
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS"
        #endif

        // Class Methods
        

        
        [DllImport(dll)]
        private static extern IntPtr GKMatchmakerViewController_initWithMatchRequest(
            IntPtr request, 
            out IntPtr exceptionPtr
            );
        
        [DllImport(dll)]
        private static extern IntPtr GKMatchmakerViewController_initWithInvite(
            IntPtr invite, 
            out IntPtr exceptionPtr
            );
        

        
        [DllImport(dll)]
        private static extern void GKMatchmakerViewController_addPlayersToMatch(
            HandleRef ptr, 
            IntPtr match,
            out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern void GKMatchmakerViewController_setHostedPlayer_didConnect(
            HandleRef ptr, 
            IntPtr player,
            bool connected,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        [DllImport(dll)]
        private static extern IntPtr GKMatchmakerViewController_GetPropMatchmakerDelegate(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKMatchmakerViewController_SetPropMatchmakerDelegate(HandleRef ptr, IntPtr matchmakerDelegate, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern bool GKMatchmakerViewController_GetPropHosted(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKMatchmakerViewController_SetPropHosted(HandleRef ptr, bool hosted, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern GKMatchmakingMode GKMatchmakerViewController_GetPropMatchmakingMode(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKMatchmakerViewController_SetPropMatchmakingMode(HandleRef ptr, long matchmakingMode, out IntPtr exceptionPtr);

        

        #endregion

        internal GKMatchmakerViewController(IntPtr ptr) : base(ptr) {}
        
        
        
        
        public GKMatchmakerViewController(
            GKMatchRequest request
            )
        {
            
            IntPtr ptr = GKMatchmakerViewController_initWithMatchRequest(
                request != null ? HandleRef.ToIntPtr(request.Handle) : IntPtr.Zero, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        
        public GKMatchmakerViewController(
            GKInvite invite
            )
        {
            
            IntPtr ptr = GKMatchmakerViewController_initWithInvite(
                invite != null ? HandleRef.ToIntPtr(invite.Handle) : IntPtr.Zero, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="match"></param>
        /// <returns>void</returns>
        public void AddPlayersToMatch(
            GKMatch match)
        { 
            
            GKMatchmakerViewController_addPlayersToMatch(
                Handle,
                match != null ? HandleRef.ToIntPtr(match.Handle) : IntPtr.Zero,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="player"></param><param name="connected"></param>
        /// <returns>void</returns>
        public void SetHostedPlayer(
            GKPlayer player, 
            bool connected)
        { 
            
            
            GKMatchmakerViewController_setHostedPlayer_didConnect(
                Handle,
                player != null ? HandleRef.ToIntPtr(player.Handle) : IntPtr.Zero,
                connected,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        
        
        /// <value>MatchmakerDelegate</value>
        public MatchmakerViewControllerDelegate MatchmakerDelegate
        {
            get
            {
                IntPtr matchmakerDelegate = GKMatchmakerViewController_GetPropMatchmakerDelegate(Handle);
                return matchmakerDelegate == IntPtr.Zero ? null : MatchmakerViewControllerDelegate.GetInstance(matchmakerDelegate);
            }
            set
            {
                GKMatchmakerViewController_SetPropMatchmakerDelegate(Handle, value != null ? HandleRef.ToIntPtr(value.Handle) : IntPtr.Zero, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>Hosted</value>
        public bool Hosted
        {
            get
            {
                bool hosted = GKMatchmakerViewController_GetPropHosted(Handle);
                return hosted;
            }
            set
            {
                GKMatchmakerViewController_SetPropHosted(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>MatchmakingMode</value>
        public GKMatchmakingMode MatchmakingMode
        {
            get
            {
                GKMatchmakingMode matchmakingMode = GKMatchmakerViewController_GetPropMatchmakingMode(Handle);
                return (GKMatchmakingMode) matchmakingMode;
            }
            set
            {
                GKMatchmakerViewController_SetPropMatchmakingMode(Handle, (long) value, out IntPtr exceptionPtr);
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
        private static extern void GKMatchmakerViewController_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKMatchmakerViewController Dispose");
                GKMatchmakerViewController_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKMatchmakerViewController()
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
