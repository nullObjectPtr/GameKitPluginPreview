//
//  GKAchievementChallenge.cs
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
    public class GKAchievementChallenge : GKChallenge, IDisposable
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
        private static extern IntPtr GKAchievementChallenge_GetPropAchievement(HandleRef ptr);

        

        #endregion

        internal GKAchievementChallenge(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Achievement</value>
        public GKAchievement Achievement
        {
            get
            {
                IntPtr achievement = GKAchievementChallenge_GetPropAchievement(Handle);
                return achievement == IntPtr.Zero ? null : new GKAchievement(achievement);
            }
        }

        

        

        
        #region IDisposable Support
        [DllImport(dll)]
        private static extern void GKAchievementChallenge_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKAchievementChallenge Dispose");
                GKAchievementChallenge_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKAchievementChallenge()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public new void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        
    }
}
