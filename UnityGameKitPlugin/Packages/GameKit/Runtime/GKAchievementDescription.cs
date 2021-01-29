//
//  GKAchievementDescription.cs
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
    public class GKAchievementDescription : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAchievementDescription_loadAchievementDescriptionsWithCompletionHandler(
            ulong invocationId, GKAchievementDescriptionsDelegate completionHandler,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievementDescription_incompleteAchievementImage(
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr GKAchievementDescription_placeholderCompletedAchievementImage(
            out IntPtr exceptionPtr);

        

        

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void GKAchievementDescription_loadImageWithCompletionHandler(
            HandleRef ptr, 
            ulong invocationId, ImageDelegate completionHandler,
            out IntPtr exceptionPtr);

        

        

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
        
        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public static void LoadAchievementDescriptionsWithCompletionHandler(
            Action<GKAchievementDescription[],NSError> completionHandler)
        { 
            var completionHandlerCall = InvocationRecord.Next();
            LoadAchievementDescriptionsWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<GKAchievementDescription[],NSError>(completionHandler);
            
            GKAchievementDescription_loadAchievementDescriptionsWithCompletionHandler(
                completionHandlerCall.id, LoadAchievementDescriptionsWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<GKAchievementDescription[],NSError>> LoadAchievementDescriptionsWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<GKAchievementDescription[],NSError>>();

        [MonoPInvokeCallback(typeof(GKAchievementDescriptionsDelegate))]
        private static void LoadAchievementDescriptionsWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr[] descriptions,
		    long descriptionsCount,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadAchievementDescriptionsWithCompletionHandlerCallbacks[invocation];
            LoadAchievementDescriptionsWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    descriptions == null ? null : descriptions.Select(x => new GKAchievementDescription(x)).ToArray(),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>val</returns>
        public static UIImage IncompleteAchievementImage()
        { 
            var val = GKAchievementDescription_incompleteAchievementImage(
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val == IntPtr.Zero ? null : new UIImage(val);
        }
        

        
        /// <summary>
        /// </summary>
        /// 
        /// <returns>val</returns>
        public static UIImage PlaceholderCompletedAchievementImage()
        { 
            var val = GKAchievementDescription_placeholderCompletedAchievementImage(
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return val == IntPtr.Zero ? null : new UIImage(val);
        }
        

        
        
        


        
        /// <summary>
        /// </summary>
        /// <param name="completionHandler"></param>
        /// <returns>void</returns>
        public void LoadImageWithCompletionHandler(
            Action<UIImage,NSError> completionHandler)
        { 
            var completionHandlerCall = new InvocationRecord(Handle);
            LoadImageWithCompletionHandlerCallbacks[completionHandlerCall] = new ExecutionContext<UIImage,NSError>(completionHandler);
            
            GKAchievementDescription_loadImageWithCompletionHandler(
                Handle,
                completionHandlerCall.id, LoadImageWithCompletionHandlerCallback,
                out var exceptionPtr);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
        }
        
        private static readonly Dictionary<InvocationRecord,ExecutionContext<UIImage,NSError>> LoadImageWithCompletionHandlerCallbacks = new Dictionary<InvocationRecord,ExecutionContext<UIImage,NSError>>();

        [MonoPInvokeCallback(typeof(ImageDelegate))]
        private static void LoadImageWithCompletionHandlerCallback(
            ulong invocationId,
            IntPtr image,
            IntPtr error)
        {
            var invocation = new InvocationRecord(invocationId);
            var executionContext = LoadImageWithCompletionHandlerCallbacks[invocation];
            LoadImageWithCompletionHandlerCallbacks.Remove(invocation);
            
            executionContext.Invoke(
                    image == IntPtr.Zero ? null : new UIImage(image),
                    error == IntPtr.Zero ? null : new NSError(error));
        }

        

        
        
        
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
