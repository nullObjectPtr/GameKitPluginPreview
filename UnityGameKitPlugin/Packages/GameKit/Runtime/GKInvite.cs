//
//  GKInvite.cs
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
    /// A matchmaking invitation sent by another player to the local player.
    /// </summary>
    public class GKInvite : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKInvite_GetPropPlayerGroup(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKInvite_GetPropSender(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKInvite_GetPropHosted(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern uint GKInvite_GetPropPlayerAttributes(HandleRef ptr);

        

        #endregion

        internal GKInvite(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>PlayerGroup</value>
        public ulong PlayerGroup
        {
            get
            {
                ulong playerGroup = GKInvite_GetPropPlayerGroup(Handle);
                return playerGroup;
            }
        }

        
        /// <value>Sender</value>
        public GKPlayer Sender
        {
            get
            {
                IntPtr sender = GKInvite_GetPropSender(Handle);
                return sender == IntPtr.Zero ? null : new GKPlayer(sender);
            }
        }

        
        /// <value>Hosted</value>
        public bool Hosted
        {
            get
            {
                bool hosted = GKInvite_GetPropHosted(Handle);
                return hosted;
            }
        }

        
        /// <value>PlayerAttributes</value>
        public uint PlayerAttributes
        {
            get
            {
                uint playerAttributes = GKInvite_GetPropPlayerAttributes(Handle);
                return playerAttributes;
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKInvite_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKInvite Dispose");
                GKInvite_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKInvite()
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
