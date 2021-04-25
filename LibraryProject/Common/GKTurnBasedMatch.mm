//
//  GKTurnBasedMatch.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKTurnBasedMatch.h"
#import "Converters.h"


extern "C" {

//ClassMethods
void GKTurnBasedMatch_loadMatchesWithCompletionHandler(
	unsigned long invocationId, LoadMatchesCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKTurnBasedMatch_loadMatchesWithCompletionHandler()");
	    [GKTurnBasedMatch loadMatchesWithCompletionHandler:^(NSArray<GKTurnBasedMatch*>* matches,
NSError* error)
		{
			long matchesCount = [matches count];
			void** matchesBuffer = nil;
			if(matchesCount > 0)
			{
				matchesBuffer = (void**) malloc(sizeof(void*) * matchesCount);
				[Converters NSArrayToRetainedCArray:matches withBuffer:matchesBuffer];
			}
			completionHandler(invocationId, matchesBuffer, matchesCount, (__bridge_retained void*) error);
			free(matchesBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	
}



void GKTurnBasedMatch_loadMatchWithID_withCompletionHandler(
	const char* matchID, 
	unsigned long invocationId, StaticTurnBasedMatchCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKTurnBasedMatch_loadMatchWithID_withCompletionHandler()");
	    [GKTurnBasedMatch loadMatchWithID:[NSString stringWithUTF8String:matchID] withCompletionHandler:^(GKTurnBasedMatch* match,
NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) match, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	
}



void GKTurnBasedMatch_findMatchForRequest_withCompletionHandler(
	void* request, 
	unsigned long invocationId, StaticTurnBasedMatchCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKTurnBasedMatch_findMatchForRequest_withCompletionHandler()");
	    [GKTurnBasedMatch findMatchForRequest:(__bridge GKMatchRequest*) request withCompletionHandler:^(GKTurnBasedMatch* match,
NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) match, (__bridge_retained void*) error);
			
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
void GKTurnBasedMatch_acceptInviteWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, TurnBasedMatchCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch acceptInviteWithCompletionHandler:^(GKTurnBasedMatch* match,
NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) match, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKTurnBasedMatch_declineInviteWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch declineInviteWithCompletionHandler:^(NSError* error)
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



void GKTurnBasedMatch_rematchWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, TurnBasedMatchCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch rematchWithCompletionHandler:^(GKTurnBasedMatch* match,
NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) match, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKTurnBasedMatch_loadMatchDataWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, ByteArrayCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch loadMatchDataWithCompletionHandler:^(NSData* matchData,
NSError* error)
		{
			
			completionHandler(invocationId, [matchData bytes], [matchData length], (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKTurnBasedMatch_saveCurrentTurnWithMatchData_completionHandler(
    void* ptr,
    const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
        NSData* data = [NSData dataWithBytes:matchData length:matchDataLength];
	    [iGKTurnBasedMatch saveCurrentTurnWithMatchData:data completionHandler:^(NSError* error)
		{
			completionHandler(invocationId, (__bridge_retained void*) error);
		}];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
}


void GKTurnBasedMatch_endTurnWithNextParticipants_turnTimeout_matchData_completionHandler(
    void* ptr,
    void* nextParticipants[],
	long nextParticipantsCount,
    double timeout,
    const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
        NSData* data = [NSData dataWithBytes:matchData length:matchDataLength];
	    [iGKTurnBasedMatch endTurnWithNextParticipants:[Converters BridgedArray:nextParticipants withCount:nextParticipantsCount] turnTimeout:timeout matchData:data completionHandler:^(NSError* error)
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



void GKTurnBasedMatch_endMatchInTurnWithMatchData_completionHandler(
    void* ptr,
    const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
        NSData* data = [NSData dataWithBytes:matchData length:matchDataLength];
	    [iGKTurnBasedMatch endMatchInTurnWithMatchData:data completionHandler:^(NSError* error)
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



void GKTurnBasedMatch_endMatchInTurnWithMatchData_leaderboardScores_achievements_completionHandler(
    void* ptr,
    const void* matchData, long matchDataLength,
    void* scores[],
	long scoresCount,
    void* achievements[],
	long achievementsCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        @try
        {
            GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
            NSData* data = [NSData dataWithBytes:matchData length:matchDataLength];
            [iGKTurnBasedMatch endMatchInTurnWithMatchData:data leaderboardScores:[Converters BridgedArray:scores withCount:scoresCount] achievements:[Converters BridgedArray:achievements withCount:achievementsCount] completionHandler:^(NSError* error)
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
}



void GKTurnBasedMatch_participantQuitInTurnWithOutcome_nextParticipants_turnTimeout_matchData_completionHandler(
    void* ptr,
    long matchOutcome,
    void* nextParticipants[],
	long nextParticipantsCount,
    double timeout,
    const void* matchData, long matchDataLength,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
        NSData* data = [NSData dataWithBytes:matchData length:matchDataLength];
	    [iGKTurnBasedMatch participantQuitInTurnWithOutcome:(GKTurnBasedMatchOutcome)matchOutcome nextParticipants:[Converters BridgedArray:nextParticipants withCount:nextParticipantsCount] turnTimeout:timeout matchData:data completionHandler:^(NSError* error)
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



void GKTurnBasedMatch_participantQuitOutOfTurnWithOutcome_withCompletionHandler(
    void* ptr,
    long matchOutcome,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch participantQuitOutOfTurnWithOutcome:(GKTurnBasedMatchOutcome)matchOutcome withCompletionHandler:^(NSError* error)
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



void GKTurnBasedMatch_removeWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch removeWithCompletionHandler:^(NSError* error)
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



void GKTurnBasedMatch_saveMergedMatchData_withResolvedExchanges_completionHandler(
    void* ptr,
    const void* matchData, long matchDataLength,
    void* exchanges[],
	long exchangesCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
        NSData* data = [NSData dataWithBytes:matchData length:matchDataLength];
	    [iGKTurnBasedMatch saveMergedMatchData:data withResolvedExchanges:[Converters BridgedArray:exchanges withCount:exchangesCount] completionHandler:^(NSError* error)
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



void GKTurnBasedMatch_sendExchangeToParticipants_data_localizableMessageKey_arguments_timeout_completionHandler(
    void* ptr,
    void* participants[],
	long participantsCount,
    const void* data, long dataLength,
    const char* key,
    const char* arguments[],
	long argumentsCount,
    double timeout,
    unsigned long invocationId, TurnBasedExchangeCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
        NSData* nsdata = [NSData dataWithBytes:data length:dataLength];
	    [iGKTurnBasedMatch sendExchangeToParticipants:[Converters BridgedArray:participants withCount:participantsCount] data:nsdata localizableMessageKey:[NSString stringWithUTF8String:key] arguments:[Converters StringArray:arguments withCount:argumentsCount] timeout:timeout completionHandler:^(GKTurnBasedExchange* match,
NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) match, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKTurnBasedMatch_sendReminderToParticipants_localizableMessageKey_arguments_completionHandler(
    void* ptr,
    void* participants[],
	long participantsCount,
    const char* key,
    const char* arguments[],
	long argumentsCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch sendReminderToParticipants:[Converters BridgedArray:participants withCount:participantsCount] localizableMessageKey:[NSString stringWithUTF8String:key] arguments:[Converters StringArray:arguments withCount:argumentsCount] completionHandler:^(NSError* error)
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



void GKTurnBasedMatch_setLocalizableMessageWithKey_arguments(
    void* ptr,
    const char* key,
    const char* arguments[],
	long argumentsCount,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	    [iGKTurnBasedMatch setLocalizableMessageWithKey:[NSString stringWithUTF8String:key] arguments:[Converters StringArray:arguments withCount:argumentsCount]];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



//VoidMethods
//Properties
const char* GKTurnBasedMatch_GetPropMessage(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSString* val = [iGKTurnBasedMatch message];
	return [val UTF8String];
}

void GKTurnBasedMatch_SetPropMessage(void* ptr, const char* message, void** exceptionPtr)
{
	@try
	{
		GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
		[iGKTurnBasedMatch setMessage:[NSString stringWithUTF8String:message]];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


double GKTurnBasedMatch_GetPropCreationDate(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSDate* val = [iGKTurnBasedMatch creationDate];
	return [val timeIntervalSince1970];
}


const char* GKTurnBasedMatch_GetPropMatchID(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSString* val = [iGKTurnBasedMatch matchID];
	return [val UTF8String];
}



void GKTurnBasedMatch_GetPropParticipants(void* ptr, void** buffer, long* count)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSArray<GKTurnBasedParticipant*>* val = [iGKTurnBasedMatch participants];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}
void* GKTurnBasedMatch_GetPropCurrentParticipant(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	GKTurnBasedParticipant* val = [iGKTurnBasedMatch currentParticipant];
	return (__bridge_retained void*) val;
}


uint GKTurnBasedMatch_GetPropMatchDataMaximumSize(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSUInteger val = [iGKTurnBasedMatch matchDataMaximumSize];
	return val;
}


long GKTurnBasedMatch_GetPropStatus(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	GKTurnBasedMatchStatus val = [iGKTurnBasedMatch status];
	return val;
}


void GKTurnBasedMatch_GetPropMatchData(void* ptr, const void** buffer, long* length)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSData* data = [iGKTurnBasedMatch matchData];
    *length = data.length;
    *buffer = [data bytes];
}



void GKTurnBasedMatch_GetPropActiveExchanges(void* ptr, void** buffer, long* count)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSArray<GKTurnBasedExchange*>* val = [iGKTurnBasedMatch activeExchanges];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}

void GKTurnBasedMatch_GetPropCompletedExchanges(void* ptr, void** buffer, long* count)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSArray<GKTurnBasedExchange*>* val = [iGKTurnBasedMatch completedExchanges];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}
uint GKTurnBasedMatch_GetPropExchangeDataMaximumSize(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSUInteger val = [iGKTurnBasedMatch exchangeDataMaximumSize];
	return val;
}


uint GKTurnBasedMatch_GetPropExchangeMaxInitiatedExchangesPerPlayer(void* ptr)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSUInteger val = [iGKTurnBasedMatch exchangeMaxInitiatedExchangesPerPlayer];
	return val;
}



void GKTurnBasedMatch_GetPropExchanges(void* ptr, void** buffer, long* count)
{
	GKTurnBasedMatch* iGKTurnBasedMatch = (__bridge GKTurnBasedMatch*) ptr;
	NSArray<GKTurnBasedExchange*>* val = [iGKTurnBasedMatch exchanges];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}


void GKTurnBasedMatch_Dispose(void* ptr)
{
    GKTurnBasedMatch* val = (__bridge GKTurnBasedMatch*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKTurnBasedMatch");
}

}
