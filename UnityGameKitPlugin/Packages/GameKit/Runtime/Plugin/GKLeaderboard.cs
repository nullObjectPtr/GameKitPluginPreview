//
//  GKLeaderboard.cs
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
    public class GKLeaderboard : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboard_GetPropTitle(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboard_GetPropGroupIdentifier(HandleRef ptr);

        

        #endregion

        internal GKLeaderboard(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Title</value>
        public string Title
        {
            get 
            { 
                IntPtr title = GKLeaderboard_GetPropTitle(Handle);
                return Marshal.PtrToStringAuto(title);
            }
        }

        
        /// <value>GroupIdentifier</value>
        public string GroupIdentifier
        {
            get 
            { 
                IntPtr groupIdentifier = GKLeaderboard_GetPropGroupIdentifier(Handle);
                return Marshal.PtrToStringAuto(groupIdentifier);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboard_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKLeaderboard Dispose");
                GKLeaderboard_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKLeaderboard()
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
