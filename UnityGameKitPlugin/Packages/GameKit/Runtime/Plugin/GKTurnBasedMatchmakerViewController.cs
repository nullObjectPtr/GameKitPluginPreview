//
//  GKTurnBasedMatchmakerViewController.cs
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
    public class GKTurnBasedMatchmakerViewController : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKTurnBasedMatchmakerViewController_GetPropShowExistingMatches(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatchmakerViewController_SetPropShowExistingMatches(HandleRef ptr, bool showExistingMatches, out IntPtr exceptionPtr);

        

        #endregion

        internal GKTurnBasedMatchmakerViewController(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>ShowExistingMatches</value>
        public bool ShowExistingMatches
        {
            get 
            { 
                bool showExistingMatches = GKTurnBasedMatchmakerViewController_GetPropShowExistingMatches(Handle);
                return showExistingMatches;
            }
            set
            {
                GKTurnBasedMatchmakerViewController_SetPropShowExistingMatches(Handle, value, out IntPtr exceptionPtr);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatchmakerViewController_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKTurnBasedMatchmakerViewController Dispose");
                GKTurnBasedMatchmakerViewController_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKTurnBasedMatchmakerViewController()
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
