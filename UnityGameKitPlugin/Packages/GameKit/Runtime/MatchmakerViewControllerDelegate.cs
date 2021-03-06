//
//  MatchmakerViewControllerDelegate.cs
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
    public class MatchmakerViewControllerDelegate : UnmanagedObject
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif
        
        [DllImport(dll)]
        private static extern IntPtr MatchmakerViewControllerDelegate_init(out IntPtr exceptionPtr);
            
        [DllImport(dll)]
        private static extern void MatchmakerViewControllerDelegate_Dispose(HandleRef handle);
            
        #endregion
        
        private static Dictionary<Int64,MatchmakerViewControllerDelegate> classInstances =
            new Dictionary<Int64,MatchmakerViewControllerDelegate>();
            
        private readonly SynchronizationContext synchronizationContext;
    
        internal static MatchmakerViewControllerDelegate GetInstance(IntPtr ptr)
        {
            return classInstances[ptr.ToInt64()];
        }
        
        public MatchmakerViewControllerDelegate()
        {
            var ptr = MatchmakerViewControllerDelegate_init(
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


        
        [MonoPInvokeCallback(typeof(MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch))]
        public static void matchmakerViewController_didFindMatch(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr match)
        {
            try 
            {
                Debug.Log("matchmakerViewController_didFindMatch");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.matchmakerViewController_didFindMatch(
                    viewController == IntPtr.Zero ? null : new GKMatchmakerViewController(viewController),
                    match == IntPtr.Zero ? null : new GKMatch(match));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled))]
        public static void matchmakerViewControllerWasCancelled(
            IntPtr ptr,
            IntPtr viewController)
        {
            try 
            {
                Debug.Log("matchmakerViewControllerWasCancelled");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.matchmakerViewControllerWasCancelled(
                    viewController == IntPtr.Zero ? null : new GKMatchmakerViewController(viewController));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError))]
        public static void matchmakerViewController_didFailWithError(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr error)
        {
            try 
            {
                Debug.Log("matchmakerViewController_didFailWithError");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.matchmakerViewController_didFailWithError(
                    viewController == IntPtr.Zero ? null : new GKMatchmakerViewController(viewController),
                    error == IntPtr.Zero ? null : new NSError(error));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept))]
        public static void matchmakerViewController_hostedPlayerDidAccept(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr player)
        {
            try 
            {
                Debug.Log("matchmakerViewController_hostedPlayerDidAccept");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.matchmakerViewController_hostedPlayerDidAccept(
                    viewController == IntPtr.Zero ? null : new GKMatchmakerViewController(viewController),
                    player == IntPtr.Zero ? null : new GKPlayer(player));
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers))]
        public static void matchmakerViewController_didFindHostedPlayers(
            IntPtr ptr,
            IntPtr viewController, 
            IntPtr[] players,
			int playersCount)
        {
            try 
            {
                Debug.Log("matchmakerViewController_didFindHostedPlayers");
                var inst = classInstances[ptr.ToInt64()];
                
                
                inst.synchronizationContext.Post((_) => {
                    inst.matchmakerViewController_didFindHostedPlayers(
                    viewController == IntPtr.Zero ? null : new GKMatchmakerViewController(viewController),
                    players == null ? null : players.Select(x => new GKPlayer(x)).ToArray());
                }, null);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        
        
        public virtual void matchmakerViewController_didFindMatch(
            GKMatchmakerViewController viewController,
            GKMatch match)
        {
            
        }
        
        public virtual void matchmakerViewControllerWasCancelled(
            GKMatchmakerViewController viewController)
        {
            
        }
        
        public virtual void matchmakerViewController_didFailWithError(
            GKMatchmakerViewController viewController,
            NSError error)
        {
            
        }
        
        public virtual void matchmakerViewController_hostedPlayerDidAccept(
            GKMatchmakerViewController viewController,
            GKPlayer player)
        {
            
        }
        
        public virtual void matchmakerViewController_didFindHostedPlayers(
            GKMatchmakerViewController viewController,
            GKPlayer[] players)
        {
            
        }
        

        
        private bool disposedValue = false; // To detect redundant calls
        
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                MatchmakerViewControllerDelegate_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~MatchmakerViewControllerDelegate()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        
    }
}
