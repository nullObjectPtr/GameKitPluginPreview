//
//  GKMatchRequest.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" uint GKMatchRequest_maxPlayersAllowedForMatchOfType(
	long matchType,
    void** exception
    );


// Init Methods 
extern "C" void* GKMatchRequest_init(
    void** exceptionPtr);


// Instance methods 

// Void methods 

// Properties 
extern "C" uint GKMatchRequest_GetPropMaxPlayers(void* ptr);
extern "C" void GKMatchRequest_SetPropMaxPlayers(void* ptr, uint maxPlayers, void** exceptionPtr);

extern "C" uint GKMatchRequest_GetPropMinPlayers(void* ptr);
extern "C" void GKMatchRequest_SetPropMinPlayers(void* ptr, uint minPlayers, void** exceptionPtr);

extern "C" uint GKMatchRequest_GetPropDefaultNumberOfPlayers(void* ptr);
extern "C" void GKMatchRequest_SetPropDefaultNumberOfPlayers(void* ptr, uint defaultNumberOfPlayers, void** exceptionPtr);

extern "C" const char* GKMatchRequest_GetPropInviteMessage(void* ptr);
extern "C" void GKMatchRequest_SetPropInviteMessage(void* ptr, const char* inviteMessage, void** exceptionPtr);

extern "C" uint GKMatchRequest_GetPropPlayerGroup(void* ptr);
extern "C" void GKMatchRequest_SetPropPlayerGroup(void* ptr, uint playerGroup, void** exceptionPtr);
extern "C" void GKMatchRequest_SetPropRecipientResponseHandler(void* ptr, RecipientResponseHandler recipientResponseHandler, void** exceptionPtr);

extern "C" void GKMatchRequest_GetPropRecipients(void* ptr, void** buffer, long* count);
extern "C" void GKMatchRequest_SetPropRecipients(void* ptr, void* recipients[],
	long recipientsCount, void** exceptionPtr);




extern "C" void GKMatchRequest_Dispose(void* ptr);
