//
//  GKChallenge.cs
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
    public class GKChallenge : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKChallenge_GetPropIssuingPlayer(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKChallenge_GetPropReceivingPlayer(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKChallenge_GetPropMessage(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern GKChallengeState GKChallenge_GetPropState(HandleRef ptr);

        

        #endregion

        internal GKChallenge(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>IssuingPlayer</value>
        public GKPlayer IssuingPlayer
        {
            get 
            { 
                IntPtr issuingPlayer = GKChallenge_GetPropIssuingPlayer(Handle);
                return issuingPlayer == IntPtr.Zero ? null : new GKPlayer(issuingPlayer);
            }
        }

        
        /// <value>ReceivingPlayer</value>
        public GKPlayer ReceivingPlayer
        {
            get 
            { 
                IntPtr receivingPlayer = GKChallenge_GetPropReceivingPlayer(Handle);
                return receivingPlayer == IntPtr.Zero ? null : new GKPlayer(receivingPlayer);
            }
        }

        
        /// <value>Message</value>
        public string Message
        {
            get 
            { 
                IntPtr message = GKChallenge_GetPropMessage(Handle);
                return Marshal.PtrToStringAuto(message);
            }
        }

        
        /// <value>State</value>
        public GKChallengeState State
        {
            get 
            { 
                GKChallengeState state = GKChallenge_GetPropState(Handle);
                return (GKChallengeState) state;
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKChallenge_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKChallenge Dispose");
                GKChallenge_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKChallenge()
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
