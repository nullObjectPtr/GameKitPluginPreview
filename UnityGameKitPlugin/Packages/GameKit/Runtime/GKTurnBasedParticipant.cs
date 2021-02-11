//
//  GKTurnBasedParticipant.cs
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
    public class GKTurnBasedParticipant : UnmanagedObject, IDisposable
    {
        #region dll
        
        #if UNITY_IPHONE || UNITY_TVOS
        const string dll = "__Internal";
        #else
        const string dll = "HHGameKitMacOS";
        #endif

        // Class Methods
        

        

        

        

        // Properties
        
        [DllImport(dll)]
        private static extern IntPtr GKTurnBasedParticipant_GetPropPlayer(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern GKTurnBasedParticipantStatus GKTurnBasedParticipant_GetPropStatus(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern double GKTurnBasedParticipant_GetPropLastTurnDate(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern GKTurnBasedMatchOutcome GKTurnBasedParticipant_GetPropMatchOutcome(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKTurnBasedParticipant_SetPropMatchOutcome(HandleRef ptr, long matchOutcome, out IntPtr exceptionPtr);

        

        #endregion

        internal GKTurnBasedParticipant(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Player</value>
        public GKPlayer Player
        {
            get
            {
                IntPtr player = GKTurnBasedParticipant_GetPropPlayer(Handle);
                return player == IntPtr.Zero ? null : new GKPlayer(player);
            }
        }

        
        /// <value>Status</value>
        public GKTurnBasedParticipantStatus Status
        {
            get
            {
                GKTurnBasedParticipantStatus status = GKTurnBasedParticipant_GetPropStatus(Handle);
                return (GKTurnBasedParticipantStatus) status;
            }
        }

        
        /// <value>LastTurnDate</value>
        public DateTime LastTurnDate
        {
            get
            {
                double lastTurnDate = GKTurnBasedParticipant_GetPropLastTurnDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(lastTurnDate);;
            }
        }

        
        /// <value>MatchOutcome</value>
        public GKTurnBasedMatchOutcome MatchOutcome
        {
            get
            {
                GKTurnBasedMatchOutcome matchOutcome = GKTurnBasedParticipant_GetPropMatchOutcome(Handle);
                return (GKTurnBasedMatchOutcome) matchOutcome;
            }
            set
            {
                GKTurnBasedParticipant_SetPropMatchOutcome(Handle, (long) value, out IntPtr exceptionPtr);
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
        private static extern void GKTurnBasedParticipant_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKTurnBasedParticipant Dispose");
                GKTurnBasedParticipant_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKTurnBasedParticipant()
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
