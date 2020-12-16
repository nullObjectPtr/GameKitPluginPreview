//
//  GKMatchmakerViewController.h
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
extern "C" void* GKMatchmakerViewController_initWithMatchRequest(
    void* request,
    void** exceptionPtr);

extern "C" void* GKMatchmakerViewController_initWithInvite(
    void* invite,
    void** exceptionPtr);


// Instance methods 
extern "C" void GKMatchmakerViewController_present(
	void* ptr,
	void** exception
    );

extern "C" void GKMatchmakerViewController_dismiss(
	void* ptr,
	void** exception
    );

extern "C" void GKMatchmakerViewController_addPlayersToMatch(
	void* ptr,
	void* match,
    void** exception
    );

extern "C" void GKMatchmakerViewController_setHostedPlayer_didConnect(
	void* ptr,
	void* player,
    bool connected,
    void** exception
    );


// Void methods 

// Properties 

extern "C" void* GKMatchmakerViewController_GetPropMatchmakerDelegate(void* ptr);
extern "C" void GKMatchmakerViewController_SetPropMatchmakerDelegate(void* ptr, void* matchmakerDelegate, void** exceptionPtr);



extern "C" bool GKMatchmakerViewController_GetPropHosted(void* ptr);
extern "C" void GKMatchmakerViewController_SetPropHosted(void* ptr, bool hosted, void** exceptionPtr);



extern "C" long GKMatchmakerViewController_GetPropMatchmakingMode(void* ptr);
extern "C" void GKMatchmakerViewController_SetPropMatchmakingMode(void* ptr, long matchmakingMode, void** exceptionPtr);





extern "C" void GKMatchmakerViewController_Dispose(void* ptr);
