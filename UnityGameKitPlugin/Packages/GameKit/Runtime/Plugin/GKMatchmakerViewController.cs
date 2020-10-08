//
//  GKMatchmakerViewController.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on
//  Copyright © 2020 HovelHouseApps. All rights reserved.
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
    public class GKMatchmakerViewController : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatchmakerViewController_initWithMatchRequest(
            IntPtr request, 
            out IntPtr exceptionPtr
            );
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatchmakerViewController_initWithInvite(
            IntPtr invite, 
            out IntPtr exceptionPtr
            );
        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmakerViewController_present(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmakerViewController_dismiss(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmakerViewController_addPlayersToMatch(
            HandleRef ptr, 
            IntPtr match,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmakerViewController_setHostedPlayer_didConnect(
            HandleRef ptr, 
            IntPtr player,
            bool connected,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatchmakerViewController_GetPropMatchmakerDelegate(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmakerViewController_SetPropMatchmakerDelegate(HandleRef ptr, IntPtr matchmakerDelegate, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKMatchmakerViewController_GetPropHosted(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmakerViewController_SetPropHosted(HandleRef ptr, bool hosted, out IntPtr exceptionPtr);

        

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
        /// 
        /// <returns>void</returns>
        public void Present()
        { 
            GKMatchmakerViewController_present(
                Handle, out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>void</returns>
        public void Dismiss()
        { 
            GKMatchmakerViewController_dismiss(
                Handle, out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
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
                out IntPtr exceptionPtr);

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
                out IntPtr exceptionPtr);

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
                return matchmakerDelegate == IntPtr.Zero ? null : new MatchmakerViewControllerDelegate(matchmakerDelegate);
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

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmakerViewController_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
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
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        
    }
}
