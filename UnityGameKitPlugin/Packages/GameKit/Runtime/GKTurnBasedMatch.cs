//
//  GKTurnBasedMatch.cs
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

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_saveCurrentTurnWithMatchData_completionHandler(
            HandleRef ptr, 
            byte[] matchData,
			int matchDataLength,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_endTurnWithNextParticipants_turnTimeout_matchData_completionHandler(
            HandleRef ptr, 
            IntPtr[] nextParticipants,
			int nextParticipantsCount,
            double timeout,
            byte[] matchData,
			int matchDataLength,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_endMatchInTurnWithMatchData_completionHandler(
            HandleRef ptr, 
            byte[] matchData,
			int matchDataLength,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_endMatchInTurnWithMatchData_leaderboardScores_achievements_completionHandler(
            HandleRef ptr, 
            byte[] matchData,
			int matchDataLength,
            IntPtr[] scores,
			int scoresCount,
            IntPtr[] achievements,
            int achievementsCount,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_participantQuitInTurnWithOutcome_nextParticipants_turnTimeout_matchData_completionHandler(
            HandleRef ptr, 
            long matchOutcome,
            IntPtr[] nextParticipants,
			int nextParticipantsCount,
            double timeout,
            byte[] matchData,
			int matchDataLength,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_participantQuitOutOfTurnWithOutcome_withCompletionHandler(
            HandleRef ptr, 
            long matchOutcome,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_removeWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_saveMergedMatchData_withResolvedExchanges_completionHandler(
            HandleRef ptr, 
            byte[] matchData,
			int matchDataLength,
            IntPtr[] exchanges,
			int exchangesCount,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_sendExchangeToParticipants_data_localizableMessageKey_arguments_timeout_completionHandler(
            HandleRef ptr, 
            IntPtr[] participants,
			int participantsCount,
            byte[] data,
			int dataLength,
            string key,
            string[] arguments,
			int argumentsCount,
            double timeout,
            ulong invocationId, TurnBasedExchangeDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_sendReminderToParticipants_localizableMessageKey_arguments_completionHandler(
            HandleRef ptr, 
            IntPtr[] participants,
			int participantsCount,
            string key,
            string[] arguments,
			int argumentsCount,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_setLocalizableMessageWithKey_arguments(
            HandleRef ptr, 
            string key,
            string[] arguments,
			int argumentsCount,
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

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_GetPropActiveExchanges(HandleRef ptr, ref IntPtr buffer, ref long count);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_GetPropCompletedExchanges(HandleRef ptr, ref IntPtr buffer, ref long count);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKTurnBasedMatch_GetPropExchangeDataMaximumSize(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKTurnBasedMatch_GetPropExchangeMaxInitiatedExchangesPerPlayer(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedMatch_GetPropExchanges(HandleRef ptr, ref IntPtr buffer, ref long count);

        

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
            if(matchData != IntPtr.Zero)
                Marshal.Copy(matchData, bytes, 0, (int) matchDataLength);
            
            executionContext.Invoke(
                    bytes,
                    error == IntPtr.Zero ? null : new NSError(error));
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="matchData"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void SaveCurrentTurnWithMatchData(
            byte[] matchData, 
            Action<NSError> completionHandler)
        { 
            
            var completionHandlerCall = new InvocationRecord(Handle);
            SaveCurrentTurnWithMatchDataCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_saveCurrentTurnWithMatchData_completionHandler(
                Handle,
                matchData,
                matchData.Length,
                completionHandlerCall.id, SaveCurrentTurnWithMatchDataCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> SaveCurrentTurnWithMatchDataCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void SaveCurrentTurnWithMatchDataCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = SaveCurrentTurnWithMatchDataCallbacks[invocation];
            SaveCurrentTurnWithMatchDataCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="nextParticipants"></param><param name="timeout"></param><param name="matchData"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void EndTurnWithNextParticipants(
            GKTurnBasedParticipant[] nextParticipants, 
            double timeout,
            byte[] matchData, 
            Action<NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            EndTurnWithNextParticipantsCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_endTurnWithNextParticipants_turnTimeout_matchData_completionHandler(
                Handle,
                nextParticipants == null ? null : nextParticipants.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				nextParticipants == null ? 0 : nextParticipants.Length,
                timeout,
                matchData,
                matchData.Length,
                completionHandlerCall.id, EndTurnWithNextParticipantsCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> EndTurnWithNextParticipantsCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void EndTurnWithNextParticipantsCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = EndTurnWithNextParticipantsCallbacks[invocation];
            EndTurnWithNextParticipantsCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="matchData"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void EndMatchInTurnWithMatchData(
            byte[] matchData, 
            Action<NSError> completionHandler)
        { 
            
            var completionHandlerCall = new InvocationRecord(Handle);
            EndMatchInTurnWithMatchDataCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_endMatchInTurnWithMatchData_completionHandler(
                Handle,
                matchData,
                matchData.Length,
                completionHandlerCall.id, EndMatchInTurnWithMatchDataCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> EndMatchInTurnWithMatchDataCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void EndMatchInTurnWithMatchDataCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = EndMatchInTurnWithMatchDataCallbacks[invocation];
            EndMatchInTurnWithMatchDataCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="matchData"></param><param name="scores"></param><param name="achievements"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void EndMatchInTurnWithMatchData(
            byte[] matchData, 
            GKLeaderboardScore[] scores, 
            GKAchievement[] achievements, 
            Action<NSError> completionHandler)
        { 
            
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            EndMatchInTurnWithMatchDataCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_endMatchInTurnWithMatchData_leaderboardScores_achievements_completionHandler(
                Handle,
                matchData,
                matchData.Length,
                scores == null ? null : scores.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				scores == null ? 0 : scores.Length,
                achievements == null ? null : achievements.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				achievements == null ? 0 : achievements.Length,
                completionHandlerCall.id, EndMatchInTurnWithMatchDataCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }

        /// <summary>
        /// </summary>
        /// <param name="matchOutcome"></param><param name="nextParticipants"></param><param name="timeout"></param><param name="matchData"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void ParticipantQuitInTurnWithOutcome(
            GKTurnBasedMatchOutcome matchOutcome, 
            GKTurnBasedParticipant[] nextParticipants, 
            double timeout, 
            byte[] matchData, 
            Action<NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            ParticipantQuitInTurnWithOutcomeCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_participantQuitInTurnWithOutcome_nextParticipants_turnTimeout_matchData_completionHandler(
                Handle,
                (long) matchOutcome,
                nextParticipants == null ? null : nextParticipants.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				nextParticipants == null ? 0 : nextParticipants.Length,
                timeout,
                matchData,
                matchData.Length,
                completionHandlerCall.id, ParticipantQuitInTurnWithOutcomeCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> ParticipantQuitInTurnWithOutcomeCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void ParticipantQuitInTurnWithOutcomeCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = ParticipantQuitInTurnWithOutcomeCallbacks[invocation];
            ParticipantQuitInTurnWithOutcomeCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="matchOutcome"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void ParticipantQuitOutOfTurnWithOutcome(
            GKTurnBasedMatchOutcome matchOutcome, 
            Action<NSError> completionHandler)
        { 
            
            var completionHandlerCall = new InvocationRecord(Handle);
            ParticipantQuitOutOfTurnWithOutcomeCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_participantQuitOutOfTurnWithOutcome_withCompletionHandler(
                Handle,
                (long) matchOutcome,
                completionHandlerCall.id, ParticipantQuitOutOfTurnWithOutcomeCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> ParticipantQuitOutOfTurnWithOutcomeCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void ParticipantQuitOutOfTurnWithOutcomeCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = ParticipantQuitOutOfTurnWithOutcomeCallbacks[invocation];
            ParticipantQuitOutOfTurnWithOutcomeCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void RemoveWithCompletionHandler(
            Action<NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            RemoveWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_removeWithCompletionHandler(
                Handle,
                completionHandlerCall.id, RemoveWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> RemoveWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void RemoveWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = RemoveWithCompletionHandlerCallbacks[invocation];
            RemoveWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="matchData"></param><param name="exchanges"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void SaveMergedMatchData(
            byte[] matchData, 
            GKTurnBasedExchange[] exchanges, 
            Action<NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            SaveMergedMatchDataCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_saveMergedMatchData_withResolvedExchanges_completionHandler(
                Handle,
                matchData,
                matchData.Length,
                exchanges == null ? null : exchanges.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				exchanges == null ? 0 : exchanges.Length,
                completionHandlerCall.id, SaveMergedMatchDataCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> SaveMergedMatchDataCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void SaveMergedMatchDataCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = SaveMergedMatchDataCallbacks[invocation];
            SaveMergedMatchDataCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="participants"></param><param name="data"></param><param name="key"></param><param name="arguments"></param><param name="timeout"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void SendExchangeToParticipants(
            GKTurnBasedParticipant[] participants, 
            byte[] data, 
            string key, 
            string[] arguments, 
            double timeout, 
            Action<GKTurnBasedExchange,NSError> completionHandler)
        {
            var completionHandlerCall = new InvocationRecord(Handle);
            SendExchangeToParticipantsCallbacks[completionHandlerCall] = new ExecutionContext<GKTurnBasedExchange,NSError>(completionHandler);
            
            GKTurnBasedMatch_sendExchangeToParticipants_data_localizableMessageKey_arguments_timeout_completionHandler(
                Handle,
                participants == null ? null : participants.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				participants == null ? 0 : participants.Length,
                data,
                data.Length,
                key,
                arguments,
				arguments?.Length ?? 0,
                timeout,
                completionHandlerCall.id, SendExchangeToParticipantsCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedExchange,NSError>> SendExchangeToParticipantsCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKTurnBasedExchange,NSError>>();

        [MonoPInvokeCallback(typeof(TurnBasedExchangeDelegate))]
        private static void SendExchangeToParticipantsCallback(
            ulong invocationId,
            IntPtr match,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = SendExchangeToParticipantsCallbacks[invocation];
            SendExchangeToParticipantsCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKTurnBasedExchange(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="participants"></param><param name="key"></param><param name="arguments"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void SendReminderToParticipants(
            GKTurnBasedParticipant[] participants, 
            string key, 
            string[] arguments, 
            Action<NSError> completionHandler)
        { 
            
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            SendReminderToParticipantsCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedMatch_sendReminderToParticipants_localizableMessageKey_arguments_completionHandler(
                Handle,
                participants == null ? null : participants.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				participants == null ? 0 : participants.Length,
                key,
                arguments,
				arguments?.Length ?? 0,
                completionHandlerCall.id, SendReminderToParticipantsCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> SendReminderToParticipantsCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void SendReminderToParticipantsCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = SendReminderToParticipantsCallbacks[invocation];
            SendReminderToParticipantsCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="key"></param><param name="arguments"></param>
        /// <returns>void</returns>
        public void SetLocalizableMessageWithKey(
            string key, 
            string[] arguments)
        { 
            
            
            GKTurnBasedMatch_setLocalizableMessageWithKey_arguments(
                Handle,
                key,
                arguments,
				arguments?.Length ?? 0,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
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
                if(source != IntPtr.Zero)
                    Marshal.Copy(source, bytes, 0, (int) length);
                return bytes;
            }
        }

        
        /// <value>ActiveExchanges</value>
        public GKTurnBasedExchange[] ActiveExchanges
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKTurnBasedMatch_GetPropActiveExchanges(Handle, ref bufferPtr, ref bufferLen);

                var activeExchanges = new GKTurnBasedExchange[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    activeExchanges[i] = ptr2 == IntPtr.Zero ? null : new GKTurnBasedExchange(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return activeExchanges;
            }
        }

        
        /// <value>CompletedExchanges</value>
        public GKTurnBasedExchange[] CompletedExchanges
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKTurnBasedMatch_GetPropCompletedExchanges(Handle, ref bufferPtr, ref bufferLen);

                var completedExchanges = new GKTurnBasedExchange[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    completedExchanges[i] = ptr2 == IntPtr.Zero ? null : new GKTurnBasedExchange(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return completedExchanges;
            }
        }

        
        /// <value>ExchangeDataMaximumSize</value>
        public ulong ExchangeDataMaximumSize
        {
            get
            {
                ulong exchangeDataMaximumSize = GKTurnBasedMatch_GetPropExchangeDataMaximumSize(Handle);
                return exchangeDataMaximumSize;
            }
        }

        
        /// <value>ExchangeMaxInitiatedExchangesPerPlayer</value>
        public ulong ExchangeMaxInitiatedExchangesPerPlayer
        {
            get
            {
                ulong exchangeMaxInitiatedExchangesPerPlayer = GKTurnBasedMatch_GetPropExchangeMaxInitiatedExchangesPerPlayer(Handle);
                return exchangeMaxInitiatedExchangesPerPlayer;
            }
        }

        
        /// <value>Exchanges</value>
        public GKTurnBasedExchange[] Exchanges
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKTurnBasedMatch_GetPropExchanges(Handle, ref bufferPtr, ref bufferLen);

                var exchanges = new GKTurnBasedExchange[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    exchanges[i] = ptr2 == IntPtr.Zero ? null : new GKTurnBasedExchange(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return exchanges;
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
