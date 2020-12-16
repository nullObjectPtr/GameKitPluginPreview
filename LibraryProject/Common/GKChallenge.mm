//
//  GKChallenge.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKChallenge.h"
#import "Converters.h"


extern "C" {

//ClassMethods
void GKChallenge_loadReceivedChallengesWithCompletionHandler(
	unsigned long invocationId, LoadReceivedChallengesCompletionCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKChallenge_loadReceivedChallengesWithCompletionHandler()");
	    [GKChallenge loadReceivedChallengesWithCompletionHandler:^(NSArray<GKChallenge*>* challenges,
NSError* error)
		{
			long challengesCount = [challenges count];
			void** challengesBuffer = nil;
			if(challengesCount > 0)
			{
				challengesBuffer = (void**) malloc(sizeof(void*) * challengesCount);
				[Converters NSArrayToRetainedCArray:challenges withBuffer:challengesBuffer];
			}
			completionHandler(invocationId, challengesBuffer, challengesCount, (__bridge_retained void*) error);
			free(challengesBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	
}



//InitMethods
//InstanceMethods
//VoidMethods
//Properties
double GKChallenge_GetPropIssueDate(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	NSDate* val = [iGKChallenge issueDate];
	return [val timeIntervalSince1970];
}


double GKChallenge_GetPropCompletionDate(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	NSDate* val = [iGKChallenge completionDate];
	return [val timeIntervalSince1970];
}


void* GKChallenge_GetPropIssuingPlayer(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	GKPlayer* val = [iGKChallenge issuingPlayer];
	return (__bridge_retained void*) val;
}


void* GKChallenge_GetPropReceivingPlayer(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	GKPlayer* val = [iGKChallenge receivingPlayer];
	return (__bridge_retained void*) val;
}


const char* GKChallenge_GetPropMessage(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	NSString* val = [iGKChallenge message];
	return [val UTF8String];
}


long GKChallenge_GetPropState(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	GKChallengeState val = [iGKChallenge state];
	return val;
}




void GKChallenge_Dispose(void* ptr)
{
    GKChallenge* val = (__bridge GKChallenge*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKChallenge");
}

}
