//
//  GKAchievement.cs
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
    public class GKAchievement : UnmanagedObject, IDisposable
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif

        // Class Methods
        
        [DllImport(dll)]
        private static extern void GKAchievement_loadAchievementsWithCompletionHandler(
            ulong invocationId, GKAchievementsDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern void GKAchievement_reportAchievements_withCompletionHandler(
            IntPtr[] achievements,
			int achievementsCount,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern void GKAchievement_resetAchievementsWithCompletionHandler(
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern void GKAchievement_reportAchievements_withEligibleChallenges_withCompletionHandler(
            IntPtr[] achievements,
			int achievementsCount,
            IntPtr[] challenges,
			int challengesCount,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        
        [DllImport(dll)]
        private static extern IntPtr GKAchievement_initWithIdentifier(
            string identifier, 
            out IntPtr exceptionPtr
            );
        
        [DllImport(dll)]
        private static extern IntPtr GKAchievement_initWithIdentifier_player(
            string identifier, 
            IntPtr player, 
            out IntPtr exceptionPtr
            );
        

        
        [DllImport(dll)]
        private static extern void GKAchievement_selectChallengeablePlayers_withCompletionHandler(
            HandleRef ptr, 
            IntPtr[] players,
			int playersCount,
            ulong invocationId, GKPlayersDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern IntPtr GKAchievement_challengeComposeControllerWithMessage_players_completionHandler(
            HandleRef ptr, 
            string message,
            IntPtr[] players,
			int playersCount,
            ulong invocationId, GKChallengeComposeCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        [DllImport(dll)]
        private static extern bool GKAchievement_GetPropCompleted(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern bool GKAchievement_GetPropShowsCompletionBanner(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKAchievement_SetPropShowsCompletionBanner(HandleRef ptr, bool showsCompletionBanner, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern IntPtr GKAchievement_GetPropIdentifier(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKAchievement_SetPropIdentifier(HandleRef ptr, string identifier, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern double GKAchievement_GetPropPercentComplete(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKAchievement_SetPropPercentComplete(HandleRef ptr, double percentComplete, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern double GKAchievement_GetPropLastReportedDate(HandleRef ptr);

        

        #endregion

        internal GKAchievement(IntPtr ptr) : base(ptr) {}
        
        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void LoadAchievementsWithCompletionHandler(
            Action<GKAchievement[],NSError> completionHandler)
        { 
            var completionHandlerCall = InvocationRecord.Next();
            LoadAchievementsWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKAchievement[],NSError>(completionHandler);
            
            GKAchievement_loadAchievementsWithCompletionHandler(
                completionHandlerCall.id, LoadAchievementsWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKAchievement[],NSError>> LoadAchievementsWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKAchievement[],NSError>>();

        [MonoPInvokeCallback(typeof(GKAchievementsDelegate))]
        private static void LoadAchievementsWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr[] achievements,
		long achievementsCount,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadAchievementsWithCompletionHandlerCallbacks[invocation];
            LoadAchievementsWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    achievements == null ? null : achievements.Select(x => new GKAchievement(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="achievements"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void ReportAchievements(
            GKAchievement[] achievements, 
            Action<NSError> completionHandler)
        { 
            
            var completionHandlerCall = InvocationRecord.Next();
            ReportAchievementsCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKAchievement_reportAchievements_withCompletionHandler(
                achievements == null ? null : achievements.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				achievements == null ? 0 : achievements.Length,
                completionHandlerCall.id, ReportAchievementsCallback,
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
        public static void ResetAchievementsWithCompletionHandler(
            Action<NSError> completionHandler)
        { 
            var completionHandlerCall = InvocationRecord.Next();
            ResetAchievementsWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKAchievement_resetAchievementsWithCompletionHandler(
                completionHandlerCall.id, ResetAchievementsWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> ResetAchievementsWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void ResetAchievementsWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = ResetAchievementsWithCompletionHandlerCallbacks[invocation];
            ResetAchievementsWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="achievements"></param><param name="challenges"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void ReportAchievements(
            GKAchievement[] achievements, 
            GKChallenge[] challenges, 
            Action<NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = InvocationRecord.Next();
            ReportAchievementsCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKAchievement_reportAchievements_withEligibleChallenges_withCompletionHandler(
                achievements == null ? null : achievements.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				achievements == null ? 0 : achievements.Length,
                challenges == null ? null : challenges.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				challenges == null ? 0 : challenges.Length,
                completionHandlerCall.id, ReportAchievementsCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> ReportAchievementsCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void ReportAchievementsCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = ReportAchievementsCallbacks[invocation];
            ReportAchievementsCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        
        public GKAchievement(
            string identifier
            )
        {
            
            IntPtr ptr = GKAchievement_initWithIdentifier(
                identifier, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        
        public GKAchievement(
            string identifier, 
            GKPlayer player
            )
        {
            
            IntPtr ptr = GKAchievement_initWithIdentifier_player(
                identifier, 
                player != null ? HandleRef.ToIntPtr(player.Handle) : IntPtr.Zero, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="players"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void SelectChallengeablePlayers(
            GKPlayer[] players, 
            Action<GKPlayer[],NSError> completionHandler)
        { 
            
            var completionHandlerCall = new InvocationRecord(Handle);
            SelectChallengeablePlayersCallbacks[completionHandlerCall] = new ExecutionContext<GKPlayer[],NSError>(completionHandler);
            
            GKAchievement_selectChallengeablePlayers_withCompletionHandler(
                Handle,
                players == null ? null : players.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				players == null ? 0 : players.Length,
                completionHandlerCall.id, SelectChallengeablePlayersCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>> SelectChallengeablePlayersCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKPlayer[],NSError>>();

        [MonoPInvokeCallback(typeof(GKPlayersDelegate))]
        private static void SelectChallengeablePlayersCallback(
            ulong invocationId,
            IntPtr[] players,
		long playersCount,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = SelectChallengeablePlayersCallbacks[invocation];
            SelectChallengeablePlayersCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    players == null ? null : players.Select(x => new GKPlayer(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="message"></param><param name="players"></param><param name="completionHandler"></param>
        /// <returns>val</returns>
        public GKViewController ChallengeComposeControllerWithMessage(
            string message, 
            GKPlayer[] players, 
            Action<GKViewController,bool,string[]> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            ChallengeComposeControllerWithMessageCallbacks[completionHandlerCall] = new ExecutionContext<GKViewController,bool,string[]>(completionHandler);
            
            var val = GKAchievement_challengeComposeControllerWithMessage_players_completionHandler(
                Handle,
                message,
                players == null ? null : players.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				players == null ? 0 : players.Length,
                completionHandlerCall.id, ChallengeComposeControllerWithMessageCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val == IntPtr.Zero ? null : new GKViewController(val);
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKViewController,bool,string[]>> ChallengeComposeControllerWithMessageCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKViewController,bool,string[]>>();

        [MonoPInvokeCallback(typeof(GKChallengeComposeCompletionDelegate))]
        private static void ChallengeComposeControllerWithMessageCallback(
            ulong invocationId,
            IntPtr composeController,
            bool didIssueChallenge,
            IntPtr[] sentPlayerIDs,
		long sentPlayerIDsCount)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = ChallengeComposeControllerWithMessageCallbacks[invocation];
            ChallengeComposeControllerWithMessageCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    composeController == IntPtr.Zero ? null : new GKViewController(composeController),
                    didIssueChallenge,
                    sentPlayerIDs == null ? null : sentPlayerIDs.Select(x => Marshal.PtrToStringAuto(x)).ToArray());
        }

        

        
        
        
        /// <value>Completed</value>
        public bool Completed
        {
            get
            {
                bool completed = GKAchievement_GetPropCompleted(Handle);
                return completed;
            }
        }

        
        /// <value>ShowsCompletionBanner</value>
        public bool ShowsCompletionBanner
        {
            get
            {
                bool showsCompletionBanner = GKAchievement_GetPropShowsCompletionBanner(Handle);
                return showsCompletionBanner;
            }
            set
            {
                GKAchievement_SetPropShowsCompletionBanner(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>Identifier</value>
        public string Identifier
        {
            get
            {
                IntPtr identifier = GKAchievement_GetPropIdentifier(Handle);
                return Marshal.PtrToStringAuto(identifier);
            }
            set
            {
                GKAchievement_SetPropIdentifier(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>PercentComplete</value>
        public double PercentComplete
        {
            get
            {
                double percentComplete = GKAchievement_GetPropPercentComplete(Handle);
                return percentComplete;
            }
            set
            {
                GKAchievement_SetPropPercentComplete(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>LastReportedDate</value>
        public DateTime LastReportedDate
        {
            get
            {
                double lastReportedDate = GKAchievement_GetPropLastReportedDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(lastReportedDate);;
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
        private static extern void GKAchievement_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKAchievement Dispose");
                GKAchievement_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKAchievement()
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
