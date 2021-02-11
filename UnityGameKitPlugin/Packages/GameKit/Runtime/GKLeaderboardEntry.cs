//
//  GKLeaderboardEntry.cs
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
    public class GKLeaderboardEntry : UnmanagedObject, IDisposable
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
        private static extern ulong GKLeaderboardEntry_GetPropContext(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern double GKLeaderboardEntry_GetPropDate(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern IntPtr GKLeaderboardEntry_GetPropFormattedScore(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern IntPtr GKLeaderboardEntry_GetPropPlayer(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern long GKLeaderboardEntry_GetPropRank(HandleRef ptr);

        
        [DllImport(dll)]
        private static extern long GKLeaderboardEntry_GetPropScore(HandleRef ptr);

        

        #endregion

        internal GKLeaderboardEntry(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Context</value>
        public ulong Context
        {
            get
            {
                ulong context = GKLeaderboardEntry_GetPropContext(Handle);
                return context;
            }
        }

        
        /// <value>Date</value>
        public DateTime Date
        {
            get
            {
                double date = GKLeaderboardEntry_GetPropDate(Handle);
                return new DateTime(1970, 1, 1, 0, 0, 0,DateTimeKind.Utc).AddSeconds(date);;
            }
        }

        
        /// <value>FormattedScore</value>
        public string FormattedScore
        {
            get
            {
                IntPtr formattedScore = GKLeaderboardEntry_GetPropFormattedScore(Handle);
                return Marshal.PtrToStringAuto(formattedScore);
            }
        }

        
        /// <value>Player</value>
        public GKPlayer Player
        {
            get
            {
                IntPtr player = GKLeaderboardEntry_GetPropPlayer(Handle);
                return player == IntPtr.Zero ? null : new GKPlayer(player);
            }
        }

        
        /// <value>Rank</value>
        public long Rank
        {
            get
            {
                long rank = GKLeaderboardEntry_GetPropRank(Handle);
                return rank;
            }
        }

        
        /// <value>Score</value>
        public long Score
        {
            get
            {
                long score = GKLeaderboardEntry_GetPropScore(Handle);
                return score;
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
        private static extern void GKLeaderboardEntry_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKLeaderboardEntry Dispose");
                GKLeaderboardEntry_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKLeaderboardEntry()
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
