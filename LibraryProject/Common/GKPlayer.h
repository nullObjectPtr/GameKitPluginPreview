//
//  GKPlayer.h
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
extern "C" bool GKPlayer_scopedIDsArePersistent(
	void* ptr,
	void** exception
    );


// Void methods 

// Properties 
extern "C" const char* GKPlayer_GetPropGamePlayerID(void* ptr);
extern "C" const char* GKPlayer_GetPropTeamPlayerID(void* ptr);
extern "C" const char* GKPlayer_GetPropAlias(void* ptr);
extern "C" const char* GKPlayer_GetPropDisplayName(void* ptr);
extern "C" const char* GKPlayer_GetPropGuestIdentifier(void* ptr);



extern "C" void GKPlayer_Dispose(void* ptr);
