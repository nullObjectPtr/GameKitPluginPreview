//
//  GKVoiceChat.h
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
extern "C" bool GKVoiceChat_isVoIPAllowed(
	void** exception
    );

extern "C" void GKVoiceChat_start(
	void* ptr,
	void** exception
    );

extern "C" void GKVoiceChat_stop(
	void* ptr,
	void** exception
    );

extern "C" void GKVoiceChat_setPlayer_muted(
	void* ptr,
	void* player,
    bool isMuted,
    void** exception
    );


// Void methods 

// Properties 

extern "C" bool GKVoiceChat_GetPropActive(void* ptr);
extern "C" void GKVoiceChat_SetPropActive(void* ptr, bool active, void** exceptionPtr);



extern "C" const char* GKVoiceChat_GetPropName(void* ptr);


extern "C" void GKVoiceChat_GetPropPlayers(void* ptr, void** buffer, long* count);

extern "C" float GKVoiceChat_GetPropVolume(void* ptr);
extern "C" void GKVoiceChat_SetPropVolume(void* ptr, float volume, void** exceptionPtr);





extern "C" void GKVoiceChat_Dispose(void* ptr);
