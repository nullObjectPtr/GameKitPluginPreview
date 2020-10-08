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
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern IntPtr GKAccessPoint_GetPropShared();

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern GKAccessPointLocation GKAccessPoint_GetPropLocation(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern void GKAccessPoint_SetPropLocation(HandleRef ptr, long location, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropActive(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern void GKAccessPoint_SetPropActive(HandleRef ptr, bool active, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropIsPresentingGameCenter(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropVisible(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern bool GKAccessPoint_GetPropShowHighlights(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern void GKAccessPoint_SetPropShowHighlights(HandleRef ptr, bool showHighlights, out IntPtr exceptionPtr);

        

        #endregion

        internal GKAccessPoint(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
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

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHCloudKitMacOS")]
        #endif
        private static extern void GKAccessPoint_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                
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
