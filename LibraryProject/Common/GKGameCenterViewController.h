//
//  GKGameCenterViewController.h
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
extern "C" void* GKGameCenterViewController_initWithState(
    long state,
    void** exceptionPtr);

extern "C" void* GKGameCenterViewController_initWithAchievementID(
    const char* achievementID,
    void** exceptionPtr);

extern "C" void* GKGameCenterViewController_initWithLeaderboard_playerScope(
    void* leaderboard,
    long playerScope,
    void** exceptionPtr);

extern "C" void* GKGameCenterViewController_initWithLeaderboardID_playerScope_timeScope(
    const char* leaderboardID,
    long playerScope,
    long timeScope,
    void** exceptionPtr);

extern "C" void* GKGameCenterViewController_registerDidFinish(
     const void* ptr);

extern "C" void GKGameCenterViewController_unregisterDidFinish(
     const void* ptr);


// Instance methods 

// Void methods 

// Properties 

extern "C" void GKGameCenterViewController_Dispose(void* ptr);
