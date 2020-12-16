//
//  GKLeaderboard.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKLeaderboard.h"
#import "Converters.h"


extern "C" {

//ClassMethods
#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void GKLeaderboard_loadLeaderboardsWithIDs_completionHandler(
	const char* leaderboardIDs[],
	long leaderboardIDsCount, 
	unsigned long invocationId, LoadLeaderboardsWithIDsCompletionCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKLeaderboard_loadLeaderboardsWithIDs_completionHandler()");
	    [GKLeaderboard loadLeaderboardsWithIDs:[Converters StringArray:leaderboardIDs withCount:leaderboardIDsCount] completionHandler:^(NSArray<GKLeaderboard*>* leaderboards,
NSError* error)
		{
			long leaderboardsCount = [leaderboards count];
			void** leaderboardsBuffer = nil;
			if(leaderboardsCount > 0)
			{
				leaderboardsBuffer = (void**) malloc(sizeof(void*) * leaderboardsCount);
				[Converters NSArrayToRetainedCArray:leaderboards withBuffer:leaderboardsBuffer];
			}
			completionHandler(invocationId, leaderboardsBuffer, leaderboardsCount, (__bridge_retained void*) error);
			free(leaderboardsBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	
}
#endif


#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void GKLeaderboard_submitScore_context_player_leaderboardIDs_completionHandler(
	NSInteger score, 
	uint context, 
	void* player, 
	const char* leaderboardIDs[],
	long leaderboardIDsCount, 
	unsigned long invocationId, StaticCompletionCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKLeaderboard_submitScore_context_player_leaderboardIDs_completionHandler()");
	    [GKLeaderboard submitScore:score context:context player:(__bridge GKPlayer*) player leaderboardIDs:[Converters StringArray:leaderboardIDs withCount:leaderboardIDsCount] completionHandler:^(NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	
}
#endif


//InitMethods
//InstanceMethods
#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void GKLeaderboard_submitScore_context_player_completionHandler(
    void* ptr,
    NSInteger score,
    uint context,
    void* player,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	    [iGKLeaderboard submitScore:score context:context player:(__bridge GKPlayer*) player completionHandler:^(NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}
#endif


#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void GKLeaderboard_loadPreviousOccurrenceWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, GKLeaderboardCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	    [iGKLeaderboard loadPreviousOccurrenceWithCompletionHandler:^(GKLeaderboard* leaderboards,
NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) leaderboards, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}
#endif


void GKLeaderboard_loadEntriesForPlayers_timeScope_completionHandler(
    void* ptr,
    void* players[],
	long playersCount,
    long timeScope,
    unsigned long invocationId, LoadLeaderboardEntriesCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	    [iGKLeaderboard loadEntriesForPlayers:[Converters BridgedArray:players withCount:playersCount] timeScope:(GKLeaderboardTimeScope)timeScope completionHandler:^(GKLeaderboardEntry* localPlayerEntry,
NSArray<GKLeaderboardEntry*>* entries,
NSError* error)
		{
			long entriesCount = [entries count];
			void** entriesBuffer = nil;
			if(entriesCount > 0)
			{
				entriesBuffer = (void**) malloc(sizeof(void*) * entriesCount);
				[Converters NSArrayToRetainedCArray:entries withBuffer:entriesBuffer];
			}
			completionHandler(invocationId, (__bridge_retained void*) localPlayerEntry, entriesBuffer, entriesCount, (__bridge_retained void*) error);
			free(entriesBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



//VoidMethods
//Properties
const char* GKLeaderboard_GetPropTitle(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSString* val = [iGKLeaderboard title];
	return [val UTF8String];
}


double GKLeaderboard_GetPropDuration(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSTimeInterval val = [iGKLeaderboard duration];
	return val;
}


const char* GKLeaderboard_GetPropGroupIdentifier(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSString* val = [iGKLeaderboard groupIdentifier];
	return [val UTF8String];
}


#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
double GKLeaderboard_GetPropStartDate(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSDate* val = [iGKLeaderboard startDate];
	return [val timeIntervalSince1970];
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
double GKLeaderboard_GetPropNextStartDate(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSDate* val = [iGKLeaderboard nextStartDate];
	return [val timeIntervalSince1970];
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
long GKLeaderboard_GetPropType(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	GKLeaderboardType val = [iGKLeaderboard type];
	return val;
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
const char* GKLeaderboard_GetPropBaseLeaderboardID(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSString* val = [iGKLeaderboard baseLeaderboardID];
	return [val UTF8String];
}
#endif



void GKLeaderboard_Dispose(void* ptr)
{
    GKLeaderboard* val = (__bridge GKLeaderboard*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKLeaderboard");
}

}
