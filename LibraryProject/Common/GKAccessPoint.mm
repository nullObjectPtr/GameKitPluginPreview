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
#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void GKAccessPoint_triggerAccessPointWithHandler(
    void* ptr,
    unsigned long invocationId, GKAccessPointCallback handler,
    void** exception
    )
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
#endif


#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void GKAccessPoint_triggerAccessPointWithState_handler(
    void* ptr,
    long state,
    unsigned long invocationId, GKAccessPointCallback handler,
    void** exception
    )
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
#endif


//VoidMethods
//Properties
#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void* GKAccessPoint_GetPropShared()
{
	GKAccessPoint* val = [GKAccessPoint shared];
	return (__bridge_retained void*) val;
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
long GKAccessPoint_GetPropLocation(void* ptr)
{
	GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
	GKAccessPointLocation val = [iGKAccessPoint location];
	return val;
}

void GKAccessPoint_SetPropLocation(void* ptr, long location, void** exceptionPtr)
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
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
bool GKAccessPoint_GetPropActive(void* ptr)
{
	GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
	BOOL val = [iGKAccessPoint isActive];
	return val;
}

void GKAccessPoint_SetPropActive(void* ptr, bool active, void** exceptionPtr)
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
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
bool GKAccessPoint_GetPropIsPresentingGameCenter(void* ptr)
{
	GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
	BOOL val = [iGKAccessPoint isPresentingGameCenter];
	return val;
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
bool GKAccessPoint_GetPropVisible(void* ptr)
{
	GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
	BOOL val = [iGKAccessPoint isVisible];
	return val;
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
bool GKAccessPoint_GetPropShowHighlights(void* ptr)
{
	GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
	BOOL val = [iGKAccessPoint showHighlights];
	return val;
}

void GKAccessPoint_SetPropShowHighlights(void* ptr, bool showHighlights, void** exceptionPtr)
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
#endif

#if (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
bool GKAccessPoint_GetPropFocused(void* ptr)
{
	GKAccessPoint* iGKAccessPoint = (__bridge GKAccessPoint*) ptr;
	BOOL val = [iGKAccessPoint isFocused];
	return val;
}

void GKAccessPoint_SetPropFocused(void* ptr, bool focused, void** exceptionPtr)
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



void GKAccessPoint_Dispose(void* ptr)
{
    GKAccessPoint* val = (__bridge GKAccessPoint*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKAccessPoint");
}

}
