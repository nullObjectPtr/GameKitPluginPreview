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

        

        #endregion

        internal GKTurnBasedExchange(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
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
