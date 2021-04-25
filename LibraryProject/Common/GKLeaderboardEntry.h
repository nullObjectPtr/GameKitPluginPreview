//
//  GKLeaderboardEntry.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
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

extern "C" uint GKLeaderboardEntry_GetPropContext(void* ptr);


extern "C" double GKLeaderboardEntry_GetPropDate(void* ptr);


extern "C" const char* GKLeaderboardEntry_GetPropFormattedScore(void* ptr);


extern "C" void* GKLeaderboardEntry_GetPropPlayer(void* ptr);


extern "C" NSInteger GKLeaderboardEntry_GetPropRank(void* ptr);


extern "C" NSInteger GKLeaderboardEntry_GetPropScore(void* ptr);




extern "C" void GKLeaderboardEntry_Dispose(void* ptr);
