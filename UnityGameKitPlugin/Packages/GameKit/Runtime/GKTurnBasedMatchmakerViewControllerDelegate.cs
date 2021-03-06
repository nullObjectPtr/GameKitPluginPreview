//
//  GKTurnBasedMatchmakerViewControllerDelegate.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace HovelHouse.GameKit
{
    /// <summary>
    /// 
    /// </summary>
    public class GKTurnBasedMatchmakerViewControllerDelegate : UnmanagedObject
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif
        
        [DllImport(dll)]
        private static extern IntPtr GKTurnBasedMatchmakerViewControllerDelegate_init(out IntPtr exceptionPtr);
            
        [DllImport(dll)]
        private static extern void GKTurnBasedMatchmakerViewControllerDelegate_Dispose(HandleRef handle);
            
        #endregion
        
        private static Dictionary<Int64,GKTurnBasedMatchmakerViewControllerDelegate> classInstances =
            new Dictionary<Int64,GKTurnBasedMatchmakerViewControllerDelegate>();
            
        private readonly SynchronizationContext synchronizationContext;
    
        internal static GKTurnBasedMatchmakerViewControllerDelegate GetInstance(IntPtr ptr)
        {
            return classInstances[ptr.ToInt64()];
        }
        
        public GKTurnBasedMatchmakerViewControllerDelegate()
        {
            var ptr = GKTurnBasedMatchmakerViewControllerDelegate_init(
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
            synchronizationContext = SynchronizationContext.Current;
            classInstances[ptr.ToInt64()] = this;
        }


        
        [MonoPInvokeCallback(typeof(GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled))]
        public static void turnBasedMatchmakerViewControllerWasCancelled(
            IntPtr ptr,
            IntPtr viewController)
        {
            try 
            {
                Debug.Log("turnBasedMatchmakerViewControllerWasCancelled");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.turnBasedMatchmakerViewControllerWasCancelled(
                    viewController == IntPtr.Zero ? null : new GKTurnBasedMatchmakerViewController(viewController));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError))]
        public static void turnBasedMatchmakerViewController_didFailWithError(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr error)
        {
            try 
            {
                Debug.Log("turnBasedMatchmakerViewController_didFailWithError");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.turnBasedMatchmakerViewController_didFailWithError(
                    viewController == IntPtr.Zero ? null : new GKTurnBasedMatchmakerViewController(viewController),
                    error == IntPtr.Zero ? null : new NSError(error));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        
        
        public virtual void turnBasedMatchmakerViewControllerWasCancelled(
            GKTurnBasedMatchmakerViewController viewController)
        {
            
        }
        
        public virtual void turnBasedMatchmakerViewController_didFailWithError(
            GKTurnBasedMatchmakerViewController viewController,
            NSError error)
        {
            
        }
        

        
        private bool disposedValue = false; // To detect redundant calls
        
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GKTurnBasedMatchmakerViewControllerDelegate_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKTurnBasedMatchmakerViewControllerDelegate()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        
    }
}
