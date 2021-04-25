//
//  GKLeaderboardSet.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKLeaderboardSet.h"
#import "Converters.h"


extern "C" {

//ClassMethods
void GKLeaderboardSet_loadLeaderboardSetsWithCompletionHandler(
	unsigned long invocationId, GKLeaderboardSetCallback completionHandler, 
	void** exception
    )
{

        @try {
            NSLog(@"GKLeaderboardSet_loadLeaderboardSetsWithCompletionHandler()");
            [GKLeaderboardSet loadLeaderboardSetsWithCompletionHandler:^(NSArray<GKLeaderboardSet*>* leaderboardSets,
NSError* error)
		{
			long leaderboardSetsCount = [leaderboardSets count];
			void** leaderboardSetsBuffer = nil;
			if(leaderboardSetsCount > 0)
			{
				leaderboardSetsBuffer = (void**) malloc(sizeof(void*) * leaderboardSetsCount);
				[Converters NSArrayToRetainedCArray:leaderboardSets withBuffer:leaderboardSetsBuffer];
			}
			completionHandler(invocationId, leaderboardSetsBuffer, leaderboardSetsCount, (__bridge_retained void*) error);
			free(leaderboardSetsBuffer);
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
void GKLeaderboardSet_loadLeaderboardsWithHandler(
    void* ptr,
    unsigned long invocationId, LoadLeaderboardsCallback handler,
    void** exception
    )
{ 
    if(@available(macOS 10.16, iOS 14, tvOS 14, * ))
    { 
        @try
        {
            GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
            [iGKLeaderboardSet loadLeaderboardsWithHandler:^(NSArray<GKLeaderboard*>* leaderboards,
NSError* error)
		{
			long leaderboardsCount = [leaderboards count];
			void** leaderboardsBuffer = nil;
			if(leaderboardsCount > 0)
			{
				leaderboardsBuffer = (void**) malloc(sizeof(void*) * leaderboardsCount);
				[Converters NSArrayToRetainedCArray:leaderboards withBuffer:leaderboardsBuffer];
			}
			handler(invocationId, leaderboardsBuffer, leaderboardsCount, (__bridge_retained void*) error);
			free(leaderboardsBuffer);
		}
];
        }
        @catch(NSException* ex)
        {
            *exception = (__bridge_retained void*) ex;
        }

    }
}



//VoidMethods
//Properties
const char* GKLeaderboardSet_GetPropTitle(void* ptr)
{ 
        GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
        NSString* val = [iGKLeaderboardSet title];
        return [val UTF8String];
    
}

const char* GKLeaderboardSet_GetPropIdentifier(void* ptr)
{ 
        GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
        NSString* val = [iGKLeaderboardSet identifier];
        return [val UTF8String];
    
}

void GKLeaderboardSet_SetPropIdentifier(void* ptr, const char* identifier, void** exceptionPtr)
{ 
        @try
        {
            GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
            [iGKLeaderboardSet setIdentifier:[NSString stringWithUTF8String:identifier]];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
}

const char* GKLeaderboardSet_GetPropGroupIdentifier(void* ptr)
{ 
        GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
        NSString* val = [iGKLeaderboardSet groupIdentifier];
        return [val UTF8String];
    
}



void GKLeaderboardSet_Dispose(void* ptr)
{
    GKLeaderboardSet* val = (__bridge GKLeaderboardSet*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKLeaderboardSet");
}

}
