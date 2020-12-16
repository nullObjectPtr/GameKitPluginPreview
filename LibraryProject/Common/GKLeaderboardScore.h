//
//  GKLeaderboardScore.h
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

// Instance methods 

// Void methods 

// Properties 

extern "C" uint GKLeaderboardScore_GetPropContext(void* ptr);
extern "C" void GKLeaderboardScore_SetPropContext(void* ptr, uint context, void** exceptionPtr);



extern "C" const char* GKLeaderboardScore_GetPropLeaderboardID(void* ptr);
extern "C" void GKLeaderboardScore_SetPropLeaderboardID(void* ptr, const char* leaderboardID, void** exceptionPtr);



extern "C" void* GKLeaderboardScore_GetPropPlayer(void* ptr);
extern "C" void GKLeaderboardScore_SetPropPlayer(void* ptr, void* player, void** exceptionPtr);



extern "C" NSInteger GKLeaderboardScore_GetPropValue(void* ptr);
extern "C" void GKLeaderboardScore_SetPropValue(void* ptr, NSInteger value, void** exceptionPtr);





extern "C" void GKLeaderboardScore_Dispose(void* ptr);
