//
//  GKLeaderboard.cs
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
    public class GKLeaderboard : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboard_loadLeaderboardsWithIDs_completionHandler(
            string[] leaderboardIDs,
			int leaderboardIDsCount,
            ulong invocationId, LoadLeaderboardsWithIDsCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboard_submitScore_context_player_leaderboardIDs_completionHandler(
            long score,
            ulong context,
            IntPtr player,
            string[] leaderboardIDs,
			int leaderboardIDsCount,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboard_submitScore_context_player_completionHandler(
            HandleRef ptr, 
            long score,
            ulong context,
            IntPtr player,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboard_loadPreviousOccurrenceWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, GKLeaderboardDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboard_loadEntriesForPlayers_timeScope_completionHandler(
            HandleRef ptr, 
            IntPtr[] players,
			int playersCount,
            long timeScope,
            ulong invocationId, LoadLeaderboardEntriesDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboard_GetPropTitle(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKLeaderboard_GetPropDuration(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboard_GetPropGroupIdentifier(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKLeaderboard_GetPropStartDate(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKLeaderboard_GetPropNextStartDate(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern GKLeaderboardType GKLeaderboard_GetPropType(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKLeaderboard_GetPropBaseLeaderboardID(HandleRef ptr);

        

        #endregion

        internal GKLeaderboard(IntPtr ptr) : base(ptr) {}
        
        
        /// <summary>
        /// </summary>
        /// <param name="leaderboardIDs"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void LoadLeaderboardsWithIDs(
            string[] leaderboardIDs, 
            Action<GKLeaderboard[],NSError> completionHandler)
        { 
            
            var completionHandlerCall = InvocationRecord.Next();
            LoadLeaderboardsWithIDsCallbacks[completionHandlerCall] = new ExecutionContext<GKLeaderboard[],NSError>(completionHandler);
            
            GKLeaderboard_loadLeaderboardsWithIDs_completionHandler(
                leaderboardIDs,
				leaderboardIDs?.Length ?? 0,
                completionHandlerCall.id, LoadLeaderboardsWithIDsCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKLeaderboard[],NSError>> LoadLeaderboardsWithIDsCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKLeaderboard[],NSError>>();

        [MonoPInvokeCallback(typeof(LoadLeaderboardsWithIDsCompletionDelegate))]
        private static void LoadLeaderboardsWithIDsCallback(
            ulong invocationId,
            IntPtr[] leaderboards,
		    long leaderboardsCount,
            IntPtr error)
        {
            Debug.Log("LoadLeaderboardsCallback");
            Debug.Log($"count: {leaderboardsCount}");
            Debug.Log($"{leaderboards.Length}");
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadLeaderboardsWithIDsCallbacks[invocation];
            LoadLeaderboardsWithIDsCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    leaderboards == null ? null : leaderboards.Select(x => new GKLeaderboard(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="score"></param><param name="context"></param><param name="player"></param><param name="leaderboardIDs"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void SubmitScore(
            long score, 
            ulong context, 
            GKPlayer player, 
            string[] leaderboardIDs, 
            Action<NSError> completionHandler)
        { 
            
            
            
            
            var completionHandlerCall = InvocationRecord.Next();
            SubmitScoreCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKLeaderboard_submitScore_context_player_leaderboardIDs_completionHandler(
                score,
                context,
                player != null ? HandleRef.ToIntPtr(player.Handle) : IntPtr.Zero,
                leaderboardIDs,
				leaderboardIDs?.Length ?? 0,
                completionHandlerCall.id, SubmitScoreCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> SubmitScoreCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void SubmitScoreCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = SubmitScoreCallbacks[invocation];
            SubmitScoreCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="score"></param><param name="context"></param><param name="player"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void SubmitScore(
            long score, 
            ulong context, 
            GKPlayer player, 
            Action<NSError> completionHandler)
        { 
            
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            SubmitScoreCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKLeaderboard_submitScore_context_player_completionHandler(
                Handle,
                score,
                context,
                player != null ? HandleRef.ToIntPtr(player.Handle) : IntPtr.Zero,
                completionHandlerCall.id, SubmitScoreCallback,
                out var exceptionPtr);

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
        public void LoadPreviousOccurrenceWithCompletionHandler(
            Action<GKLeaderboard,NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            LoadPreviousOccurrenceWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKLeaderboard,NSError>(completionHandler);
            
            GKLeaderboard_loadPreviousOccurrenceWithCompletionHandler(
                Handle,
                completionHandlerCall.id, LoadPreviousOccurrenceWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKLeaderboard,NSError>> LoadPreviousOccurrenceWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKLeaderboard,NSError>>();

        [MonoPInvokeCallback(typeof(GKLeaderboardDelegate))]
        private static void LoadPreviousOccurrenceWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr leaderboards,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadPreviousOccurrenceWithCompletionHandlerCallbacks[invocation];
            LoadPreviousOccurrenceWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    leaderboards == IntPtr.Zero ? null : new GKLeaderboard(leaderboards),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="players"></param><param name="timeScope"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void LoadEntriesForPlayers(
            GKPlayer[] players, 
            GKLeaderboardTimeScope timeScope, 
            Action<GKLeaderboardEntry,GKLeaderboardEntry[],NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            LoadEntriesForPlayersCallbacks[completionHandlerCall] = new ExecutionContext<GKLeaderboardEntry,GKLeaderboardEntry[],NSError>(completionHandler);
            
            GKLeaderboard_loadEntriesForPlayers_timeScope_completionHandler(
                Handle,
                players == null ? null : players.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				players == null ? 0 : players.Length,
                (long) timeScope,
                completionHandlerCall.id, LoadEntriesForPlayersCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKLeaderboardEntry,GKLeaderboardEntry[],NSError>> LoadEntriesForPlayersCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKLeaderboardEntry,GKLeaderboardEntry[],NSError>>();

        [MonoPInvokeCallback(typeof(LoadLeaderboardEntriesDelegate))]
        private static void LoadEntriesForPlayersCallback(
            ulong invocationId,
            IntPtr localPlayerEntry,
            IntPtr[] entries,
		long entriesCount,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadEntriesForPlayersCallbacks[invocation];
            LoadEntriesForPlayersCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    localPlayerEntry == IntPtr.Zero ? null : new GKLeaderboardEntry(localPlayerEntry),
                    entries == null ? null : entries.Select(x => new GKLeaderboardEntry(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        
        /// <value>Title</value>
        public string Title
        {
            get
            {
                IntPtr title = GKLeaderboard_GetPropTitle(Handle);
                return Marshal.PtrToStringAuto(title);
            }
        }

        
        /// <value>Duration</value>
        public DateTime Duration
        {
            get
            {
                double duration = GKLeaderboard_GetPropDuration(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(duration);;
            }
        }

        
        /// <value>GroupIdentifier</value>
        public string GroupIdentifier
        {
            get
            {
                IntPtr groupIdentifier = GKLeaderboard_GetPropGroupIdentifier(Handle);
                return Marshal.PtrToStringAuto(groupIdentifier);
            }
        }

        
        /// <value>StartDate</value>
        public DateTime StartDate
        {
            get
            {
                double startDate = GKLeaderboard_GetPropStartDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(startDate);;
            }
        }

        
        /// <value>NextStartDate</value>
        public DateTime NextStartDate
        {
            get
            {
                double nextStartDate = GKLeaderboard_GetPropNextStartDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(nextStartDate);;
            }
        }

        
        /// <value>Type</value>
        public GKLeaderboardType Type
        {
            get
            {
                GKLeaderboardType type = GKLeaderboard_GetPropType(Handle);
                return (GKLeaderboardType) type;
            }
        }

        
        /// <value>BaseLeaderboardID</value>
        public string BaseLeaderboardID
        {
            get
            {
                IntPtr baseLeaderboardID = GKLeaderboard_GetPropBaseLeaderboardID(Handle);
                return Marshal.PtrToStringAuto(baseLeaderboardID);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKLeaderboard_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKLeaderboard Dispose");
                GKLeaderboard_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKLeaderboard()
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
