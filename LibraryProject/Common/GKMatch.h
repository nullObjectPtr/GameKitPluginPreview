//
//  GKMatch.h
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
extern "C" void GKMatch_disconnect(
	void* ptr,
	void** exception
    );

extern "C" void GKMatch_sendDataToAllPlayers_withDataMode_error(
    void* ptr,
    void* buffer,
    unsigned long length);
extern "C" void GKMatch_chooseBestHostingPlayerWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, GKPlayerCallback completionHandler,
    void** exception
    );

extern "C" void GKMatch_rematchWithCompletionHandler(
	void* ptr,
	unsigned long invocationId, MatchCompletionCallback completionHandler,
    void** exception
    );

extern "C" void* GKMatch_voiceChatWithName(
	void* ptr,
	const char* name,
    void** exception
    );

extern "C" bool GKMatch_sendData_toPlayers_dataMode_error(
    void* ptr,
    const void* buffer, long dataLength,
    void* players[],
	long playersCount,
    long mode,
    void** error
    );

// Void methods 

// Properties 
extern "C" void* GKMatch_GetPropDelegate(void* ptr);
extern "C" void GKMatch_SetPropDelegate(void* ptr, void* delegate, void** exceptionPtr);

extern "C" uint GKMatch_GetPropExpectedPlayerCount(void* ptr);
extern "C" void GKMatch_GetPropPlayers(void* ptr, void** buffer, long* count);



extern "C" void GKMatch_Dispose(void* ptr);
