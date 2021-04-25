//
//  GKAccessPoint.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKAccessPoint.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods

void GKAccessPoint_triggerAccessPointWithHandler(
    void* ptr,
    unsigned long invocationId, VoidCallback handler,
    void** exception
    )
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        @try
        {
            GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
            [iGKAccessPoint triggerAccessPointWithHandler:^()
            {
                
                handler(invocationId);
                
            }
    ];
        }
        @catch(NSException* ex)
        {
            *exception = (__bridge_retained void*) ex;
        }
    }
}

void GKAccessPoint_triggerAccessPointWithState_handler(
    void* ptr,
    long state,
    unsigned long invocationId, VoidCallback handler,
    void** exception
    )
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        @try
        {
            GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
            [iGKAccessPoint triggerAccessPointWithState:(GKGameCenterViewControllerState)state handler:^()
            {
                
                handler(invocationId);
                
            }
    ];
        }
        @catch(NSException* ex)
        {
            *exception = (__bridge_retained void*) ex;
        }
    }
}


void* GKAccessPoint_GetPropShared()
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        GKAccessPoint* val = [GKAccessPoint shared];
        return (__bridge_retained void*) val;
    }
    else
    {
        return nil;
    }
}

long GKAccessPoint_GetPropLocation(void* ptr)
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
        GKAccessPointLocation val = [iGKAccessPoint location];
        return val;
    }
    else
    {
        return 0;
    }
}

void GKAccessPoint_SetPropLocation(void* ptr, long location, void** exceptionPtr)
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        @try
        {
            GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
            [iGKAccessPoint setLocation:(GKAccessPointLocation)location];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}

bool GKAccessPoint_GetPropActive(void* ptr)
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
        BOOL val = [iGKAccessPoint isActive];
        return val;
    }
    else
    {
        return false;
    }
}

void GKAccessPoint_SetPropActive(void* ptr, bool active, void** exceptionPtr)
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        @try
        {
            GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
            [iGKAccessPoint setActive:active];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}

bool GKAccessPoint_GetPropIsPresentingGameCenter(void* ptr)
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
        BOOL val = [iGKAccessPoint isPresentingGameCenter];
        return val;
    }
    else
    {
        return false;
    }
}

bool GKAccessPoint_GetPropVisible(void* ptr)
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
        BOOL val = [iGKAccessPoint isVisible];
        return val;
    }
    else
    {
        return false;
    }
}

bool GKAccessPoint_GetPropShowHighlights(void* ptr)
{
    if(@available(macOS 10.16, iOS 14.0, tvOS 14.0, *))
    {
        GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
        BOOL val = [iGKAccessPoint showHighlights];
        return val;
    }
    else
    {
        return false;
    }
}

void GKAccessPoint_SetPropShowHighlights(void* ptr, bool showHighlights, void** exceptionPtr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        @try
        {
            GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
            [iGKAccessPoint setShowHighlights:showHighlights];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}


bool GKAccessPoint_GetPropFocused(void* ptr)
{
    if(@available(tvOS 14.0, *))
    {
#if (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
        GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
        BOOL val = [iGKAccessPoint isFocused];
        return val;
#endif
    }

    return false;
}

void GKAccessPoint_SetPropFocused(void* ptr, bool focused, void** exceptionPtr)
{
#if (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
    if(@available(tvOS 14.0, *))
    {
        @try
        {
            GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
            [iGKAccessPoint setFocused:focused];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
#endif
}

CGRect GKAccessPoint_GetPropFrameInScreenCoordinates(void* ptr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
        CGRect val = [iGKAccessPoint frameInScreenCoordinates];
        //NSLog(@"x:%f y:%f w:%f h:%f", val.origin.x, val.origin.y, val.size.width, val.size.height);
        return val;
    }
    else
    {
        return CGRectZero;
    }
}



void GKAccessPoint_Dispose(void* ptr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        GKAccessPoint* val = (__bridge GKAccessPoint*) ptr;
        if(val != nil)
        {
            CFRelease(ptr);
        }
        //NSLog(@"Dispose...GKAccessPoint");
    }
}

}
