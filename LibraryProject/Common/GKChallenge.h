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
extern "C" void GKChallenge_loadReceivedChallengesWithCompletionHandler(
	unsigned long invocationId, LoadReceivedChallengesCompletionCallback completionHandler,
    void** exception
    );


// Init Methods 

// Instance methods 

// Void methods 

// Properties 

extern "C" double GKChallenge_GetPropIssueDate(void* ptr);


extern "C" double GKChallenge_GetPropCompletionDate(void* ptr);


extern "C" void* GKChallenge_GetPropIssuingPlayer(void* ptr);


extern "C" void* GKChallenge_GetPropReceivingPlayer(void* ptr);


extern "C" const char* GKChallenge_GetPropMessage(void* ptr);


extern "C" long GKChallenge_GetPropState(void* ptr);




extern "C" void GKChallenge_Dispose(void* ptr);
