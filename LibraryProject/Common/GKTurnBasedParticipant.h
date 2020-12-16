//
//  GKTurnBasedParticipant.h
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

// Void methods 

// Properties 

extern "C" void* GKTurnBasedParticipant_GetPropPlayer(void* ptr);


extern "C" long GKTurnBasedParticipant_GetPropStatus(void* ptr);


extern "C" double GKTurnBasedParticipant_GetPropLastTurnDate(void* ptr);




extern "C" void GKTurnBasedParticipant_Dispose(void* ptr);
