//
//  GKLocalPlayer.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKLocalPlayer.h"
#import "Converters.h"
#import "LocalPlayerListener.h"

extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
void GKLocalPlayer_registerListener(
    void* ptr,
    void* listener,
    void** exception
    )
{
	@try 
	{
		GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
	    [iGKLocalPlayer registerListener:(__bridge LocalPlayerListener*) listener];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKLocalPlayer_unregisterAllListeners(
    void* ptr,
    void** exception
    )
{
	@try 
	{
		GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
	    [iGKLocalPlayer unregisterAllListeners];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKLocalPlayer_unregisterListener(
    void* ptr,
    void* listener,
    void** exception
    )
{
	@try 
	{
		GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
	    [iGKLocalPlayer unregisterListener:(__bridge LocalPlayerListener*) listener];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKLocalPlayer_loadRecentPlayersWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, LoadRecentPlayersWithCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
	    [iGKLocalPlayer loadRecentPlayersWithCompletionHandler:^(NSArray<GKPlayer*>* recentPlayers,
NSError* error)
		{
			long recentPlayersCount = [recentPlayers count];
			void** recentPlayersBuffer = (void**) malloc(sizeof(void*) * recentPlayersCount);
			[Converters NSArrayToRetainedCArray:recentPlayers withBuffer:recentPlayersBuffer];
			completionHandler(ptr, invocationId, recentPlayersBuffer, recentPlayersCount, (__bridge_retained void*) error);
			free(recentPlayersBuffer);
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKLocalPlayer_loadChallengableFriendsWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, LoadChallengableFriendsWithCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
	    [iGKLocalPlayer loadChallengableFriendsWithCompletionHandler:^(NSArray<GKPlayer*>* recentPlayers,
NSError* error)
		{
			long recentPlayersCount = [recentPlayers count];
			void** recentPlayersBuffer = (void**) malloc(sizeof(void*) * recentPlayersCount);
			[Converters NSArrayToRetainedCArray:recentPlayers withBuffer:recentPlayersBuffer];
			completionHandler(ptr, invocationId, recentPlayersBuffer, recentPlayersCount, (__bridge_retained void*) error);
			free(recentPlayersBuffer);
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
void GKLocalPlayer_SetPropAuthenticateHandler(void* ptr, AuthenticateHandler authenticateHandler, void** exceptionPtr)
{
	@try 
	{
#if TARGET_OS_OSX
        GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
        [iGKLocalPlayer setAuthenticateHandler:^(NSViewController* viewController, NSError* error)
        {
            
            authenticateHandler(ptr, (__bridge_retained void*) viewController, (__bridge_retained void*) error);
            
        }];
#else
		GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
		[iGKLocalPlayer setAuthenticateHandler:^(UIViewController* viewController,
	NSError* error)
			{
				
				authenticateHandler(ptr, (__bridge_retained void*) viewController, (__bridge_retained void*) error);
				
			}];
#endif
	}
	@catch(NSException* ex)
	{
		*exceptionPtr = (__bridge_retained void*)ex;
	}
}

void* GKLocalPlayer_GetPropLocalPlayer()
{
	GKLocalPlayer* val = [GKLocalPlayer localPlayer];
	return (__bridge_retained void*) val;
}


void* GKLocalPlayer_GetPropLocal()
{
	GKLocalPlayer* val = [GKLocalPlayer local];
	return (__bridge_retained void*) val;
}


bool GKLocalPlayer_GetPropAuthenticated(void* ptr)
{
	GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
	BOOL val = [iGKLocalPlayer isAuthenticated];
	return val;
}


bool GKLocalPlayer_GetPropUnderage(void* ptr)
{
	GKLocalPlayer* iGKLocalPlayer = (__bridge GKLocalPlayer*) ptr;
	BOOL val = [iGKLocalPlayer isUnderage];
	return val;
}



void GKLocalPlayer_Dispose(void* ptr)
{
    GKLocalPlayer* val = (__bridge GKLocalPlayer*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKLocalPlayer");
}

}
