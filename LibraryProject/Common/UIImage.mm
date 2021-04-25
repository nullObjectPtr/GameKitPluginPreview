//
//  UIImage.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "UIImage.h"
#import "Converters.h"
#if TARGET_OS_IOS || TARGET_OS_TV
#import <UIKit/UIKit.h>
#else
#import <AppKit/AppKit.h>
#endif


extern "C" {

//ClassMethods
void* UIImage_systemImageNamed(
	const char* name, 
	void** exception
    )
{
	@try
    {
#if TARGET_OS_IOS || TARGET_OS_TV
	    UIImage* val = [UIImage systemImageNamed:[NSString stringWithUTF8String:name]];
#else
        NSImage* val = [NSImage imageNamed:[NSString stringWithUTF8String:name]];
#endif
		return (__bridge_retained void*) val;
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	return nil;
}

void UIImage_PNGRepresentation(
    const void* image,
    const void** buffer,
    long* const bufferLen,
	void** exception
    )
{
    @try
    {
#if TARGET_OS_IOS || TARGET_OS_TV
        UIImage* uiImage = (__bridge UIImage*) image;
        NSData* val = UIImagePNGRepresentation(uiImage);
#else
        NSImage* nsImage = (__bridge NSImage*)image;
        
        // rasterize this
        CGImageRef cgRef = [nsImage CGImageForProposedRect:nil context:nil hints:nil];
        NSBitmapImageRep* bitmapRep = [[NSBitmapImageRep alloc] initWithCGImage:cgRef];
        [bitmapRep setSize:[nsImage size]];
        NSData* val = [bitmapRep representationUsingType:NSBitmapImageFileTypePNG properties:@{NSImageCompressionFactor:@1.0}];
#endif
        
        *buffer = [val bytes];
        *bufferLen = [val length];
    }
    @catch(NSException* ex)
    {
        *exception = (__bridge_retained void*) ex;
    }
}



void UIImage_JPEGRepresentation(
	void* image,
    float compressionQuality,
    const void** buffer,
    long* const bufferLen,
	void** exception
    )
{
	@try
    {
#if TARGET_OS_IOS || TARGET_OS_TV
	    NSData* val = UIImageJPEGRepresentation((__bridge UIImage*) image, compressionQuality);
#else
        NSImage* nsImage = (__bridge NSImage*)image;
        CGImageRef cgRef = [nsImage CGImageForProposedRect:nil context:nil hints:nil];
        NSBitmapImageRep* bitmapRep = [[NSBitmapImageRep alloc] initWithCGImage:cgRef];
        [bitmapRep setSize:[nsImage size]];
        NSData* val = [bitmapRep representationUsingType:NSBitmapImageFileTypeJPEG properties:@{NSImageCompressionFactor:@1.0}];
#endif
        *buffer = [val bytes];
        *bufferLen = [val length];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
}



//InitMethods
//InstanceMethods
//VoidMethods
//Properties


void UIImage_Dispose(void* ptr)
{
#if TARGET_OS_IOS || TARGET_OS_TV
    UIImage* val = (__bridge UIImage*) ptr;
#else
    NSImage* val = (__bridge NSImage*) ptr;
#endif
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...UIImage");
}

}
