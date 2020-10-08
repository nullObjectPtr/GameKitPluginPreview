//
//  GKAchievement.cs
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
    public class GKAchievement : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievement_initWithIdentifier(
            string identifier, 
            out IntPtr exceptionPtr
            );
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievement_initWithIdentifier_player(
            string identifier, 
            IntPtr player, 
            out IntPtr exceptionPtr
            );
        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAchievement_GetPropCompleted(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAchievement_GetPropShowsCompletionBanner(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAchievement_SetPropShowsCompletionBanner(HandleRef ptr, bool showsCompletionBanner, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievement_GetPropIdentifier(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAchievement_SetPropIdentifier(HandleRef ptr, string identifier, out IntPtr exceptionPtr);

        

        #endregion

        internal GKAchievement(IntPtr ptr) : base(ptr) {}
        
        
        
        
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

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
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
