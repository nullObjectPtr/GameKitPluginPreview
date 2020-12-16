//
//  GKAchievement.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKAchievement.h"
#import "Converters.h"


extern "C" {

//ClassMethods
void GKAchievement_loadAchievementsWithCompletionHandler(
	unsigned long invocationId, GKAchievementsCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKAchievement_loadAchievementsWithCompletionHandler()");
	    [GKAchievement loadAchievementsWithCompletionHandler:^(NSArray<GKAchievement*>* achievements,
NSError* error)
		{
			long achievementsCount = [achievements count];
			void** achievementsBuffer = nil;
			if(achievementsCount > 0)
			{
				achievementsBuffer = (void**) malloc(sizeof(void*) * achievementsCount);
				[Converters NSArrayToRetainedCArray:achievements withBuffer:achievementsBuffer];
			}
			completionHandler(invocationId, achievementsBuffer, achievementsCount, (__bridge_retained void*) error);
			free(achievementsBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	
}



void GKAchievement_reportAchievements_withCompletionHandler(
	void* achievements[],
	long achievementsCount, 
	unsigned long invocationId, StaticCompletionCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKAchievement_reportAchievements_withCompletionHandler()");
	    [GKAchievement reportAchievements:[Converters BridgedArray:achievements withCount:achievementsCount] withCompletionHandler:^(NSError* error)
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



void GKAchievement_resetAchievementsWithCompletionHandler(
	unsigned long invocationId, StaticCompletionCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKAchievement_resetAchievementsWithCompletionHandler()");
	    [GKAchievement resetAchievementsWithCompletionHandler:^(NSError* error)
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



void GKAchievement_reportAchievements_withEligibleChallenges_withCompletionHandler(
	void* achievements[],
	long achievementsCount, 
	void* challenges[],
	long challengesCount, 
	unsigned long invocationId, StaticCompletionCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKAchievement_reportAchievements_withEligibleChallenges_withCompletionHandler()");
	    [GKAchievement reportAchievements:[Converters BridgedArray:achievements withCount:achievementsCount] withEligibleChallenges:[Converters BridgedArray:challenges withCount:challengesCount] withCompletionHandler:^(NSError* error)
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



//InitMethods
void* GKAchievement_initWithIdentifier(
    const char* identifier,
    void** exceptionPtr)
{
    @try 
    {
        GKAchievement* iGKAchievement = [[GKAchievement alloc] initWithIdentifier:[NSString stringWithUTF8String:identifier]];
            return (__bridge_retained void*) iGKAchievement;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void* GKAchievement_initWithIdentifier_player(
    const char* identifier,
    void* player,
    void** exceptionPtr)
{
    @try 
    {
        GKAchievement* iGKAchievement = [[GKAchievement alloc] initWithIdentifier:[NSString stringWithUTF8String:identifier] player:(__bridge GKPlayer*) player];
            return (__bridge_retained void*) iGKAchievement;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

//InstanceMethods
void GKAchievement_selectChallengeablePlayers_withCompletionHandler(
    void* ptr,
    void* players[],
	long playersCount,
    unsigned long invocationId, GKPlayersCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	    [iGKAchievement selectChallengeablePlayers:[Converters BridgedArray:players withCount:playersCount] withCompletionHandler:^(NSArray<GKPlayer*>* players,
NSError* error)
		{
			long playersCount = [players count];
			void** playersBuffer = nil;
			if(playersCount > 0)
			{
				playersBuffer = (void**) malloc(sizeof(void*) * playersCount);
				[Converters NSArrayToRetainedCArray:players withBuffer:playersBuffer];
			}
			completionHandler(invocationId, playersBuffer, playersCount, (__bridge_retained void*) error);
			free(playersBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void* GKAchievement_challengeComposeControllerWithMessage_players_completionHandler(
    void* ptr,
    const char* message,
    void* players[],
	long playersCount,
    unsigned long invocationId, GKChallengeComposeCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
        GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
        
#if TARGET_OS_OSX
	    NSViewController* val = [iGKAchievement challengeComposeControllerWithMessage:[NSString stringWithUTF8String:message] players:[Converters BridgedArray:players withCount:playersCount] completionHandler:^(NSViewController* composeController,
BOOL didIssueChallenge,
NSArray<NSString*>* sentPlayerIDs)
		{
			long sentPlayerIDsCount = [sentPlayerIDs count];
			const char** sentPlayerIDsBuffer = [Converters NSArrayOfStringsToCArrayOfStringPointers:sentPlayerIDs];
			completionHandler(invocationId, (__bridge_retained void*) composeController, didIssueChallenge, sentPlayerIDsBuffer, sentPlayerIDsCount);
			free(sentPlayerIDsBuffer);
		}
];
#else
        UIViewController* val = [iGKAchievement challengeComposeControllerWithMessage:[NSString stringWithUTF8String:message] players:[Converters BridgedArray:players withCount:playersCount] completionHandler:^(UIViewController* composeController,
BOOL didIssueChallenge,
NSArray<NSString*>* sentPlayerIDs)
        {
            long sentPlayerIDsCount = [sentPlayerIDs count];
            const char** sentPlayerIDsBuffer = [Converters NSArrayOfStringsToCArrayOfStringPointers:sentPlayerIDs];
            completionHandler(invocationId, (__bridge_retained void*) composeController, didIssueChallenge, sentPlayerIDsBuffer, sentPlayerIDsCount);
            free(sentPlayerIDsBuffer);
        }
];
#endif
	    return (__bridge_retained void*) val;
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	return nil;
}


//VoidMethods
//Properties
bool GKAchievement_GetPropCompleted(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	BOOL val = [iGKAchievement isCompleted];
	return val;
}


bool GKAchievement_GetPropShowsCompletionBanner(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	BOOL val = [iGKAchievement showsCompletionBanner];
	return val;
}

void GKAchievement_SetPropShowsCompletionBanner(void* ptr, bool showsCompletionBanner, void** exceptionPtr)
{
	@try
	{
		GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
		[iGKAchievement setShowsCompletionBanner:showsCompletionBanner];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


const char* GKAchievement_GetPropIdentifier(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	NSString* val = [iGKAchievement identifier];
	return [val UTF8String];
}

void GKAchievement_SetPropIdentifier(void* ptr, const char* identifier, void** exceptionPtr)
{
	@try
	{
		GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
		[iGKAchievement setIdentifier:[NSString stringWithUTF8String:identifier]];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


double GKAchievement_GetPropPercentComplete(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	double val = [iGKAchievement percentComplete];
	return val;
}

void GKAchievement_SetPropPercentComplete(void* ptr, double percentComplete, void** exceptionPtr)
{
	@try
	{
		GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
		[iGKAchievement setPercentComplete:percentComplete];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


double GKAchievement_GetPropLastReportedDate(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	NSDate* val = [iGKAchievement lastReportedDate];
	return [val timeIntervalSince1970];
}




void GKAchievement_Dispose(void* ptr)
{
    GKAchievement* val = (__bridge GKAchievement*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKAchievement");
}

}
