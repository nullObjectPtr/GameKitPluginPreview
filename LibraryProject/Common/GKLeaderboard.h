//
//  GKLeaderboard.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void GKLeaderboard_loadLeaderboardsWithIDs_completionHandler(
	const char* leaderboardIDs[],
	long leaderboardIDsCount,
    unsigned long invocationId, LoadLeaderboardsWithIDsCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKLeaderboard_submitScore_context_player_leaderboardIDs_completionHandler(
	NSInteger score,
    uint context,
    void* player,
    const char* leaderboardIDs[],
	long leaderboardIDsCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );


// Init Methods 

// Instance methods 
extern "C" void GKLeaderboard_submitScore_context_player_completionHandler(
	void* ptr,
	NSInteger score,
    uint context,
    void* player,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKLeaderboard_loadPreviousOccurrenceWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, GKLeaderboardCallback completionHandler,
    void** exception
    );

extern "C" void GKLeaderboard_loadEntriesForPlayers_timeScope_completionHandler(
	void* ptr,
	void* players[],
	long playersCount,
    long timeScope,
    unsigned long invocationId, LoadLeaderboardEntriesCallback completionHandler,
    void** exception
    );


// Void methods 

// Properties 

extern "C" const char* GKLeaderboard_GetPropTitle(void* ptr);


extern "C" double GKLeaderboard_GetPropDuration(void* ptr);


extern "C" const char* GKLeaderboard_GetPropGroupIdentifier(void* ptr);


extern "C" double GKLeaderboard_GetPropStartDate(void* ptr);


extern "C" double GKLeaderboard_GetPropNextStartDate(void* ptr);


extern "C" long GKLeaderboard_GetPropType(void* ptr);


extern "C" const char* GKLeaderboard_GetPropBaseLeaderboardID(void* ptr);




extern "C" void GKLeaderboard_Dispose(void* ptr);
