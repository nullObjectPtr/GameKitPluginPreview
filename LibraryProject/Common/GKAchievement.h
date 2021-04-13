//
//  GKAchievement.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void GKAchievement_loadAchievementsWithCompletionHandler(
	unsigned long invocationId, GKAchievementsCallback completionHandler,
    void** exception
    );

extern "C" void GKAchievement_reportAchievements_withCompletionHandler(
	void* achievements[],
	long achievementsCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKAchievement_resetAchievementsWithCompletionHandler(
	unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKAchievement_reportAchievements_withEligibleChallenges_withCompletionHandler(
	void* achievements[],
	long achievementsCount,
    void* challenges[],
	long challengesCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );


// Init Methods 
extern "C" void* GKAchievement_initWithIdentifier(
    const char* identifier,
    void** exceptionPtr);

extern "C" void* GKAchievement_initWithIdentifier_player(
    const char* identifier,
    void* player,
    void** exceptionPtr);


// Instance methods 
extern "C" void GKAchievement_selectChallengeablePlayers_withCompletionHandler(
	void* ptr,
	void* players[],
	long playersCount,
    unsigned long invocationId, GKPlayersCallback completionHandler,
    void** exception
    );

extern "C" void* GKAchievement_challengeComposeControllerWithMessage_players_completionHandler(
	void* ptr,
	const char* message,
    void* players[],
	long playersCount,
    unsigned long invocationId, GKChallengeComposeCompletionCallback completionHandler,
    void** exception
    );


// Void methods 

// Properties 

extern "C" bool GKAchievement_GetPropCompleted(void* ptr);


extern "C" bool GKAchievement_GetPropShowsCompletionBanner(void* ptr);
extern "C" void GKAchievement_SetPropShowsCompletionBanner(void* ptr, bool showsCompletionBanner, void** exceptionPtr);



extern "C" const char* GKAchievement_GetPropIdentifier(void* ptr);
extern "C" void GKAchievement_SetPropIdentifier(void* ptr, const char* identifier, void** exceptionPtr);



extern "C" double GKAchievement_GetPropPercentComplete(void* ptr);
extern "C" void GKAchievement_SetPropPercentComplete(void* ptr, double percentComplete, void** exceptionPtr);



extern "C" double GKAchievement_GetPropLastReportedDate(void* ptr);




extern "C" void GKAchievement_Dispose(void* ptr);
