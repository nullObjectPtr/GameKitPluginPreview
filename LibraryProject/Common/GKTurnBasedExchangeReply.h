//
//  GKTurnBasedExchangeReply.h
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

extern "C" const char* GKTurnBasedExchangeReply_GetPropMessage(void* ptr);


extern "C" double GKTurnBasedExchangeReply_GetPropReplyDate(void* ptr);


extern "C" void* GKTurnBasedExchangeReply_GetPropRecipient(void* ptr);




extern "C" void GKTurnBasedExchangeReply_Dispose(void* ptr);
