//
//  GKPlayer.cs
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
    public class GKPlayer : GKBasePlayer, IDisposable
    {
        #region dll

        // Class Methods
        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKPlayer_scopedIDsArePersistent(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKPlayer_GetPropGamePlayerID(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKPlayer_GetPropTeamPlayerID(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKPlayer_GetPropAlias(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKPlayer_GetPropDisplayName(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKPlayer_GetPropGuestIdentifier(HandleRef ptr);

        

        #endregion

        internal GKPlayer(IntPtr ptr) : base(ptr) {}
        internal GKPlayer(){}
        
        
        
        


        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>val</returns>
        public bool ScopedIDsArePersistent()
        { 
            var val = GKPlayer_scopedIDsArePersistent(
                Handle, out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val;
        }
        

        
        
        
        /// <value>GamePlayerID</value>
        public string GamePlayerID
        {
            get 
            { 
                IntPtr gamePlayerID = GKPlayer_GetPropGamePlayerID(Handle);
                return Marshal.PtrToStringAuto(gamePlayerID);
            }
        }

        
        /// <value>TeamPlayerID</value>
        public string TeamPlayerID
        {
            get 
            { 
                IntPtr teamPlayerID = GKPlayer_GetPropTeamPlayerID(Handle);
                return Marshal.PtrToStringAuto(teamPlayerID);
            }
        }

        
        /// <value>Alias</value>
        public string Alias
        {
            get 
            { 
                IntPtr alias = GKPlayer_GetPropAlias(Handle);
                return Marshal.PtrToStringAuto(alias);
            }
        }

        
        /// <value>DisplayName</value>
        public new string DisplayName
        {
            get 
            { 
                IntPtr displayName = GKPlayer_GetPropDisplayName(Handle);
                return Marshal.PtrToStringAuto(displayName);
            }
        }

        
        /// <value>GuestIdentifier</value>
        public string GuestIdentifier
        {
            get 
            { 
                IntPtr guestIdentifier = GKPlayer_GetPropGuestIdentifier(Handle);
                return Marshal.PtrToStringAuto(guestIdentifier);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKPlayer_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKPlayer Dispose");
                GKPlayer_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKPlayer()
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
