//
//  GKMatchmaker.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKMatchmaker.h"
#import "Converters.h"


extern "C" {

//ClassMethods
void* GKMatchmaker_sharedMatchmaker(
	void** exception
    )
{
	@try {
		NSLog(@"GKMatchmaker_sharedMatchmaker()");
	    GKMatchmaker* val = [GKMatchmaker sharedMatchmaker];
		return (__bridge_retained void*) val;
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	return nil;
}

//InitMethods
//InstanceMethods
void GKMatchmaker_cancel(
    void* ptr,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker cancel];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_cancelPendingInviteToPlayer(
    void* ptr,
    void* player,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker cancelPendingInviteToPlayer:(__bridge GKPlayer*) player];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_stopBrowsingForNearbyPlayers(
    void* ptr,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker stopBrowsingForNearbyPlayers];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_finishMatchmakingForMatch(
    void* ptr,
    void* match,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker finishMatchmakingForMatch:(__bridge GKMatch*) match];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_startBrowsingForNearbyPlayersWithHandler(
    void* ptr,
    unsigned long invocationId, StartBrowsingForNearbyPlayersCallback reachableHandler,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker startBrowsingForNearbyPlayersWithHandler:^(GKPlayer* player,
BOOL reachable)
		{
			
			reachableHandler(ptr, invocationId, (__bridge_retained void*) player, reachable);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_findMatchForRequest_withCompletionHandler(
    void* ptr,
    void* request,
    unsigned long invocationId, FindMatchForRequestCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker findMatchForRequest:(__bridge GKMatchRequest*) request withCompletionHandler:^(GKMatch* match,
NSError* error)
		{
			
			completionHandler(ptr, invocationId, (__bridge_retained void*) match, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_matchForInvite_completionHandler(
    void* ptr,
    void* invite,
    unsigned long invocationId, MatchCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker matchForInvite:(__bridge GKInvite*) invite completionHandler:^(GKMatch* match,
NSError* error)
		{
			
			completionHandler(ptr, invocationId, (__bridge_retained void*) match, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_addPlayersToMatch_matchRequest_completionHandler(
    void* ptr,
    void* match,
    void* matchRequest,
    unsigned long invocationId, CompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker addPlayersToMatch:(__bridge GKMatch*) match matchRequest:(__bridge GKMatchRequest*) matchRequest completionHandler:^(NSError* error)
		{
			
			completionHandler(ptr, invocationId, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_findPlayersForHostedRequest_withCompletionHandler(
    void* ptr,
    void* request,
    unsigned long invocationId, FindPlayersForHostedRequestCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker findPlayersForHostedRequest:(__bridge GKMatchRequest*) request withCompletionHandler:^(NSArray<GKPlayer*>* players,
NSError* error)
		{
			long playersCount = [players count];
			void** playersBuffer = (void**) malloc(sizeof(void*) * playersCount);
			[Converters NSArrayToRetainedCArray:players withBuffer:playersBuffer];
			completionHandler(ptr, invocationId, playersBuffer, playersCount, (__bridge_retained void*) error);
			free(playersBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_queryActivityWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, QueryActivityCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker queryActivityWithCompletionHandler:^(NSInteger activity,
NSError* error)
		{
			
			completionHandler(ptr, invocationId, activity, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatchmaker_queryPlayerGroupActivity_withCompletionHandler(
    void* ptr,
    uint playerGroup,
    unsigned long invocationId, QueryActivityCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatchmaker* iGKMatchmaker = (__bridge GKMatchmaker*) ptr;
	    [iGKMatchmaker queryPlayerGroupActivity:playerGroup withCompletionHandler:^(NSInteger activity,
NSError* error)
		{
			
			completionHandler(ptr, invocationId, activity, (__bridge_retained void*) error);
			
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


void GKMatchmaker_Dispose(void* ptr)
{
    GKMatchmaker* val = (__bridge GKMatchmaker*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKMatchmaker");
}

}
