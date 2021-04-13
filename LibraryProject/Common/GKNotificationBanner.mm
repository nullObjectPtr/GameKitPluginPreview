//
//  GKNotificationBanner.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKNotificationBanner.h"
#import "Converters.h"


extern "C" {

//ClassMethods
void GKNotificationBanner_showBannerWithTitle_message_completionHandler(
	const char* title, 
	const char* message, 
	unsigned long invocationId, VoidCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKNotificationBanner_showBannerWithTitle_message_completionHandler()");
	    [GKNotificationBanner showBannerWithTitle:[NSString stringWithUTF8String:title] message:[NSString stringWithUTF8String:message] completionHandler:^()
		{
			
			completionHandler(invocationId);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	
}



void GKNotificationBanner_showBannerWithTitle_message_duration_completionHandler(
	const char* title, 
	const char* message, 
	double duration, 
	unsigned long invocationId, VoidCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKNotificationBanner_showBannerWithTitle_message_duration_completionHandler()");
	    [GKNotificationBanner showBannerWithTitle:[NSString stringWithUTF8String:title] message:[NSString stringWithUTF8String:message] duration:duration completionHandler:^()
		{
			
			completionHandler(invocationId);
			
		}
];
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


void GKNotificationBanner_Dispose(void* ptr)
{
    GKNotificationBanner* val = (__bridge GKNotificationBanner*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKNotificationBanner");
}

}
