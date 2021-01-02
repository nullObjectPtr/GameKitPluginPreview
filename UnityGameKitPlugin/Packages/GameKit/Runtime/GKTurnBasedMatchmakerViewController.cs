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
    public class GKTurnBasedMatchmakerViewController : UIViewController, IDisposable
    {
        #region dll

        // Class Methods
        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedMatchmakerViewController_initWithMatchRequest(
            IntPtr request, 
            out IntPtr exceptionPtr
            );
        

        

        

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

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedMatchmakerViewController_GetPropTurnBasedMatchmakerDelegate(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatchmakerViewController_SetPropTurnBasedMatchmakerDelegate(HandleRef ptr, IntPtr turnBasedMatchmakerDelegate, out IntPtr exceptionPtr);

        

        #endregion

        internal GKTurnBasedMatchmakerViewController(IntPtr ptr) : base(ptr) {}
        
        
        
        
        public GKTurnBasedMatchmakerViewController(
            GKMatchRequest request
            )
        {
            
            IntPtr ptr = GKTurnBasedMatchmakerViewController_initWithMatchRequest(
                request != null ? HandleRef.ToIntPtr(request.Handle) : IntPtr.Zero, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        


        
        
        
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

        
        /// <value>TurnBasedMatchmakerDelegate</value>
        public GKTurnBasedMatchmakerViewControllerDelegate TurnBasedMatchmakerDelegate
        {
            get
            {
                IntPtr turnBasedMatchmakerDelegate = GKTurnBasedMatchmakerViewController_GetPropTurnBasedMatchmakerDelegate(Handle);
                return turnBasedMatchmakerDelegate == IntPtr.Zero ? null : new GKTurnBasedMatchmakerViewControllerDelegate(turnBasedMatchmakerDelegate);
            }
            set
            {
                GKTurnBasedMatchmakerViewController_SetPropTurnBasedMatchmakerDelegate(Handle, value != null ? HandleRef.ToIntPtr(value.Handle) : IntPtr.Zero, out IntPtr exceptionPtr);
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
        
        protected override void Dispose(bool disposing)
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
        public new void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        
    }
}
