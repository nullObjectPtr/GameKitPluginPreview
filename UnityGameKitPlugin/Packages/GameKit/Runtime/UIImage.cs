//
//  UIImage.cs
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
    public class UIImage : UnmanagedObject, IDisposable
    {
        #region dll

        // Class Methods
        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern IntPtr UIImage_systemImageNamed(
            string name,
            out IntPtr exceptionPtr);

        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void UIImage_PNGRepresentation(
            IntPtr image,
            out IntPtr buffer,
            out long bufferLen,
            out IntPtr exceptionPtr);

        
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void UIImage_JPEGRepresentation(
            IntPtr image,
            float compressionQuality,
            out IntPtr buffer,
            out long bufferLen,
            out IntPtr exceptionPtr);
        
        // Properties
        

        #endregion

        internal UIImage(IntPtr ptr) : base(ptr) {}
        
        
        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>val</returns>
        public static UIImage SystemImageNamed(
            string name)
        { 
            
            var val = UIImage_systemImageNamed(
                name,
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
        /// <param name="image"></param>
        /// <returns>val</returns>
        public static byte[] PNGRepresentation(
            UIImage image)
        { 
            
            UIImage_PNGRepresentation(
                image != null ? HandleRef.ToIntPtr(image.Handle) : IntPtr.Zero,
                out var buffer,
                out var bufferLen,
                out var exceptionPtr);

            var bytes = new byte[bufferLen];
            Marshal.Copy(buffer, bytes, 0, (int)bufferLen);
            
            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return bytes;
        }
        

        
        /// <summary>
        /// </summary>
        /// <param name="image"></param>
        /// <returns>val</returns>
        public static byte[] JPEGRepresentation(
            UIImage image,
            float compressionQuality)
        { 
            UIImage_JPEGRepresentation(
                image != null ? HandleRef.ToIntPtr(image.Handle) : IntPtr.Zero,
                compressionQuality,
                out var buffer,
                out var bufferLen,
                out var exceptionPtr);

            var bytes = new byte[bufferLen];
            Marshal.Copy(buffer, bytes, 0, (int)bufferLen);

            if(exceptionPtr != IntPtr.Zero)
            {
                var nativeException = new NSException(exceptionPtr);
                throw new GameKitException(nativeException, nativeException.Reason);
            }
            
            return bytes;
        }
        

        
        
        


        
        
        

        

        
        #region IDisposable Support
        #if UNITY_IPHONE || UNITY_TVOS
        [DllImport("__Internal")]
        #else
        [DllImport("HHGameKitMacOS")]
        #endif
        private static extern void UIImage_Dispose(HandleRef handle);
            
        private bool disposedValue = false; // To detect redundant calls
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                //Debug.Log("UIImage Dispose");
                UIImage_Dispose(Handle);
                disposedValue = true;
            }
        }

        ~UIImage()
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
