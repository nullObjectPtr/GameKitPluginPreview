//
//  GKMatchmaker.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void* GKMatchmaker_sharedMatchmaker(
	void** exception
    );


// Init Methods 

// Instance methods 
extern "C" void GKMatchmaker_cancel(
	void* ptr,
	void** exception
    );

extern "C" void GKMatchmaker_cancelPendingInviteToPlayer(
	void* ptr,
	void* player,
    void** exception
    );

extern "C" void GKMatchmaker_stopBrowsingForNearbyPlayers(
	void* ptr,
	void** exception
    );

extern "C" void GKMatchmaker_finishMatchmakingForMatch(
	void* ptr,
	void* match,
    void** exception
    );

extern "C" void GKMatchmaker_matchForInvite_completionHandler(
	void* ptr,
	void* invite,
    unsigned long invocationId, MatchCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKMatchmaker_addPlayersToMatch_matchRequest_completionHandler(
	void* ptr,
	void* match,
    void* matchRequest,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKMatchmaker_findPlayersForHostedRequest_withCompletionHandler(
	void* ptr,
	void* request,
    unsigned long invocationId, GKPlayersCallback completionHandler,
    void** exception
    );

extern "C" void GKMatchmaker_queryActivityWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, QueryActivityCallback completionHandler,
    void** exception
    );

extern "C" void GKMatchmaker_queryPlayerGroupActivity_withCompletionHandler(
	void* ptr,
	uint playerGroup,
    unsigned long invocationId, QueryActivityCallback completionHandler,
    void** exception
    );

extern "C" void GKMatchmaker_findMatchForRequest_withCompletionHandler(
	void* ptr,
	void* request,
    unsigned long invocationId, FindMatchForRequestCallback completionHandler,
    void** exception
    );

extern "C" void GKMatchmaker_startBrowsingForNearbyPlayersWithHandler(
	void* ptr,
	unsigned long invocationId, StartBrowsingForNearbyPlayersCallback reachableHandler,
    void** exception
    );


// Void methods 

// Properties 



extern "C" void GKMatchmaker_Dispose(void* ptr);
