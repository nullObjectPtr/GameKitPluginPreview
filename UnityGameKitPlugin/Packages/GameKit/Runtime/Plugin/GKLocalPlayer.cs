//
//  GKLocalPlayer.cs
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
    public class GKLocalPlayer : GKPlayer, IDisposable
    {
        #region dll

        // Class Methods
        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLocalPlayer_registerListener(
            HandleRef ptr, 
            IntPtr listener,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLocalPlayer_unregisterAllListeners(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLocalPlayer_unregisterListener(
            HandleRef ptr, 
            IntPtr listener,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLocalPlayer_loadRecentPlayersWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, LoadRecentPlayersWithCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLocalPlayer_loadChallengableFriendsWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, LoadChallengableFriendsWithCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        // Properties
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLocalPlayer_SetPropAuthenticateHandler(HandleRef ptr, AuthenticateHandler authenticateHandler, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLocalPlayer_GetPropLocalPlayer();

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLocalPlayer_GetPropLocal();

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKLocalPlayer_GetPropAuthenticated(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKLocalPlayer_GetPropUnderage(HandleRef ptr);

        

        #endregion

        internal GKLocalPlayer(IntPtr ptr) : base(ptr) {}
        internal GKLocalPlayer(){}
        
        
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="listener"></param>
        /// <returns>void</returns>
        public void RegisterListener(
            LocalPlayerListener listener)
        { 
            
            GKLocalPlayer_registerListener(
                Handle, 
                listener != null ? HandleRef.ToIntPtr(listener.Handle) : IntPtr.Zero, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>void</returns>
        public void UnregisterAllListeners()
        { 
            GKLocalPlayer_unregisterAllListeners(
                Handle, out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="listener"></param>
        /// <returns>void</returns>
        public void UnregisterListener(
            LocalPlayerListener listener)
        { 
            
            GKLocalPlayer_unregisterListener(
                Handle, 
                listener != null ? HandleRef.ToIntPtr(listener.Handle) : IntPtr.Zero, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void LoadRecentPlayersWithCompletionHandler(
            Action<GKPlayer[],NSError> completionHandler)
        { 
            
            var completionHandlerCall = new InvocationRecord(Handle);
            LoadRecentPlayersWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKPlayer[],NSError>(completionHandler);
            
            GKLocalPlayer_loadRecentPlayersWithCompletionHandler(
                Handle, 
                completionHandlerCall.id, LoadRecentPlayersWithCompletionHandlerCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>> LoadRecentPlayersWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>>();

        [MonoPInvokeCallback(typeof(LoadRecentPlayersWithCompletionDelegate))]
        private static void LoadRecentPlayersWithCompletionHandlerCallback(IntPtr thisPtr, ulong invocationId, IntPtr[] recentPlayers,
		long recentPlayersCount, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = LoadRecentPlayersWithCompletionHandlerCallbacks[invocation];
            LoadRecentPlayersWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    recentPlayers == null ? null : recentPlayers.Select(x => new GKPlayer(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void LoadChallengableFriendsWithCompletionHandler(
            Action<GKPlayer[],NSError> completionHandler)
        { 
            
            var completionHandlerCall = new InvocationRecord(Handle);
            LoadChallengableFriendsWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKPlayer[],NSError>(completionHandler);
            
            GKLocalPlayer_loadChallengableFriendsWithCompletionHandler(
                Handle, 
                completionHandlerCall.id, LoadChallengableFriendsWithCompletionHandlerCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>> LoadChallengableFriendsWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>>();

        [MonoPInvokeCallback(typeof(LoadChallengableFriendsWithCompletionDelegate))]
        private static void LoadChallengableFriendsWithCompletionHandlerCallback(IntPtr thisPtr, ulong invocationId, IntPtr[] recentPlayers,
		long recentPlayersCount, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = LoadChallengableFriendsWithCompletionHandlerCallbacks[invocation];
            LoadChallengableFriendsWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    recentPlayers == null ? null : recentPlayers.Select(x => new GKPlayer(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        
        /// <value>AuthenticateHandler</value>
        public Action<UIViewController,NSError> AuthenticateHandler
        {
            get 
            {
                AuthenticateHandlerCallbacks.TryGetValue(
                    HandleRef.ToIntPtr(Handle), 
                    out ExecutionContext<UIViewController,NSError> value);
                return value.Callback;
            }    
            set 
            {
                IntPtr myPtr = HandleRef.ToIntPtr(Handle);
                if(value == null)
                {
                    AuthenticateHandlerCallbacks.Remove(myPtr);
                }
                else
                {
                    AuthenticateHandlerCallbacks[myPtr] = new ExecutionContext<UIViewController,NSError>(value);
                }
                GKLocalPlayer_SetPropAuthenticateHandler(Handle, AuthenticateHandlerCallback, out IntPtr exceptionPtr);

                if(exceptionPtr != IntPtr.Zero)
                {
                    var nativeException = new NSException(exceptionPtr);
                    throw new GameKitException(nativeException, nativeException.Reason);
                }
            }
        }

        private static readonly Dictionary<IntPtr,ExecutionContext<UIViewController,NSError>> AuthenticateHandlerCallbacks = new Dictionary<IntPtr,ExecutionContext<UIViewController,NSError>>();

        [MonoPInvokeCallback(typeof(AuthenticateHandler))]
        private static void AuthenticateHandlerCallback(IntPtr thisPtr, IntPtr viewController, IntPtr error)
        {
            if(AuthenticateHandlerCallbacks.TryGetValue(thisPtr, out ExecutionContext<UIViewController,NSError> callback))
            {
                callback.Invoke(
                        viewController == IntPtr.Zero ? null : new UIViewController(viewController),
                        error == IntPtr.Zero ? null : new NSError(error));
            }
        }

        
        /// <value>LocalPlayer</value>
        public static GKLocalPlayer LocalPlayer
        {
            get 
            { 
                IntPtr localPlayer = GKLocalPlayer_GetPropLocalPlayer();
                return localPlayer == IntPtr.Zero ? null : new GKLocalPlayer(localPlayer);
            }
        }

        
        /// <value>Local</value>
        public static GKLocalPlayer Local
        {
            get 
            { 
                IntPtr local = GKLocalPlayer_GetPropLocal();
                return local == IntPtr.Zero ? null : new GKLocalPlayer(local);
            }
        }

        
        /// <value>Authenticated</value>
        public bool Authenticated
        {
            get 
            { 
                bool authenticated = GKLocalPlayer_GetPropAuthenticated(Handle);
                return authenticated;
            }
        }

        
        /// <value>Underage</value>
        public bool Underage
        {
            get 
            { 
                bool underage = GKLocalPlayer_GetPropUnderage(Handle);
                return underage;
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLocalPlayer_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKLocalPlayer Dispose");
                GKLocalPlayer_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKLocalPlayer()
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
