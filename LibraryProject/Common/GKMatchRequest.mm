//
//  GKMatchRequest.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKMatchRequest.h"
#import "Converters.h"


extern "C" {

//ClassMethods
uint GKMatchRequest_maxPlayersAllowedForMatchOfType(
	long matchType, 
	void** exception
    )
{
	@try {
		NSLog(@"GKMatchRequest_maxPlayersAllowedForMatchOfType()");
	    NSUInteger val = [GKMatchRequest maxPlayersAllowedForMatchOfType:(GKMatchType)matchType];
		return (uint)val;
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	return -1;
}

//InitMethods
void* GKMatchRequest_init(
    void** exceptionPtr)
{
    @try 
    {
        GKMatchRequest* iGKMatchRequest = [[GKMatchRequest alloc] init];
            return (__bridge_retained void*) iGKMatchRequest;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

//InstanceMethods
//VoidMethods
//Properties
uint GKMatchRequest_GetPropMaxPlayers(void* ptr)
{
	GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
	NSUInteger val = [iGKMatchRequest maxPlayers];
	return val;
}

void GKMatchRequest_SetPropMaxPlayers(void* ptr, uint maxPlayers, void** exceptionPtr)
{
	@try
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setMaxPlayers:maxPlayers];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


uint GKMatchRequest_GetPropMinPlayers(void* ptr)
{
	GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
	NSUInteger val = [iGKMatchRequest minPlayers];
	return val;
}

void GKMatchRequest_SetPropMinPlayers(void* ptr, uint minPlayers, void** exceptionPtr)
{
	@try
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setMinPlayers:minPlayers];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


uint GKMatchRequest_GetPropDefaultNumberOfPlayers(void* ptr)
{
	GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
	NSUInteger val = [iGKMatchRequest defaultNumberOfPlayers];
	return val;
}

void GKMatchRequest_SetPropDefaultNumberOfPlayers(void* ptr, uint defaultNumberOfPlayers, void** exceptionPtr)
{
	@try
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setDefaultNumberOfPlayers:defaultNumberOfPlayers];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


const char* GKMatchRequest_GetPropInviteMessage(void* ptr)
{
	GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
	NSString* val = [iGKMatchRequest inviteMessage];
	return [val UTF8String];
}

void GKMatchRequest_SetPropInviteMessage(void* ptr, const char* inviteMessage, void** exceptionPtr)
{
	@try
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setInviteMessage:[NSString stringWithUTF8String:inviteMessage]];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


uint GKMatchRequest_GetPropPlayerGroup(void* ptr)
{
	GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
	NSUInteger val = [iGKMatchRequest playerGroup];
	return val;
}

void GKMatchRequest_SetPropPlayerGroup(void* ptr, uint playerGroup, void** exceptionPtr)
{
	@try
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setPlayerGroup:playerGroup];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


void GKMatchRequest_SetPropRecipientResponseHandler(void* ptr, RecipientResponseHandler recipientResponseHandler, void** exceptionPtr)
{
	@try 
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setRecipientResponseHandler:^(GKPlayer* player,
	GKInviteRecipientResponse response)
			{
				
				recipientResponseHandler(ptr, (__bridge_retained void*) player, response);
				
			}];
	}
	@catch(NSException* ex)
	{
		*exceptionPtr = (__bridge_retained void*)ex;
	}
}


void GKMatchRequest_GetPropRecipients(void* ptr, void** buffer, long* count)
{
	GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
	NSArray<GKPlayer*>* val = [iGKMatchRequest recipients];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}

void GKMatchRequest_SetPropRecipients(void* ptr, void* recipients[],
	long recipientsCount, void** exceptionPtr)
{
	@try 
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setRecipients:[Converters BridgedArray:recipients withCount:recipientsCount]];
	}
	@catch(NSException* ex)
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}
uint32_t GKMatchRequest_GetPropPlayerAttributes(void* ptr)
{
	GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
	uint32_t val = [iGKMatchRequest playerAttributes];
	return val;
}

void GKMatchRequest_SetPropPlayerAttributes(void* ptr, uint32_t playerAttributes, void** exceptionPtr)
{
	@try
	{
		GKMatchRequest* iGKMatchRequest = (__bridge GKMatchRequest*) ptr;
		[iGKMatchRequest setPlayerAttributes:playerAttributes];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}




void GKMatchRequest_Dispose(void* ptr)
{
    GKMatchRequest* val = (__bridge GKMatchRequest*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKMatchRequest");
}

}
