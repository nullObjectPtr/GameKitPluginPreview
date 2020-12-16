//
//  GKTurnBasedExchange.cs
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
    public class GKTurnBasedExchange : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedExchange_cancelWithLocalizableMessageKey_arguments_completionHandler(
            HandleRef ptr, 
            string key,
            string[] arguments,
			int argumentsCount,
            ulong invocationId, StaticCompletionDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedExchange_GetPropExchangeID(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedExchange_GetPropMessage(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKTurnBasedExchange_GetPropSender(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKTurnBasedExchange_GetPropCompletionDate(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKTurnBasedExchange_GetPropSendDate(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKTurnBasedExchange_GetPropTimeoutDate(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedExchange_GetPropRecipients(HandleRef ptr, ref IntPtr buffer, ref long count);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedExchange_GetPropReplies(HandleRef ptr, ref IntPtr buffer, ref long count);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern GKTurnBasedExchangeStatus GKTurnBasedExchange_GetPropStatus(HandleRef ptr);

        

        #endregion

        internal GKTurnBasedExchange(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="key"></param><param name="arguments"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public void CancelWithLocalizableMessageKey(
            string key, 
            string[] arguments, 
            Action<NSError> completionHandler)
        { 
            
            
            var completionHandlerCall = new InvocationRecord(Handle);
            CancelWithLocalizableMessageKeyCallbacks[completionHandlerCall] = new ExecutionContext<NSError>(completionHandler);
            
            GKTurnBasedExchange_cancelWithLocalizableMessageKey_arguments_completionHandler(
                Handle,
                key,
                arguments,
				arguments?.Length ?? 0,
                completionHandlerCall.id, CancelWithLocalizableMessageKeyCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<NSError>> CancelWithLocalizableMessageKeyCallbacks = new Dictionary<InvocationRecord,ExecutionContext<NSError>>();

        [MonoPInvokeCallback(typeof(StaticCompletionDelegate))]
        private static void CancelWithLocalizableMessageKeyCallback(
            ulong invocationId,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = CancelWithLocalizableMessageKeyCallbacks[invocation];
            CancelWithLocalizableMessageKeyCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        
        /// <value>ExchangeID</value>
        public string ExchangeID
        {
            get
            {
                IntPtr exchangeID = GKTurnBasedExchange_GetPropExchangeID(Handle);
                return Marshal.PtrToStringAuto(exchangeID);
            }
        }

        
        /// <value>Message</value>
        public string Message
        {
            get
            {
                IntPtr message = GKTurnBasedExchange_GetPropMessage(Handle);
                return Marshal.PtrToStringAuto(message);
            }
        }

        
        /// <value>Sender</value>
        public GKTurnBasedParticipant Sender
        {
            get
            {
                IntPtr sender = GKTurnBasedExchange_GetPropSender(Handle);
                return sender == IntPtr.Zero ? null : new GKTurnBasedParticipant(sender);
            }
        }

        
        /// <value>CompletionDate</value>
        public DateTime CompletionDate
        {
            get
            {
                double completionDate = GKTurnBasedExchange_GetPropCompletionDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(completionDate);;
            }
        }

        
        /// <value>SendDate</value>
        public DateTime SendDate
        {
            get
            {
                double sendDate = GKTurnBasedExchange_GetPropSendDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(sendDate);;
            }
        }

        
        /// <value>TimeoutDate</value>
        public DateTime TimeoutDate
        {
            get
            {
                double timeoutDate = GKTurnBasedExchange_GetPropTimeoutDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(timeoutDate);;
            }
        }

        
        /// <value>Recipients</value>
        public GKTurnBasedParticipant[] Recipients
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKTurnBasedExchange_GetPropRecipients(Handle, ref bufferPtr, ref bufferLen);

                var recipients = new GKTurnBasedParticipant[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    recipients[i] = ptr2 == IntPtr.Zero ? null : new GKTurnBasedParticipant(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return recipients;
            }
        }

        
        /// <value>Replies</value>
        public GKTurnBasedExchangeReply[] Replies
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKTurnBasedExchange_GetPropReplies(Handle, ref bufferPtr, ref bufferLen);

                var replies = new GKTurnBasedExchangeReply[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    replies[i] = ptr2 == IntPtr.Zero ? null : new GKTurnBasedExchangeReply(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return replies;
            }
        }

        
        /// <value>Status</value>
        public GKTurnBasedExchangeStatus Status
        {
            get
            {
                GKTurnBasedExchangeStatus status = GKTurnBasedExchange_GetPropStatus(Handle);
                return (GKTurnBasedExchangeStatus) status;
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKTurnBasedExchange_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKTurnBasedExchange Dispose");
                GKTurnBasedExchange_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKTurnBasedExchange()
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
