//
//  GKBasePlayer.cs
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
    /// A set of parameters for a new live or turn-based match.
    /// </summary>
    public class GKBasePlayer : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKBasePlayer_GetPropDisplayName(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKBasePlayer_GetPropPlayerID(HandleRef ptr);

        

        #endregion

        internal GKBasePlayer(IntPtr ptr) : base(ptr) {}
        internal GKBasePlayer(){}
        
        
        
        


        
        
        
        /// <value>DisplayName</value>
        public string DisplayName
        {
            get
            {
                IntPtr displayName = GKBasePlayer_GetPropDisplayName(Handle);
                return Marshal.PtrToStringAuto(displayName);
            }
        }

        
        /// <value>PlayerID</value>
        public string PlayerID
        {
            get
            {
                IntPtr playerID = GKBasePlayer_GetPropPlayerID(Handle);
                return Marshal.PtrToStringAuto(playerID);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKBasePlayer_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKBasePlayer Dispose");
                GKBasePlayer_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKBasePlayer()
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
