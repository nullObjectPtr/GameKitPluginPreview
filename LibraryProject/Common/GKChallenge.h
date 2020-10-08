//
//  GKChallenge.h
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
extern "C" void* GKChallenge_GetPropIssuingPlayer(void* ptr);
extern "C" void* GKChallenge_GetPropReceivingPlayer(void* ptr);
extern "C" const char* GKChallenge_GetPropMessage(void* ptr);
extern "C" long GKChallenge_GetPropState(void* ptr);



extern "C" void GKChallenge_Dispose(void* ptr);
