//
//  GKLeaderboardScore.cs
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
    public class GKLeaderboardScore : UnmanagedObject, IDisposable
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
        private static extern ulong GKLeaderboardScore_GetPropContext(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKLeaderboardScore_SetPropContext(HandleRef ptr, ulong context, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern IntPtr GKLeaderboardScore_GetPropLeaderboardID(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKLeaderboardScore_SetPropLeaderboardID(HandleRef ptr, string leaderboardID, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern IntPtr GKLeaderboardScore_GetPropPlayer(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKLeaderboardScore_SetPropPlayer(HandleRef ptr, IntPtr player, out IntPtr exceptionPtr);

        
        [DllImport(dll)]
        private static extern long GKLeaderboardScore_GetPropValue(HandleRef ptr);
        
        [DllImport(dll)]
        private static extern void GKLeaderboardScore_SetPropValue(HandleRef ptr, long value, out IntPtr exceptionPtr);

        

        #endregion

        internal GKLeaderboardScore(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Context</value>
        public ulong Context
        {
            get
            {
                ulong context = GKLeaderboardScore_GetPropContext(Handle);
                return context;
            }
            set
            {
                GKLeaderboardScore_SetPropContext(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>LeaderboardID</value>
        public string LeaderboardID
        {
            get
            {
                IntPtr leaderboardID = GKLeaderboardScore_GetPropLeaderboardID(Handle);
                return Marshal.PtrToStringAuto(leaderboardID);
            }
            set
            {
                GKLeaderboardScore_SetPropLeaderboardID(Handle, value, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>Player</value>
        public GKPlayer Player
        {
            get
            {
                IntPtr player = GKLeaderboardScore_GetPropPlayer(Handle);
                return player == IntPtr.Zero ? null : new GKPlayer(player);
            }
            set
            {
                GKLeaderboardScore_SetPropPlayer(Handle, value != null ? HandleRef.ToIntPtr(value.Handle) : IntPtr.Zero, out IntPtr exceptionPtr);
            }
        }

        
        /// <value>Value</value>
        public long Value
        {
            get
            {
                long value = GKLeaderboardScore_GetPropValue(Handle);
                return value;
            }
            set
            {
                GKLeaderboardScore_SetPropValue(Handle, value, out IntPtr exceptionPtr);
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
        private static extern void GKLeaderboardScore_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKLeaderboardScore Dispose");
                GKLeaderboardScore_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKLeaderboardScore()
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
