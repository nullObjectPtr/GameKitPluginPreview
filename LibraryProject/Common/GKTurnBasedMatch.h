//
//  GKTurnBasedMatch.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
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

extern "C" void GKTurnBasedMatch_saveCurrentTurnWithMatchData_completionHandler(
	void* ptr,
	const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_endTurnWithNextParticipants_turnTimeout_matchData_completionHandler(
	void* ptr,
	void* nextParticipants[],
	long nextParticipantsCount,
    double timeout,
    const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_endMatchInTurnWithMatchData_completionHandler(
	void* ptr,
	const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_endMatchInTurnWithMatchData_leaderboardScores_achievements_completionHandler(
	void* ptr,
	const void* matchData, long matchDataLength,
    void* scores[],
	long scoresCount,
    void* achievements[],
	long achievementsCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_participantQuitInTurnWithOutcome_nextParticipants_turnTimeout_matchData_completionHandler(
	void* ptr,
	long matchOutcome,
    void* nextParticipants[],
	long nextParticipantsCount,
    double timeout,
    const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_participantQuitOutOfTurnWithOutcome_withCompletionHandler(
	void* ptr,
	long matchOutcome,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_removeWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_saveMergedMatchData_withResolvedExchanges_completionHandler(
	void* ptr,
	const void* matchData, long matchDataLength,
    void* exchanges[],
	long exchangesCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_sendExchangeToParticipants_data_localizableMessageKey_arguments_timeout_completionHandler(
	void* ptr,
	void* participants[],
	long participantsCount,
    const void* data, long dataLength,
    const char* key,
    const char* arguments[],
	long argumentsCount,
    double timeout,
    unsigned long invocationId, TurnBasedExchangeCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_sendReminderToParticipants_localizableMessageKey_arguments_completionHandler(
	void* ptr,
	void* participants[],
	long participantsCount,
    const char* key,
    const char* arguments[],
	long argumentsCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    );

extern "C" void GKTurnBasedMatch_setLocalizableMessageWithKey_arguments(
	void* ptr,
	const char* key,
    const char* arguments[],
	long argumentsCount,
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


extern "C" void GKTurnBasedMatch_GetPropActiveExchanges(void* ptr, void** buffer, long* count);

extern "C" void GKTurnBasedMatch_GetPropCompletedExchanges(void* ptr, void** buffer, long* count);

extern "C" uint GKTurnBasedMatch_GetPropExchangeDataMaximumSize(void* ptr);


extern "C" uint GKTurnBasedMatch_GetPropExchangeMaxInitiatedExchangesPerPlayer(void* ptr);


extern "C" void GKTurnBasedMatch_GetPropExchanges(void* ptr, void** buffer, long* count);



extern "C" void GKTurnBasedMatch_Dispose(void* ptr);
