//
//  GKVoiceChat.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKVoiceChat.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
bool GKVoiceChat_isVoIPAllowed(
	void** exception
    )
{
	@try {
		NSLog(@"GKVoiceChat_isVoIPAllowed()");
	    BOOL val = [GKVoiceChat isVoIPAllowed];
		return val;
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}

	return nil;
}

void GKVoiceChat_start(
    void* ptr,
    void** exception
    )
{
	@try 
	{
		GKVoiceChat* iGKVoiceChat = (__bridge GKVoiceChat*) ptr;
	    [iGKVoiceChat start];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKVoiceChat_stop(
    void* ptr,
    void** exception
    )
{
	@try 
	{
		GKVoiceChat* iGKVoiceChat = (__bridge GKVoiceChat*) ptr;
	    [iGKVoiceChat stop];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKVoiceChat_setPlayer_muted(
    void* ptr,
    void* player,
    bool isMuted,
    void** exception
    )
{
	@try 
	{
		GKVoiceChat* iGKVoiceChat = (__bridge GKVoiceChat*) ptr;
	    [iGKVoiceChat setPlayer:(__bridge GKPlayer*) player muted:isMuted];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



//VoidMethods
//Properties

bool GKVoiceChat_GetPropActive(void* ptr)
{
	GKVoiceChat* iGKVoiceChat = (__bridge GKVoiceChat*) ptr;
	BOOL val = [iGKVoiceChat isActive];
	return val;
}

void GKVoiceChat_SetPropActive(void* ptr, bool active, void** exceptionPtr)
{
	@try 
	{
		GKVoiceChat* iGKVoiceChat = (__bridge GKVoiceChat*) ptr;
		[iGKVoiceChat setActive:active];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


const char* GKVoiceChat_GetPropName(void* ptr)
{
	GKVoiceChat* iGKVoiceChat = (__bridge GKVoiceChat*) ptr;
	NSString* val = [iGKVoiceChat name];
	return [val UTF8String];
}


void GKVoiceChat_GetPropPlayers(void* ptr, void** buffer, long* count)
{
	GKVoiceChat* iGKVoiceChat = (__bridge GKVoiceChat*) ptr;
	NSArray<GKPlayer*>* val = [iGKVoiceChat players];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}


void GKVoiceChat_Dispose(void* ptr)
{
    GKVoiceChat* val = (__bridge GKVoiceChat*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKVoiceChat");
}

}
