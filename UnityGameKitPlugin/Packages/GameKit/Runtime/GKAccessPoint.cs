//
//  GKAccessPoint.cs
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
    public class GKAccessPoint : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAccessPoint_triggerAccessPointWithHandler(
            HandleRef ptr, 
            ulong invocationId, GKAccessPointDelegate handler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAccessPoint_triggerAccessPointWithState_handler(
            HandleRef ptr, 
            long state,
            ulong invocationId, GKAccessPointDelegate handler,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAccessPoint_GetPropShared();

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern GKAccessPointLocation GKAccessPoint_GetPropLocation(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAccessPoint_SetPropLocation(HandleRef ptr, long location, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropActive(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAccessPoint_SetPropActive(HandleRef ptr, bool active, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropIsPresentingGameCenter(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropVisible(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropShowHighlights(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAccessPoint_SetPropShowHighlights(HandleRef ptr, bool showHighlights, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropFocused(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAccessPoint_SetPropFocused(HandleRef ptr, bool focused, out IntPtr exceptionPtr);

        

        #endregion

        internal GKAccessPoint(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="handler"></param>
        /// <returns>void</returns>
        public void TriggerAccessPointWithHandler(
            Action handler)
        { 
            var handlerCall = new InvocationRecord(Handle);
            TriggerAccessPointWithHandlerCallbacks[handlerCall] = new ExecutionContext(handler);
            
            GKAccessPoint_triggerAccessPointWithHandler(
                Handle,
                handlerCall.id, TriggerAccessPointWithHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext> TriggerAccessPointWithHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext>();

        [MonoPInvokeCallback(typeof(GKAccessPointDelegate))]
        private static void TriggerAccessPointWithHandlerCallback(
            ulong invocationId
            )
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = TriggerAccessPointWithHandlerCallbacks[invocation];
            TriggerAccessPointWithHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke();
        }

        

        
        /// <summary>
        /// </summary>
        /// <param name="state"></param><param name="handler"></param>
        /// <returns>void</returns>
        public void TriggerAccessPointWithState(
            GKGameCenterViewControllerState state, 
            Action handler)
        { 
            
            var handlerCall = new InvocationRecord(Handle);
            TriggerAccessPointWithStateCallbacks[handlerCall] = new ExecutionContext(handler);
            
            GKAccessPoint_triggerAccessPointWithState_handler(
                Handle,
                (long) state,
                handlerCall.id, TriggerAccessPointWithStateCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext> TriggerAccessPointWithStateCallbacks = new Dictionary<InvocationRecord,ExecutionContext>();

        [MonoPInvokeCallback(typeof(GKAccessPointDelegate))]
        private static void TriggerAccessPointWithStateCallback(
            ulong invocationId
            )
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = TriggerAccessPointWithStateCallbacks[invocation];
            TriggerAccessPointWithStateCallbacks.Remove(invocation);
            
            executionContext.Invoke();
        }

        

        
        
        
        /// <value>Shared</value>
        public static GKAccessPoint Shared
        {
            get
            {
                IntPtr shared = GKAccessPoint_GetPropShared();
                return shared == IntPtr.Zero ? null : new GKAccessPoint(shared);
            }
        }

        
        /// <value>Location</value>
        public GKAccessPointLocation Location
        {
            get
            {
                GKAccessPointLocation location = GKAccessPoint_GetPropLocation(Handle);
                return (GKAccessPointLocation) location;
            }
            set
            {
                GKAccessPoint_SetPropLocation(Handle, (long) value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>Active</value>
        public bool Active
        {
            get
            {
                bool active = GKAccessPoint_GetPropActive(Handle);
                return active;
            }
            set
            {
                GKAccessPoint_SetPropActive(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>IsPresentingGameCenter</value>
        public bool IsPresentingGameCenter
        {
            get
            {
                bool isPresentingGameCenter = GKAccessPoint_GetPropIsPresentingGameCenter(Handle);
                return isPresentingGameCenter;
            }
        }

        
        /// <value>Visible</value>
        public bool Visible
        {
            get
            {
                bool visible = GKAccessPoint_GetPropVisible(Handle);
                return visible;
            }
        }

        
        /// <value>ShowHighlights</value>
        public bool ShowHighlights
        {
            get
            {
                bool showHighlights = GKAccessPoint_GetPropShowHighlights(Handle);
                return showHighlights;
            }
            set
            {
                GKAccessPoint_SetPropShowHighlights(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>Focused</value>
        public bool Focused
        {
            get
            {
                bool focused = GKAccessPoint_GetPropFocused(Handle);
                return focused;
            }
            set
            {
                GKAccessPoint_SetPropFocused(Handle, value, out IntPtr exceptionPtr);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAccessPoint_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKAccessPoint Dispose");
                GKAccessPoint_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKAccessPoint()
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
