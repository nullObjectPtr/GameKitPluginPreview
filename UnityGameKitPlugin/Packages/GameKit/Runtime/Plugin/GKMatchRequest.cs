//
//  GKMatchRequest.cs
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
    public class GKMatchRequest : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKMatchRequest_maxPlayersAllowedForMatchOfType(
            long matchType,
            out IntPtr exceptionPtr);

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatchRequest_init(
            out IntPtr exceptionPtr
            );
        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKMatchRequest_GetPropMaxPlayers(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_SetPropMaxPlayers(HandleRef ptr, ulong maxPlayers, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKMatchRequest_GetPropMinPlayers(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_SetPropMinPlayers(HandleRef ptr, ulong minPlayers, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKMatchRequest_GetPropDefaultNumberOfPlayers(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_SetPropDefaultNumberOfPlayers(HandleRef ptr, ulong defaultNumberOfPlayers, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKMatchRequest_GetPropInviteMessage(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_SetPropInviteMessage(HandleRef ptr, string inviteMessage, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern ulong GKMatchRequest_GetPropPlayerGroup(HandleRef ptr);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_SetPropPlayerGroup(HandleRef ptr, ulong playerGroup, out IntPtr exceptionPtr);

        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_SetPropRecipientResponseHandler(HandleRef ptr, RecipientResponseHandler recipientResponseHandler, out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_GetPropRecipients(HandleRef ptr, ref IntPtr buffer, ref long count);
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_SetPropRecipients(HandleRef ptr, IntPtr[] recipients,
			int recipientsCount, out IntPtr exceptionPtr);

        

        #endregion

        internal GKMatchRequest(IntPtr ptr) : base(ptr) {}
        
        
        /// <summary>
        /// </summary>
        /// <param name="matchType"></param>
        /// <returns>val</returns>
        public static ulong MaxPlayersAllowedForMatchOfType(
            GKMatchType matchType)
        { 
            
            var val = GKMatchRequest_maxPlayersAllowedForMatchOfType(
                (long) matchType, 
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val;
        }
        

        
        
        
        public GKMatchRequest(
            )
        {
            
            IntPtr ptr = GKMatchRequest_init(
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
        }
        
        


        
        
        
        /// <value>MaxPlayers</value>
        public ulong MaxPlayers
        {
            get 
            { 
                ulong maxPlayers = GKMatchRequest_GetPropMaxPlayers(Handle);
                return maxPlayers;
            }
            set
            {
                GKMatchRequest_SetPropMaxPlayers(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>MinPlayers</value>
        public ulong MinPlayers
        {
            get 
            { 
                ulong minPlayers = GKMatchRequest_GetPropMinPlayers(Handle);
                return minPlayers;
            }
            set
            {
                GKMatchRequest_SetPropMinPlayers(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>DefaultNumberOfPlayers</value>
        public ulong DefaultNumberOfPlayers
        {
            get 
            { 
                ulong defaultNumberOfPlayers = GKMatchRequest_GetPropDefaultNumberOfPlayers(Handle);
                return defaultNumberOfPlayers;
            }
            set
            {
                GKMatchRequest_SetPropDefaultNumberOfPlayers(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>InviteMessage</value>
        public string InviteMessage
        {
            get 
            { 
                IntPtr inviteMessage = GKMatchRequest_GetPropInviteMessage(Handle);
                return Marshal.PtrToStringAuto(inviteMessage);
            }
            set
            {
                GKMatchRequest_SetPropInviteMessage(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>PlayerGroup</value>
        public ulong PlayerGroup
        {
            get 
            { 
                ulong playerGroup = GKMatchRequest_GetPropPlayerGroup(Handle);
                return playerGroup;
            }
            set
            {
                GKMatchRequest_SetPropPlayerGroup(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>RecipientResponseHandler</value>
        public Action<GKPlayer,GKInviteRecipientResponse> RecipientResponseHandler
        {
            get 
            {
                RecipientResponseHandlerCallbacks.TryGetValue(
                    HandleRef.ToIntPtr(Handle), 
                    out ExecutionContext<GKPlayer,GKInviteRecipientResponse> value);
                return value.Callback;
            }    
            set 
            {
                IntPtr myPtr = HandleRef.ToIntPtr(Handle);
                if(value == null)
                {
                    RecipientResponseHandlerCallbacks.Remove(myPtr);
                }
                else
                {
                    RecipientResponseHandlerCallbacks[myPtr] = new ExecutionContext<GKPlayer,GKInviteRecipientResponse>(value);
                }
                GKMatchRequest_SetPropRecipientResponseHandler(Handle, RecipientResponseHandlerCallback, out IntPtr exceptionPtr);

                if(exceptionPtr != IntPtr.Zero)
                {
                    var nativeException = new NSException(exceptionPtr);
                    throw new GameKitException(nativeException, nativeException.Reason);
                }
            }
        }

        private static readonly Dictionary<IntPtr,ExecutionContext<GKPlayer,GKInviteRecipientResponse>> RecipientResponseHandlerCallbacks = new Dictionary<IntPtr,ExecutionContext<GKPlayer,GKInviteRecipientResponse>>();

        [MonoPInvokeCallback(typeof(RecipientResponseHandler))]
        private static void RecipientResponseHandlerCallback(IntPtr thisPtr, IntPtr player, GKInviteRecipientResponse response)
        {
            if(RecipientResponseHandlerCallbacks.TryGetValue(thisPtr, out ExecutionContext<GKPlayer,GKInviteRecipientResponse> callback))
            {
                callback.Invoke(
                        player == IntPtr.Zero ? null : new GKPlayer(player),
                        (GKInviteRecipientResponse) response);
            }
        }

        
        /// <value>Recipients</value>
        public GKPlayer[] Recipients
        {
            get 
            { 
                IntPtr bufferPtr = IntPtr.Zero;
                long bufferLen = 0;

                GKMatchRequest_GetPropRecipients(Handle, ref bufferPtr, ref bufferLen);

                var recipients = new GKPlayer[bufferLen];

                for (int i = 0; i < bufferLen; i++)
                {
                    IntPtr ptr2 = Marshal.ReadIntPtr(bufferPtr + (i * IntPtr.Size));
                    recipients[i] = ptr2 == IntPtr.Zero ? null : new GKPlayer(ptr2);
                }

                Marshal.FreeHGlobal(bufferPtr);

                return recipients;
            }
            set
            {
                GKMatchRequest_SetPropRecipients(Handle, value == null ? null : value.Select(x => HandleRef.ToIntPtr(x.Handle)).ToArray(),
				value == null ? 0 : value.Length, out IntPtr exceptionPtr);
                
                if(exceptionPtr != IntPtr.Zero)
                {
                    var nativeException = new NSException(exceptionPtr);
                    throw new GameKitException(nativeException, nativeException.Reason);
                }
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKMatchRequest_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKMatchRequest Dispose");
                GKMatchRequest_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKMatchRequest()
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
