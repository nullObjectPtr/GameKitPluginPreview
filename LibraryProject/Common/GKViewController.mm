//
//  UIViewController.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKViewController.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods

//InstanceMethods
void GKViewController_present(
    void* ptr,
    void** exception
    )
{
    @try
    {
        id vc = (__bridge id) ptr;
        
#if TARGET_OS_OSX
        GKDialogController *sdc = [GKDialogController sharedDialogController];
        sdc.parentWindow = [[NSApplication sharedApplication] keyWindow];
        [sdc presentViewController: vc];
        
#else
        [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:vc animated:YES completion:nil];
#endif
    }
    @catch(NSException* ex)
    {
        *exception = (__bridge_retained void*) ex;
    }
    
}


void GKViewController_dismiss(
    void* ptr,
    void** exception
    )
{
    @try
    {
#if TARGET_OS_OSX
        id vc = (__bridge id) ptr;
        GKDialogController *sdc = [GKDialogController sharedDialogController];
        [sdc dismiss: vc];
#else
        [[[[UIApplication sharedApplication] keyWindow] rootViewController] dismissViewControllerAnimated:YES completion:nil];
#endif
    }
    @catch(NSException* ex)
    {
        *exception = (__bridge_retained void*) ex;
    }
}


//VoidMethods
//Properties


void GKViewController_Dispose(void* ptr)
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
