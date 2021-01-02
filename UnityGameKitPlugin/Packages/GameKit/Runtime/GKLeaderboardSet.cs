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
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboardSet_loadLeaderboardSetsWithCompletionHandler(
            ulong invocationId, GKLeaderboardSetDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboardSet_loadLeaderboardsWithHandler(
            HandleRef ptr, 
            ulong invocationId, LoadLeaderboardsDelegate handler,
            out IntPtr exceptionPtr);

        

        

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
        
        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void LoadLeaderboardSetsWithCompletionHandler(
            Action<GKLeaderboardSet[],NSError> completionHandler)
        { 
            var completionHandlerCall = InvocationRecord.Next();
            LoadLeaderboardSetsWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKLeaderboardSet[],NSError>(completionHandler);
            
            GKLeaderboardSet_loadLeaderboardSetsWithCompletionHandler(
                completionHandlerCall.id, LoadLeaderboardSetsWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKLeaderboardSet[],NSError>> LoadLeaderboardSetsWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKLeaderboardSet[],NSError>>();

        [MonoPInvokeCallback(typeof(GKLeaderboardSetDelegate))]
        private static void LoadLeaderboardSetsWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr[] leaderboardSets,
		    long leaderboardSetsCount,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadLeaderboardSetsWithCompletionHandlerCallbacks[invocation];
            LoadLeaderboardSetsWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    leaderboardSets == null ? null : leaderboardSets.Select(x => new GKLeaderboardSet(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>void</returns>
        public void LoadLeaderboardsWithHandler(
            Action<GKLeaderboard[],NSError> handler)
        { 
            var handlerCall = new InvocationRecord(Handle);
            LoadLeaderboardsWithHandlerCallbacks[handlerCall] = new ExecutionContext<GKLeaderboard[],NSError>(handler);
            
            GKLeaderboardSet_loadLeaderboardsWithHandler(
                Handle,
                handlerCall.id, LoadLeaderboardsWithHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKLeaderboard[],NSError>> LoadLeaderboardsWithHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKLeaderboard[],NSError>>();

        [MonoPInvokeCallback(typeof(LoadLeaderboardsDelegate))]
        private static void LoadLeaderboardsWithHandlerCallback(
            ulong invocationId,
            IntPtr[] leaderboards,
		long leaderboardsCount,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadLeaderboardsWithHandlerCallbacks[invocation];
            LoadLeaderboardsWithHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    leaderboards == null ? null : leaderboards.Select(x => new GKLeaderboard(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        
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
