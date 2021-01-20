//
//  GKSavedGame.cs
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
    public class GKSavedGame : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKSavedGame_GetPropDeviceName(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKSavedGame_GetPropName(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern double GKSavedGame_GetPropModificationDate(HandleRef ptr);

        

        #endregion

        internal GKSavedGame(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>DeviceName</value>
        public string DeviceName
        {
            get
            {
                IntPtr deviceName = GKSavedGame_GetPropDeviceName(Handle);
                return Marshal.PtrToStringAuto(deviceName);
            }
        }

        
        /// <value>Name</value>
        public string Name
        {
            get
            {
                IntPtr name = GKSavedGame_GetPropName(Handle);
                return Marshal.PtrToStringAuto(name);
            }
        }

        
        /// <value>ModificationDate</value>
        public DateTime ModificationDate
        {
            get
            {
                double modificationDate = GKSavedGame_GetPropModificationDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(modificationDate);;
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKSavedGame_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKSavedGame Dispose");
                GKSavedGame_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKSavedGame()
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
