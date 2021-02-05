//
//  GKMatch.cs
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
    /// A peer-to-peer network between a group of devices that are connected to Game Center.
    /// </summary>
    public class GKMatch : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatch_disconnect(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKMatch_sendDataToAllPlayers_withDataMode_error(
            HandleRef ptr,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
            byte[] bytes,
            long length,
            long mode,
            out IntPtr errorPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatch_chooseBestHostingPlayerWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, GKPlayerDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatch_rematchWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, MatchCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatch_voiceChatWithName(
            HandleRef ptr, 
            string name,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKMatch_sendData_toPlayers_dataMode_error(
            HandleRef ptr,
            byte[] data,
            int dataLength,
            IntPtr[] players,
            int playersCount,
            long mode,
            out IntPtr errorPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatch_GetPropDelegate(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatch_SetPropDelegate(HandleRef ptr, IntPtr del, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKMatch_GetPropExpectedPlayerCount(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatch_GetPropPlayers(HandleRef ptr, ref IntPtr buffer, ref long count);

        

        #endregion

        internal GKMatch(IntPtr ptr) : base(ptr) {}
        internal GKMatch(){}
        
        
        
        


        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>void</returns>
        public void Disconnect()
        { 
            GKMatch_disconnect(
                Handle,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>val</returns>
		public bool SendDataToAllPlayers(
            byte[] bytes,
            GKMatchSendDataMode mode)
        {
            var val = GKMatch_sendDataToAllPlayers_withDataMode_error(
                Handle,
                bytes,
                bytes.Length,
                (long) mode,
                out IntPtr errorPtr);
            if (errorPtr != IntPtr.Zero)
            {
                var ex = new Exception(new NSError(errorPtr).LocalizedDescription);
            }
            return val;
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void ChooseBestHostingPlayerWithCompletionHandler(
            Action<GKPlayer> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            ChooseBestHostingPlayerWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKPlayer>(completionHandler);
            
            GKMatch_chooseBestHostingPlayerWithCompletionHandler(
                Handle,
                completionHandlerCall.id, ChooseBestHostingPlayerWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKPlayer>> ChooseBestHostingPlayerWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKPlayer>>();

        [MonoPInvokeCallback(typeof(GKPlayerDelegate))]
        private static void ChooseBestHostingPlayerWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr player)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = ChooseBestHostingPlayerWithCompletionHandlerCallbacks[invocation];
            ChooseBestHostingPlayerWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    player == IntPtr.Zero ? null : new GKPlayer(player));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void RematchWithCompletionHandler(
            Action<GKMatch,NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            RematchWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKMatch,NSError>(completionHandler);
            
            GKMatch_rematchWithCompletionHandler(
                Handle,
                completionHandlerCall.id, RematchWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKMatch,NSError>> RematchWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKMatch,NSError>>();

        [MonoPInvokeCallback(typeof(MatchCompletionDelegate))]
        private static void RematchWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr match,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = RematchWithCompletionHandlerCallbacks[invocation];
            RematchWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    match == IntPtr.Zero ? null : new GKMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>val</returns>
        public GKVoiceChat VoiceChatWithName(
            string name)
        { 
            
            var val = GKMatch_voiceChatWithName(
                Handle,
                name,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val == IntPtr.Zero ? null : new GKVoiceChat(val);
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="data"></param><param name="players"></param><param name="mode"></param><param name="error"></param>
        /// <returns>val</returns>
        public bool SendDataToPlayers(
           byte[] data, 
           GKPlayer[] players, 
           GKMatchSendDataMode mode)
       { 
           var val = GKMatch_sendData_toPlayers_dataMode_error(
               Handle, 
               data, 
               data.Length,
               players?.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
               players?.Length ?? 0,
               (long) mode,
               out var errorPtr);

           if(errorPtr != IntPtr.Zero)
           {
               var nativeException = new NSError(errorPtr);
               throw new Exception(nativeException.LocalizedDescription);
           }
           
           return val;
       }
        

        
        
        
        /// <value>Delegate</value>
        public MatchDelegate Delegate
        {
            get
            {
                IntPtr del = GKMatch_GetPropDelegate(Handle);
                return del == IntPtr.Zero ? null : MatchDelegate.GetInstance(del);
            }
            set
            {
                GKMatch_SetPropDelegate(Handle, value != null ? HandleRef.ToIntPtr(value.Handle) : IntPtr.Zero, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>ExpectedPlayerCount</value>
        public ulong ExpectedPlayerCount
        {
            get
            {
                ulong expectedPlayerCount = GKMatch_GetPropExpectedPlayerCount(Handle);
                return expectedPlayerCount;
            }
        }

        
        /// <value>Players</value>
        public GKPlayer[] Players
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKMatch_GetPropPlayers(Handle, ref bufferPtr, ref bufferLen);

                var players = new GKPlayer[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    players[i] = ptr2 == IntPtr.Zero ? null : new GKPlayer(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return players;
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatch_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKMatch Dispose");
                GKMatch_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKMatch()
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
