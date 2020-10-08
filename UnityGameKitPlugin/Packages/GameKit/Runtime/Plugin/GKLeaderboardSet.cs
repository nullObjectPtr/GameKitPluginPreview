//
//  GKLeaderboardSet.cs
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
    public class GKLeaderboardSet : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboardSet_GetPropTitle(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboardSet_GetPropIdentifier(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboardSet_SetPropIdentifier(HandleRef ptr, string identifier, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboardSet_GetPropGroupIdentifier(HandleRef ptr);

        

        #endregion

        internal GKLeaderboardSet(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Title</value>
        public string Title
        {
            get 
            { 
                IntPtr title = GKLeaderboardSet_GetPropTitle(Handle);
                return Marshal.PtrToStringAuto(title);
            }
        }

        
        /// <value>Identifier</value>
        public string Identifier
        {
            get 
            { 
                IntPtr identifier = GKLeaderboardSet_GetPropIdentifier(Handle);
                return Marshal.PtrToStringAuto(identifier);
            }
            set
            {
                GKLeaderboardSet_SetPropIdentifier(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>GroupIdentifier</value>
        public string GroupIdentifier
        {
            get 
            { 
                IntPtr groupIdentifier = GKLeaderboardSet_GetPropGroupIdentifier(Handle);
                return Marshal.PtrToStringAuto(groupIdentifier);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboardSet_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKLeaderboardSet Dispose");
                GKLeaderboardSet_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKLeaderboardSet()
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
