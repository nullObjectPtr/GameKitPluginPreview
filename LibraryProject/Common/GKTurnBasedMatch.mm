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
