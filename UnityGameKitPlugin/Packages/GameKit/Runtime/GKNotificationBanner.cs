//
//  GKNotificationBanner.cs
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
    public class GKNotificationBanner : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKNotificationBanner_showBannerWithTitle_message_completionHandler(
            string title,
            string message,
            ulong invocationId, VoidDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKNotificationBanner_showBannerWithTitle_message_duration_completionHandler(
            string title,
            string message,
            double duration,
            ulong invocationId, VoidDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

        

        

        // Properties
        

        #endregion

        internal GKNotificationBanner(IntPtr ptr) : base(ptr) {}
        
        
        /// <summary>
        /// </summary>
        /// <param name="title"></param><param name="message"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void ShowBannerWithTitle(
            string title, 
            string message, 
            Action completionHandler)
        { 
            
            
            var completionHandlerCall = InvocationRecord.Next();
            ShowBannerWithTitleCallbacks[completionHandlerCall] = new ExecutionContext(completionHandler);
            
            GKNotificationBanner_showBannerWithTitle_message_completionHandler(
                title,
                message,
                completionHandlerCall.id, ShowBannerWithTitleCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        /// <summary>
        /// </summary>
        /// <param name="title"></param><param name="message"></param><param name="duration"></param><param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void ShowBannerWithTitleAndMessageDuration(
            string title, 
            string message, 
            double duration, 
            Action completionHandler)
        {
            var completionHandlerCall = InvocationRecord.Next();
            ShowBannerWithTitleCallbacks[completionHandlerCall] = new ExecutionContext(completionHandler);
            
            GKNotificationBanner_showBannerWithTitle_message_duration_completionHandler(
                title,
                message,
                duration,
                completionHandlerCall.id, ShowBannerWithTitleCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext> ShowBannerWithTitleCallbacks = new Dictionary<InvocationRecord,ExecutionContext>();

        [MonoPInvokeCallback(typeof(VoidDelegate))]
        private static void ShowBannerWithTitleCallback(
            ulong invocationId
            )
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = ShowBannerWithTitleCallbacks[invocation];
            ShowBannerWithTitleCallbacks.Remove(invocation);
            
            executionContext.Invoke();
        }

        

        
        
        


        
        
        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKNotificationBanner_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKNotificationBanner Dispose");
                GKNotificationBanner_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKNotificationBanner()
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
