//
//  GKTurnBasedMatchmakerViewController.cs
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
    public class GKTurnBasedMatchmakerViewController : GKViewController, IDisposable
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif

        // Class Methods
        

        
        [DllImport(dll)]
        private static extern IntPtr GKTurnBasedMatchmakerViewController_initWithMatchRequest(
            IntPtr request, 
            out IntPtr exceptionPtr
            );
        

        

        

        // Properties
        
        [DllImport(dll)]
        private static extern bool GKTurnBasedMatchmakerViewController_GetPropShowExistingMatches(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKTurnBasedMatchmakerViewController_SetPropShowExistingMatches(HandleRef ptr, bool showExistingMatches, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern IntPtr GKTurnBasedMatchmakerViewController_GetPropTurnBasedMatchmakerDelegate(HandleRef ptr);
        
        [DllImport(dll)]
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
                return turnBasedMatchmakerDelegate == IntPtr.Zero ? null : GKTurnBasedMatchmakerViewControllerDelegate.GetInstance(turnBasedMatchmakerDelegate);
            }
            set
            {
                GKTurnBasedMatchmakerViewController_SetPropTurnBasedMatchmakerDelegate(Handle, value != null ? HandleRef.ToIntPtr(value.Handle) : IntPtr.Zero, out IntPtr exceptionPtr);
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
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
