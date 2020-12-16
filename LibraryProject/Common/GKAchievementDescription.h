//
//  GKAchievementDescription.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void GKAchievementDescription_loadAchievementDescriptionsWithCompletionHandler(
	unsigned long invocationId, GKAchievementDescriptionsCallback completionHandler,
    void** exception
    );


// Init Methods 

// Instance methods 

// Void methods 

// Properties 

extern "C" const char* GKAchievementDescription_GetPropIdentifier(void* ptr);


extern "C" const char* GKAchievementDescription_GetPropTitle(void* ptr);


extern "C" const char* GKAchievementDescription_GetPropUnachievedDescription(void* ptr);


extern "C" const char* GKAchievementDescription_GetPropAchievedDescription(void* ptr);


extern "C" NSInteger GKAchievementDescription_GetPropMaximumPoints(void* ptr);


extern "C" bool GKAchievementDescription_GetPropHidden(void* ptr);


extern "C" bool GKAchievementDescription_GetPropReplayable(void* ptr);


extern "C" const char* GKAchievementDescription_GetPropGroupIdentifier(void* ptr);




extern "C" void GKAchievementDescription_Dispose(void* ptr);
