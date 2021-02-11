//
//  GKTurnBasedExchangeReply.cs
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
    public class GKTurnBasedExchangeReply : UnmanagedObject, IDisposable
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS"
        #endif

        // Class Methods
        

        

        

        

        // Properties
        
        [DllImport(dll)]
        private static extern IntPtr GKTurnBasedExchangeReply_GetPropMessage(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern double GKTurnBasedExchangeReply_GetPropReplyDate(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern IntPtr GKTurnBasedExchangeReply_GetPropRecipient(HandleRef ptr);

        

        #endregion

        internal GKTurnBasedExchangeReply(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Message</value>
        public string Message
        {
            get
            {
                IntPtr message = GKTurnBasedExchangeReply_GetPropMessage(Handle);
                return Marshal.PtrToStringAuto(message);
            }
        }

        
        /// <value>ReplyDate</value>
        public DateTime ReplyDate
        {
            get
            {
                double replyDate = GKTurnBasedExchangeReply_GetPropReplyDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(replyDate);;
            }
        }

        
        /// <value>Recipient</value>
        public GKTurnBasedParticipant Recipient
        {
            get
            {
                IntPtr recipient = GKTurnBasedExchangeReply_GetPropRecipient(Handle);
                return recipient == IntPtr.Zero ? null : new GKTurnBasedParticipant(recipient);
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
        private static extern void GKTurnBasedExchangeReply_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKTurnBasedExchangeReply Dispose");
                GKTurnBasedExchangeReply_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKTurnBasedExchangeReply()
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
