//
//  GKMatch.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKMatch.h"
#import "Converters.h"
#import "MatchDelegate.h"

extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
void GKMatch_disconnect(
    void* ptr,
    void** exception
    )
{
	@try 
	{
		GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
	    [iGKMatch disconnect];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



bool GKMatch_sendDataToAllPlayers_withDataMode_error(
    void* ptr,
    void* buffer,
    unsigned long length,
    unsigned long dataMode,
  void** error
)
{
    GKMatch* match = (__bridge GKMatch*) ptr;
    NSData* data = [NSData dataWithBytes:buffer length:(NSUInteger)length];
    NSError* anyError;
    BOOL val = [match sendDataToAllPlayers:data withDataMode:(GKMatchSendDataMode)dataMode error:&anyError];
    *error = (__bridge_retained void*) anyError;
    return val;
}


void GKMatch_chooseBestHostingPlayerWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, GKPlayerCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
	    [iGKMatch chooseBestHostingPlayerWithCompletionHandler:^(GKPlayer* player)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) player);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



void GKMatch_rematchWithCompletionHandler(
    void* ptr,
    unsigned long invocationId, MatchCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
	    [iGKMatch rematchWithCompletionHandler:^(GKMatch* match,
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



void* GKMatch_voiceChatWithName(
    void* ptr,
    const char* name,
    void** exception
    )
{
	@try 
	{
		GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
	    GKVoiceChat* val = [iGKMatch voiceChatWithName:[NSString stringWithUTF8String:name]];
	    return (__bridge_retained void*) val;
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	return nil;
}



bool GKMatch_sendData_toPlayers_dataMode_error(
    void* ptr,
    const void* buffer, long dataLength,
    void* players[],
	long playersCount,
    long mode,
    void** error
    )
{
    NSError* anyError;
    GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
    NSData* data = [NSData dataWithBytes:buffer length:(NSUInteger)dataLength];
    BOOL val = [iGKMatch sendData:data toPlayers:[Converters BridgedArray:players withCount:playersCount] dataMode:(GKMatchSendDataMode)mode error:&anyError];
    
    *error = (__bridge_retained void*) anyError;
    
    return val;
}


//VoidMethods
//Properties
void* GKMatch_GetPropDelegate(void* ptr)
{
	GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
	MatchDelegate* val = [iGKMatch delegate];
	return (__bridge_retained void*) val;
}

void GKMatch_SetPropDelegate(void* ptr, void* delegate, void** exceptionPtr)
{
	@try
	{
		GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
		[iGKMatch setDelegate:(__bridge MatchDelegate*) delegate];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


uint GKMatch_GetPropExpectedPlayerCount(void* ptr)
{
	GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
	NSUInteger val = [iGKMatch expectedPlayerCount];
	return val;
}



void GKMatch_GetPropPlayers(void* ptr, void** buffer, long* count)
{
	GKMatch* iGKMatch = (__bridge GKMatch*) ptr;
	NSArray<GKPlayer*>* val = [iGKMatch players];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}


void GKMatch_Dispose(void* ptr)
{
    GKMatch* val = (__bridge GKMatch*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKMatch");
}

}
