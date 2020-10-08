//
//  GKAchievement.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 

// Init Methods 
extern "C" void* GKAchievement_initWithIdentifier(
    const char* identifier,
    void** exceptionPtr);

extern "C" void* GKAchievement_initWithIdentifier_player(
    const char* identifier,
    void* player,
    void** exceptionPtr);


// Instance methods 

// Void methods 

// Properties 
extern "C" bool GKAchievement_GetPropCompleted(void* ptr);
extern "C" bool GKAchievement_GetPropShowsCompletionBanner(void* ptr);
extern "C" void GKAchievement_SetPropShowsCompletionBanner(void* ptr, bool showsCompletionBanner, void** exceptionPtr);

extern "C" const char* GKAchievement_GetPropIdentifier(void* ptr);
extern "C" void GKAchievement_SetPropIdentifier(void* ptr, const char* identifier, void** exceptionPtr);




extern "C" void GKAchievement_Dispose(void* ptr);
