//
//  GKSavedGame.h
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

extern "C" const char* GKSavedGame_GetPropDeviceName(void* ptr);


extern "C" const char* GKSavedGame_GetPropName(void* ptr);


extern "C" double GKSavedGame_GetPropModificationDate(void* ptr);




extern "C" void GKSavedGame_Dispose(void* ptr);
