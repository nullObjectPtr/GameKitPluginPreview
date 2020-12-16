//
//  UIViewController.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "UIViewController.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
void UIViewController_present(
    void* ptr,
    void** exception
    )
{
	@try 
	{
#if TARGET_OS_OSX
        NSViewController* val = (__bridge NSViewController*) ptr;
        [[NSApplication sharedApplication].keyWindow.windowController.contentViewController presentViewControllerAsSheet:val];
#else
        UIViewController* val = (__bridge UIViewController*) ptr;
		[[[UIApplication sharedApplication] keyWindow].rootViewController presentViewController:val animated:YES completion:nil];
#endif
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
}


void UIViewController_dismiss(
    void* ptr,
    void** exception
    )
{
	@try 
	{
#if TARGET_OS_OSX
        NSViewController* val = (__bridge NSViewController*) ptr;
        [[NSApplication sharedApplication].keyWindow.windowController.contentViewController dismissViewController:val];
#else
        [[[UIApplication sharedApplication] keyWindow].rootViewController dismissViewControllerAnimated:YES completion:nil];
#endif
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
}


//VoidMethods
//Properties


void UIViewController_Dispose(void* ptr)
{
#if TARGET_OS_OSX
    NSViewController* val = (__bridge NSViewController*) ptr;
#else
    UIViewController* val = (__bridge UIViewController*) ptr;
#endif
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...UIViewController");
}

}
