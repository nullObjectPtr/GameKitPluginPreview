//
//  MatchDelegate.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace HovelHouse.GameKit
{
    /// <summary>
    /// 
    /// </summary>
    public class MatchDelegate : UnmanagedObject
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr MatchDelegate_init(out IntPtr exceptionPtr);
            
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void MatchDelegate_Dispose(HandleRef handle);
            
        #endregion
        
        private static Dictionary<Int64,MatchDelegate> classInstances =
            new Dictionary<Int64,MatchDelegate>();
    
        internal MatchDelegate(IntPtr ptr) : base(ptr)
        {
            classInstances[ptr.ToInt64()] = this;
        }
        
        public MatchDelegate()
        {
            var ptr = MatchDelegate_init(
                out IntPtr exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }

            Handle = new HandleRef(this,ptr);
            classInstances[ptr.ToInt64()] = this;
        }


        
        [MonoPInvokeCallback(typeof(MatchDelegate_match_player_didChangeConnectionState))]
        public static void match_player_didChangeConnectionState(
            IntPtr ptr,
            IntPtr match, 
            IntPtr player, 
            long state)
        {
            try 
            {
                Debug.Log("match_player_didChangeConnectionState");
                var inst = classInstances[ptr.ToInt64()];
                
                inst.match_player_didChangeConnectionState(
                    match == IntPtr.Zero ? null : new GKMatch(match),
                    player == IntPtr.Zero ? null : new GKPlayer(player),
                    (GKPlayerConnectionState) state);
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(MatchDelegate_match_didFailWithError))]
        public static void match_didFailWithError(
            IntPtr ptr,
            IntPtr match, 
            IntPtr error)
        {
            try 
            {
                Debug.Log("match_didFailWithError");
                var inst = classInstances[ptr.ToInt64()];
                
                inst.match_didFailWithError(
                    match == IntPtr.Zero ? null : new GKMatch(match),
                    error == IntPtr.Zero ? null : new NSError(error));
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
        [MonoPInvokeCallback(typeof(MatchDelegate_match_didReceiveData_fromRemotePlayer))]
        public static void match_didReceiveData_fromRemotePlayer(
            IntPtr ptr,
            IntPtr data,
			int dataLength, 
            IntPtr playerGamePlayerID)
        {
            try 
            {
                var inst = classInstances[ptr.ToInt64()];
                var dataBytes = new byte[dataLength];
				Marshal.Copy(data, dataBytes, 0, (int) dataLength);
                inst.match_didReceiveData_fromRemotePlayer(
                    dataBytes,
                    playerGamePlayerID == IntPtr.Zero ? null : Marshal.PtrToStringAuto(playerGamePlayerID));
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        [MonoPInvokeCallback(typeof(MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer))]
        public static void match_didReceiveData_forRecipient_fromRemotePlayer(
            IntPtr ptr,
            IntPtr data,
            int dataLength, 
            IntPtr recipientGamePlayerID, 
            IntPtr playerGamePlayerID)
        {
            try 
            {
                var inst = classInstances[ptr.ToInt64()];
                var dataBytes = new byte[dataLength];
				Marshal.Copy(data, dataBytes, 0, (int) dataLength);
                inst.match_didReceiveData_forRecipient_fromRemotePlayer(
                    dataBytes,
                    recipientGamePlayerID == IntPtr.Zero ? null : Marshal.PtrToStringAuto(recipientGamePlayerID),
                    playerGamePlayerID == IntPtr.Zero ? null : Marshal.PtrToStringAuto(playerGamePlayerID));
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        [MonoPInvokeCallback(typeof(MatchDelegate_match_shouldReinviteDisconnectedPlayer))]
        public static bool match_shouldReinviteDisconnectedPlayer(
            IntPtr ptr,
            IntPtr match, 
            IntPtr player)
        {
            try 
            {
                Debug.Log("match_shouldReinviteDisconnectedPlayer");
                var inst = classInstances[ptr.ToInt64()];
                
                return inst.match_shouldReinviteDisconnectedPlayer(
                    match == IntPtr.Zero ? null : new GKMatch(match),
                    player == IntPtr.Zero ? null : new GKPlayer(player));
            }
            catch(Exception ex)
            {
                Debug.LogError(ex);
            }

            return false;
        }
        
        
        
        public virtual void match_player_didChangeConnectionState(
            GKMatch match,
            GKPlayer player,
            GKPlayerConnectionState state)
        {
            
        }
        
        public virtual void match_didFailWithError(
            GKMatch match,
            NSError error)
        {
            
        }
        
        public virtual void match_didReceiveData_fromRemotePlayer(
            byte[] data,
            string player)
        {
            
        }
        public virtual void match_didReceiveData_forRecipient_fromRemotePlayer(
            byte[] data,
            string recipientGamePlayerID,
            string playerGamePlayerID)
        {
            
        }
        public virtual bool match_shouldReinviteDisconnectedPlayer(
            GKMatch match,
            GKPlayer player)
        {
            return false;
        }
        

        
        private bool disposedValue = false; // To detect redundant calls
        
        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                MatchDelegate_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~MatchDelegate()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }
        
    }
}
