//
//  GKGameCenterControllerDelegate.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace HovelHouse.GameKit
{
    /// <summary>
    /// 
    /// </summary>
    public class GKGameCenterControllerDelegate : UnmanagedObject
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKGameCenterControllerDelegate_init(out IntPtr exceptionPtr);
            
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKGameCenterControllerDelegate_Dispose(HandleRef handle);
            
        #endregion
        
        private static Dictionary<Int64,GKGameCenterControllerDelegate> classInstances =
            new Dictionary<Int64,GKGameCenterControllerDelegate>();
    
        internal GKGameCenterControllerDelegate(IntPtr ptr) : base(ptr)
        {
            classInstances[ptr.ToInt64()] = this;
        }
        
        public GKGameCenterControllerDelegate()
        {
            var ptr = GKGameCenterControllerDelegate_init(
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
            classInstances[ptr.ToInt64()] = this;
        }


        
        [MonoPInvokeCallback(typeof(GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish))]
        public static void gameCenterViewControllerDidFinish(
            IntPtr ptr,
            IntPtr gameCenterViewController)
        {
            try 
            {
                Debug.Log("gameCenterViewControllerDidFinish");
                var inst = classInstances[ptr.ToInt64()];
                
                inst.gameCenterViewControllerDidFinish(
                    gameCenterViewController == IntPtr.Zero ? null : new GKGameCenterViewController(gameCenterViewController));
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        
        
        public virtual void gameCenterViewControllerDidFinish(
            GKGameCenterViewController gameCenterViewController)
        {
            
        }
        

        
        private bool disposedValue = false; // To detect redundant calls
        
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GKGameCenterControllerDelegate_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKGameCenterControllerDelegate()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        
    }
}
