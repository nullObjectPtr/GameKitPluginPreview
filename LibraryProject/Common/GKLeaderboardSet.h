//
//  GKLeaderboardSet.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void GKLeaderboardSet_loadLeaderboardSetsWithCompletionHandler(
	unsigned long invocationId, GKLeaderboardSetCallback completionHandler,
    void** exception
    );


// Init Methods 

// Instance methods 
extern "C" void GKLeaderboardSet_loadLeaderboardsWithHandler(
	void* ptr,
	unsigned long invocationId, LoadLeaderboardsCallback handler,
    void** exception
    );


// Void methods 

// Properties 

extern "C" const char* GKLeaderboardSet_GetPropTitle(void* ptr);


extern "C" const char* GKLeaderboardSet_GetPropIdentifier(void* ptr);
extern "C" void GKLeaderboardSet_SetPropIdentifier(void* ptr, const char* identifier, void** exceptionPtr);



extern "C" const char* GKLeaderboardSet_GetPropGroupIdentifier(void* ptr);




extern "C" void GKLeaderboardSet_Dispose(void* ptr);
