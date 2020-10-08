//
//  GKAchievementDescription.cs
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
    public class GKAchievementDescription : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        

        

        

        

        // Properties
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievementDescription_GetPropIdentifier(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievementDescription_GetPropTitle(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievementDescription_GetPropUnachievedDescription(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievementDescription_GetPropAchievedDescription(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern long GKAchievementDescription_GetPropMaximumPoints(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAchievementDescription_GetPropHidden(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern bool GKAchievementDescription_GetPropReplayable(HandleRef ptr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievementDescription_GetPropGroupIdentifier(HandleRef ptr);

        

        #endregion

        internal GKAchievementDescription(IntPtr ptr) : base(ptr) {}
        
        
        
        


        
        
        
        /// <value>Identifier</value>
        public string Identifier
        {
            get 
            { 
                IntPtr identifier = GKAchievementDescription_GetPropIdentifier(Handle);
                return Marshal.PtrToStringAuto(identifier);
            }
        }

        
        /// <value>Title</value>
        public string Title
        {
            get 
            { 
                IntPtr title = GKAchievementDescription_GetPropTitle(Handle);
                return Marshal.PtrToStringAuto(title);
            }
        }

        
        /// <value>UnachievedDescription</value>
        public string UnachievedDescription
        {
            get 
            { 
                IntPtr unachievedDescription = GKAchievementDescription_GetPropUnachievedDescription(Handle);
                return Marshal.PtrToStringAuto(unachievedDescription);
            }
        }

        
        /// <value>AchievedDescription</value>
        public string AchievedDescription
        {
            get 
            { 
                IntPtr achievedDescription = GKAchievementDescription_GetPropAchievedDescription(Handle);
                return Marshal.PtrToStringAuto(achievedDescription);
            }
        }

        
        /// <value>MaximumPoints</value>
        public long MaximumPoints
        {
            get 
            { 
                long maximumPoints = GKAchievementDescription_GetPropMaximumPoints(Handle);
                return maximumPoints;
            }
        }

        
        /// <value>Hidden</value>
        public bool Hidden
        {
            get 
            { 
                bool hidden = GKAchievementDescription_GetPropHidden(Handle);
                return hidden;
            }
        }

        
        /// <value>Replayable</value>
        public bool Replayable
        {
            get 
            { 
                bool replayable = GKAchievementDescription_GetPropReplayable(Handle);
                return replayable;
            }
        }

        
        /// <value>GroupIdentifier</value>
        public string GroupIdentifier
        {
            get 
            { 
                IntPtr groupIdentifier = GKAchievementDescription_GetPropGroupIdentifier(Handle);
                return Marshal.PtrToStringAuto(groupIdentifier);
            }
        }

        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAchievementDescription_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("GKAchievementDescription Dispose");
                GKAchievementDescription_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~GKAchievementDescription()
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
