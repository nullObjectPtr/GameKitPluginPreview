//
//  GKVoiceChat.cs
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
    public class GKVoiceChat : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKVoiceChat_isVoIPAllowed(
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKVoiceChat_start(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKVoiceChat_stop(
            HandleRef ptr, 
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKVoiceChat_setPlayer_muted(
            HandleRef ptr, 
            IntPtr player,
            bool isMuted,
            out IntPtr exceptionPtr);

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKVoiceChat_GetPropActive(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKVoiceChat_SetPropActive(HandleRef ptr, bool active, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKVoiceChat_GetPropName(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKVoiceChat_GetPropPlayers(HandleRef ptr, ref IntPtr buffer, ref long count);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern float GKVoiceChat_GetPropVolume(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKVoiceChat_SetPropVolume(HandleRef ptr, float volume, out IntPtr exceptionPtr);

        

        #endregion

        internal GKVoiceChat(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>val</returns>
        public static bool IsVoIPAllowed()
        { 
            var val = GKVoiceChat_isVoIPAllowed(
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val;
        }
        

        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>void</returns>
        public void Start()
        { 
            GKVoiceChat_start(
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
        /// <returns>void</returns>
        public void Stop()
        { 
            GKVoiceChat_stop(
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
        /// <param name="player"></param><param name="isMuted"></param>
        /// <returns>void</returns>
        public void SetPlayer(
            GKPlayer player, 
            bool isMuted)
        { 
            
            
            GKVoiceChat_setPlayer_muted(
                Handle,
                player != null ? HandleRef.ToIntPtr(player.Handle) : IntPtr.Zero,
                isMuted,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        

        
        
        
        /// <value>Active</value>
        public bool Active
        {
            get
            {
                bool active = GKVoiceChat_GetPropActive(Handle);
                return active;
            }
            set
            {
                GKVoiceChat_SetPropActive(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>Name</value>
        public string Name
        {
            get
            {
                IntPtr name = GKVoiceChat_GetPropName(Handle);
                return Marshal.PtrToStringAuto(name);
            }
        }

        
        /// <value>Players</value>
        public GKPlayer[] Players
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKVoiceChat_GetPropPlayers(Handle, ref bufferPtr, ref bufferLen);

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

        
        /// <value>Volume</value>
        public float Volume
        {
            get
            {
                float volume = GKVoiceChat_GetPropVolume(Handle);
                return volume;
            }
            set
            {
                GKVoiceChat_SetPropVolume(Handle, value, out IntPtr exceptionPtr);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKVoiceChat_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKVoiceChat Dispose");
                GKVoiceChat_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKVoiceChat()
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
