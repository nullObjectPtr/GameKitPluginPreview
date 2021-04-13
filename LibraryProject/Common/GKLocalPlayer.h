//
//  GKLocalPlayer.h
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
extern "C" void GKLocalPlayer_registerListener(
	void* ptr,
	void* listener,
    void** exception
    );

extern "C" void GKLocalPlayer_unregisterAllListeners(
	void* ptr,
	void** exception
    );

extern "C" void GKLocalPlayer_unregisterListener(
	void* ptr,
	void* listener,
    void** exception
    );

extern "C" void GKLocalPlayer_loadRecentPlayersWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, LoadRecentPlayersWithCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKLocalPlayer_setDefaultLeaderboardIdentifier_completionHandler(
	void* ptr,
	const char* leaderboardIdentifier,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKLocalPlayer_loadDefaultLeaderboardIdentifierWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, NSStringCallback completionHandler,
    void** exception
    );

extern "C" void GKLocalPlayer_loadChallengableFriendsWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, LoadChallengableFriendsWithCompletionCallback completionHandler,
    void** exception
    );


// Void methods 

// Properties 
extern "C" void GKLocalPlayer_SetPropAuthenticateHandler(void* ptr, AuthenticateHandler authenticateHandler, void** exceptionPtr);


extern "C" void* GKLocalPlayer_GetPropLocalPlayer();


extern "C" void* GKLocalPlayer_GetPropLocal();


extern "C" bool GKLocalPlayer_GetPropAuthenticated(void* ptr);


extern "C" bool GKLocalPlayer_GetPropUnderage(void* ptr);


extern "C" bool GKLocalPlayer_GetPropMultiplayerGamingRestricted(void* ptr);


extern "C" bool GKLocalPlayer_GetPropPersonalizedCommunicationRestricted(void* ptr);




extern "C" void GKLocalPlayer_Dispose(void* ptr);
