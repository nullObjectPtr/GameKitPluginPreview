//
//  GKInvite.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
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

extern "C" uint GKInvite_GetPropPlayerGroup(void* ptr);


extern "C" void* GKInvite_GetPropSender(void* ptr);


extern "C" bool GKInvite_GetPropHosted(void* ptr);


extern "C" uint32_t GKInvite_GetPropPlayerAttributes(void* ptr);




extern "C" void GKInvite_Dispose(void* ptr);
