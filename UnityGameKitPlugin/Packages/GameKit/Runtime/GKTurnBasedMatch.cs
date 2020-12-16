//
//  GKTurnBasedMatch.cs
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
    public class GKTurnBasedMatch : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_loadMatchesWithCompletionHandler(
            ulong invocationId, LoadMatchesDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_loadMatchWithID_withCompletionHandler(
            string matchID,
            ulong invocationId, StaticTurnBasedMatchDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_findMatchForRequest_withCompletionHandler(
            IntPtr request,
            ulong invocationId, StaticTurnBasedMatchDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_acceptInviteWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, TurnBasedMatchDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_declineInviteWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_rematchWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, TurnBasedMatchDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_loadMatchDataWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, ByteArrayDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedMatch_GetPropMessage(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_SetPropMessage(HandleRef ptr, string message, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKTurnBasedMatch_GetPropCreationDate(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedMatch_GetPropMatchID(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_GetPropParticipants(HandleRef ptr, ref IntPtr buffer, ref long count);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedMatch_GetPropCurrentParticipant(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKTurnBasedMatch_GetPropMatchDataMaximumSize(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern GKTurnBasedMatchStatus GKTurnBasedMatch_GetPropStatus(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_GetPropMatchData(
            HandleRef ptr,
            ref IntPtr source,
            ref long length);

        

        #endregion

        internal GKTurnBasedMatch(IntPtr ptr) : base(ptr) {}
        
        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void LoadMatchesWithCompletionHandler(
            Action<GKTurnBasedMatch[],NSError> completionHandler)
        { 
            var completionHandlerCall = InvocationRecord.Next();
            LoadMatchesWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKTurnBasedMatch[],NSError>(completionHandler);
            
            GKTurnBasedMatch_loadMatchesWithCompletionHandler(
                completionHandlerCall.id, LoadMatchesWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch[],NSError>> LoadMatchesWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch[],NSError>>();

        [MonoPInvokeCallback(typeof(LoadMatchesDelegate))]
        private static void LoadMatchesWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr[] matches,
		long matchesCount,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadMatchesWithCompletionHandlerCallbacks[invocation];
            LoadMatchesWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    matches == null ? null : matches.Select(x => new GKTurnBasedMatch(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="matchID"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void LoadMatchWithID(
            string matchID, 
            Action<GKTurnBasedMatch,NSError> completionHandler)
        { 
            
            var completionHandlerCall = InvocationRecord.Next();
            LoadMatchWithIDCallbacks[completionHandlerCall] = new ExecutionContext<GKTurnBasedMatch,NSError>(completionHandler);
            
            GKTurnBasedMatch_loadMatchWithID_withCompletionHandler(
                matchID,
                completionHandlerCall.id, LoadMatchWithIDCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>> LoadMatchWithIDCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>>();

        [MonoPInvokeCallback(typeof(StaticTurnBasedMatchDelegate))]
        private static void LoadMatchWithIDCallback(
            ulong invocationId,
            IntPtr match,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadMatchWithIDCallbacks[invocation];
            LoadMatchWithIDCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="request"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void FindMatchForRequest(
            GKMatchRequest request, 
            Action<GKTurnBasedMatch,NSError> completionHandler)
        { 
            
            var completionHandlerCall = InvocationRecord.Next();
            FindMatchForRequestCallbacks[completionHandlerCall] = new ExecutionContext<GKTurnBasedMatch,NSError>(completionHandler);
            
            GKTurnBasedMatch_findMatchForRequest_withCompletionHandler(
                request != null ? HandleRef.ToIntPtr(request.Handle) : IntPtr.Zero,
                completionHandlerCall.id, FindMatchForRequestCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>> FindMatchForRequestCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>>();

        [MonoPInvokeCallback(typeof(StaticTurnBasedMatchDelegate))]
        private static void FindMatchForRequestCallback(
            ulong invocationId,
            IntPtr match,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = FindMatchForRequestCallbacks[invocation];
            FindMatchForRequestCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void AcceptInviteWithCompletionHandler(
            Action<GKTurnBasedMatch,NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            AcceptInviteWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKTurnBasedMatch,NSError>(completionHandler);
            
            GKTurnBasedMatch_acceptInviteWithCompletionHandler(
                Handle,
                completionHandlerCall.id, AcceptInviteWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>> AcceptInviteWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>>();

        [MonoPInvokeCallback(typeof(TurnBasedMatchDelegate))]
        private static void AcceptInviteWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr match,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = AcceptInviteWithCompletionHandlerCallbacks[invocation];
            AcceptInviteWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void DeclineInviteWithCompletionHandler(
            Action<NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            DeclineInviteWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_declineInviteWithCompletionHandler(
                Handle,
                completionHandlerCall.id, DeclineInviteWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> DeclineInviteWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void DeclineInviteWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = DeclineInviteWithCompletionHandlerCallbacks[invocation];
            DeclineInviteWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void RematchWithCompletionHandler(
            Action<GKTurnBasedMatch,NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            RematchWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKTurnBasedMatch,NSError>(completionHandler);
            
            GKTurnBasedMatch_rematchWithCompletionHandler(
                Handle,
                completionHandlerCall.id, RematchWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>> RematchWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedMatch,NSError>>();

        [MonoPInvokeCallback(typeof(TurnBasedMatchDelegate))]
        private static void RematchWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr match,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = RematchWithCompletionHandlerCallbacks[invocation];
            RematchWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKTurnBasedMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void LoadMatchDataWithCompletionHandler(
            Action<byte[],NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            LoadMatchDataWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<byte[],NSError>(completionHandler);
            
            GKTurnBasedMatch_loadMatchDataWithCompletionHandler(
                Handle,
                completionHandlerCall.id, LoadMatchDataWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        		private static readonly Dictionary<InvocationRecord,ExecutionContext<byte[],NSError>> LoadMatchDataWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<byte[],NSError>>();

        [MonoPInvokeCallback(typeof(ByteArrayDelegate))]        
		private static void LoadMatchDataWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr matchData, long matchDataLength,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadMatchDataWithCompletionHandlerCallbacks[invocation];
            LoadMatchDataWithCompletionHandlerCallbacks.Remove(invocation);

            var bytes = new byte[matchDataLength];
            Marshal.Copy(matchData, bytes, 0, (int) matchDataLength);
            
            executionContext.Invoke(
                    bytes,
                    error == IntPtr.Zero ? null : new NSError(error));
        }
        

        
        
        
        /// <value>Message</value>
        public string Message
        {
            get
            {
                IntPtr message = GKTurnBasedMatch_GetPropMessage(Handle);
                return Marshal.PtrToStringAuto(message);
            }
            set
            {
                GKTurnBasedMatch_SetPropMessage(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>CreationDate</value>
        public DateTime CreationDate
        {
            get
            {
                double creationDate = GKTurnBasedMatch_GetPropCreationDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(creationDate);;
            }
        }

        
        /// <value>MatchID</value>
        public string MatchID
        {
            get
            {
                IntPtr matchID = GKTurnBasedMatch_GetPropMatchID(Handle);
                return Marshal.PtrToStringAuto(matchID);
            }
        }

        
        /// <value>Participants</value>
        public GKTurnBasedParticipant[] Participants
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKTurnBasedMatch_GetPropParticipants(Handle, ref bufferPtr, ref bufferLen);

                var participants = new GKTurnBasedParticipant[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    participants[i] = ptr2 == IntPtr.Zero ? null : new GKTurnBasedParticipant(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return participants;
            }
        }

        
        /// <value>CurrentParticipant</value>
        public GKTurnBasedParticipant CurrentParticipant
        {
            get
            {
                IntPtr currentParticipant = GKTurnBasedMatch_GetPropCurrentParticipant(Handle);
                return currentParticipant == IntPtr.Zero ? null : new GKTurnBasedParticipant(currentParticipant);
            }
        }

        
        /// <value>MatchDataMaximumSize</value>
        public ulong MatchDataMaximumSize
        {
            get
            {
                ulong matchDataMaximumSize = GKTurnBasedMatch_GetPropMatchDataMaximumSize(Handle);
                return matchDataMaximumSize;
            }
        }

        
        /// <value>Status</value>
        public GKTurnBasedMatchStatus Status
        {
            get
            {
                GKTurnBasedMatchStatus status = GKTurnBasedMatch_GetPropStatus(Handle);
                return (GKTurnBasedMatchStatus) status;
            }
        }

        
        /// <value>MatchData</value>
        public byte[] MatchData
        {
            get 
            {
                var source = IntPtr.Zero;
                long length = 0;

                GKTurnBasedMatch_GetPropMatchData(
                    Handle,
                    ref source,
                    ref length);

                var bytes = new byte[length];
                Marshal.Copy(source, bytes, 0, (int) length);
                return bytes;
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKTurnBasedMatch Dispose");
                GKTurnBasedMatch_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKTurnBasedMatch()
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
