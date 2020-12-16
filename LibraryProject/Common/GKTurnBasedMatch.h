//
//  GKTurnBasedMatch.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void GKTurnBasedMatch_loadMatchesWithCompletionHandler(
	unsigned long invocationId, LoadMatchesCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_loadMatchWithID_withCompletionHandler(
	const char* matchID,
    unsigned long invocationId, StaticTurnBasedMatchCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_findMatchForRequest_withCompletionHandler(
	void* request,
    unsigned long invocationId, StaticTurnBasedMatchCallback completionHandler,
    void** exception
    );


// Init Methods 

// Instance methods 
extern "C" void GKTurnBasedMatch_acceptInviteWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, TurnBasedMatchCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_declineInviteWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_rematchWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, TurnBasedMatchCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_loadMatchDataWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, ByteArrayCallback completionHandler,
    void** exception
    );


// Void methods 

// Properties 

extern "C" const char* GKTurnBasedMatch_GetPropMessage(void* ptr);
extern "C" void GKTurnBasedMatch_SetPropMessage(void* ptr, const char* message, void** exceptionPtr);



extern "C" double GKTurnBasedMatch_GetPropCreationDate(void* ptr);


extern "C" const char* GKTurnBasedMatch_GetPropMatchID(void* ptr);


extern "C" void GKTurnBasedMatch_GetPropParticipants(void* ptr, void** buffer, long* count);

extern "C" void* GKTurnBasedMatch_GetPropCurrentParticipant(void* ptr);


extern "C" uint GKTurnBasedMatch_GetPropMatchDataMaximumSize(void* ptr);


extern "C" long GKTurnBasedMatch_GetPropStatus(void* ptr);


extern "C" void GKTurnBasedMatch_GetPropMatchData(void* ptr, const void** buffer, long* count);




extern "C" void GKTurnBasedMatch_Dispose(void* ptr);
