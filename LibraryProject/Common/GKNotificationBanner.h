//
//  GKNotificationBanner.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void GKNotificationBanner_showBannerWithTitle_message_completionHandler(
	const char* title,
    const char* message,
    unsigned long invocationId, VoidCallback completionHandler,
    void** exception
    );

extern "C" void GKNotificationBanner_showBannerWithTitle_message_duration_completionHandler(
	const char* title,
    const char* message,
    double duration,
    unsigned long invocationId, VoidCallback completionHandler,
    void** exception
    );


// Init Methods 

// Instance methods 

// Void methods 

// Properties 



extern "C" void GKNotificationBanner_Dispose(void* ptr);
