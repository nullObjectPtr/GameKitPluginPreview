//
//  GKMatchmaker.cs
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
    public class GKMatchmaker : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatchmaker_sharedMatchmaker(
            out IntPtr exceptionPtr);

        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_cancel(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_cancelPendingInviteToPlayer(
            HandleRef ptr, 
            IntPtr player,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_stopBrowsingForNearbyPlayers(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_finishMatchmakingForMatch(
            HandleRef ptr, 
            IntPtr match,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_startBrowsingForNearbyPlayersWithHandler(
            HandleRef ptr, 
            ulong invocationId, StartBrowsingForNearbyPlayersDelegate reachableHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_findMatchForRequest_withCompletionHandler(
            HandleRef ptr, 
            IntPtr request,
            ulong invocationId, FindMatchForRequestDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_matchForInvite_completionHandler(
            HandleRef ptr, 
            IntPtr invite,
            ulong invocationId, MatchCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_addPlayersToMatch_matchRequest_completionHandler(
            HandleRef ptr, 
            IntPtr match,
            IntPtr matchRequest,
            ulong invocationId, CompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_findPlayersForHostedRequest_withCompletionHandler(
            HandleRef ptr, 
            IntPtr request,
            ulong invocationId, FindPlayersForHostedRequestDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_queryActivityWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, QueryActivityDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_queryPlayerGroupActivity_withCompletionHandler(
            HandleRef ptr, 
            ulong playerGroup,
            ulong invocationId, QueryActivityDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        // Properties
        

        #endregion

        internal GKMatchmaker(IntPtr ptr) : base(ptr) {}
        
        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>val</returns>
        public static GKMatchmaker SharedMatchmaker()
        { 
            var val = GKMatchmaker_sharedMatchmaker(out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val == IntPtr.Zero ? null : new GKMatchmaker(val);
        }
        

        
        
        


        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>void</returns>
        public void Cancel()
        { 
            GKMatchmaker_cancel(
                Handle, out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="player"></param>
        /// <returns>void</returns>
        public void CancelPendingInviteToPlayer(
            GKPlayer player)
        { 
            
            GKMatchmaker_cancelPendingInviteToPlayer(
                Handle, 
                player != null ? HandleRef.ToIntPtr(player.Handle) : IntPtr.Zero, 
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
        public void StopBrowsingForNearbyPlayers()
        { 
            GKMatchmaker_stopBrowsingForNearbyPlayers(
                Handle, out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="match"></param>
        /// <returns>void</returns>
        public void FinishMatchmakingForMatch(
            GKMatch match)
        { 
            
            GKMatchmaker_finishMatchmakingForMatch(
                Handle, 
                match != null ? HandleRef.ToIntPtr(match.Handle) : IntPtr.Zero, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="reachableHandler"></param>
        /// <returns>void</returns>
        public void StartBrowsingForNearbyPlayersWithHandler(
            Action<GKPlayer,bool> reachableHandler)
        { 
            
            var reachableHandlerCall = new InvocationRecord(Handle);
            StartBrowsingForNearbyPlayersWithHandlerCallbacks[reachableHandlerCall] = new ExecutionContext<GKPlayer,bool>(reachableHandler);
            
            GKMatchmaker_startBrowsingForNearbyPlayersWithHandler(
                Handle, 
                reachableHandlerCall.id, StartBrowsingForNearbyPlayersWithHandlerCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKPlayer,bool>> StartBrowsingForNearbyPlayersWithHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKPlayer,bool>>();

        [MonoPInvokeCallback(typeof(StartBrowsingForNearbyPlayersDelegate))]
        private static void StartBrowsingForNearbyPlayersWithHandlerCallback(IntPtr thisPtr, ulong invocationId, IntPtr player, bool reachable)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = StartBrowsingForNearbyPlayersWithHandlerCallbacks[invocation];
            StartBrowsingForNearbyPlayersWithHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    reachable);
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="request"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void FindMatchForRequest(
            GKMatchRequest request, 
            Action<GKMatch,NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            FindMatchForRequestCallbacks[completionHandlerCall] = new ExecutionContext<GKMatch,NSError>(completionHandler);
            
            GKMatchmaker_findMatchForRequest_withCompletionHandler(
                Handle, 
                request != null ? HandleRef.ToIntPtr(request.Handle) : IntPtr.Zero, 
                
                completionHandlerCall.id, FindMatchForRequestCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKMatch,NSError>> FindMatchForRequestCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKMatch,NSError>>();

        [MonoPInvokeCallback(typeof(FindMatchForRequestDelegate))]
        private static void FindMatchForRequestCallback(IntPtr thisPtr, ulong invocationId, IntPtr match, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = FindMatchForRequestCallbacks[invocation];
            FindMatchForRequestCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="invite"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void MatchForInvite(
            GKInvite invite, 
            Action<GKMatch,NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            MatchForInviteCallbacks[completionHandlerCall] = new ExecutionContext<GKMatch,NSError>(completionHandler);
            
            GKMatchmaker_matchForInvite_completionHandler(
                Handle, 
                invite != null ? HandleRef.ToIntPtr(invite.Handle) : IntPtr.Zero, 
                
                completionHandlerCall.id, MatchForInviteCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKMatch,NSError>> MatchForInviteCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKMatch,NSError>>();

        [MonoPInvokeCallback(typeof(MatchCompletionDelegate))]
        private static void MatchForInviteCallback(IntPtr thisPtr, ulong invocationId, IntPtr match, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = MatchForInviteCallbacks[invocation];
            MatchForInviteCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="match"></param><param name="matchRequest"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void AddPlayersToMatch(
            GKMatch match, 
            GKMatchRequest matchRequest, 
            Action<NSError> completionHandler)
        { 
            
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            AddPlayersToMatchCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKMatchmaker_addPlayersToMatch_matchRequest_completionHandler(
                Handle, 
                match != null ? HandleRef.ToIntPtr(match.Handle) : IntPtr.Zero, 
                
                matchRequest != null ? HandleRef.ToIntPtr(matchRequest.Handle) : IntPtr.Zero, 
                
                completionHandlerCall.id, AddPlayersToMatchCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> AddPlayersToMatchCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(CompletionDelegate))]
        private static void AddPlayersToMatchCallback(IntPtr thisPtr, ulong invocationId, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = AddPlayersToMatchCallbacks[invocation];
            AddPlayersToMatchCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="request"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void FindPlayersForHostedRequest(
            GKMatchRequest request, 
            Action<GKPlayer[],NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            FindPlayersForHostedRequestCallbacks[completionHandlerCall] = new ExecutionContext<GKPlayer[],NSError>(completionHandler);
            
            GKMatchmaker_findPlayersForHostedRequest_withCompletionHandler(
                Handle, 
                request != null ? HandleRef.ToIntPtr(request.Handle) : IntPtr.Zero, 
                
                completionHandlerCall.id, FindPlayersForHostedRequestCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>> FindPlayersForHostedRequestCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>>();

        [MonoPInvokeCallback(typeof(FindPlayersForHostedRequestDelegate))]
        private static void FindPlayersForHostedRequestCallback(IntPtr thisPtr, ulong invocationId, IntPtr[] players,
		long playersCount, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = FindPlayersForHostedRequestCallbacks[invocation];
            FindPlayersForHostedRequestCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    players == null ? null : players.Select(x => new GKPlayer(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void QueryActivityWithCompletionHandler(
            Action<long,NSError> completionHandler)
        { 
            
            var completionHandlerCall = new InvocationRecord(Handle);
            QueryActivityWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<long,NSError>(completionHandler);
            
            GKMatchmaker_queryActivityWithCompletionHandler(
                Handle, 
                completionHandlerCall.id, QueryActivityWithCompletionHandlerCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<long,NSError>> QueryActivityWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<long,NSError>>();

        [MonoPInvokeCallback(typeof(QueryActivityDelegate))]
        private static void QueryActivityWithCompletionHandlerCallback(IntPtr thisPtr, ulong invocationId, long activity, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = QueryActivityWithCompletionHandlerCallbacks[invocation];
            QueryActivityWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    activity,
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="playerGroup"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void QueryPlayerGroupActivity(
            ulong playerGroup, 
            Action<long,NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            QueryPlayerGroupActivityCallbacks[completionHandlerCall] = new ExecutionContext<long,NSError>(completionHandler);
            
            GKMatchmaker_queryPlayerGroupActivity_withCompletionHandler(
                Handle, 
                playerGroup, 
                
                completionHandlerCall.id, QueryPlayerGroupActivityCallback, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<long,NSError>> QueryPlayerGroupActivityCallbacks = new Dictionary<InvocationRecord,ExecutionContext<long,NSError>>();

        [MonoPInvokeCallback(typeof(QueryActivityDelegate))]
        private static void QueryPlayerGroupActivityCallback(IntPtr thisPtr, ulong invocationId, long activity, IntPtr error)
        {
            var invocation = new InvocationRecord(thisPtr, invocationId);
            var executionContext = QueryPlayerGroupActivityCallbacks[invocation];
            QueryPlayerGroupActivityCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    activity,
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchmaker_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKMatchmaker Dispose");
                GKMatchmaker_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKMatchmaker()
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
