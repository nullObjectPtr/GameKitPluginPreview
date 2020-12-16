//
//  GKPlayer.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKPlayer.h"
#import "Converters.h"


extern "C" {

//ClassMethods
void GKPlayer_loadPlayersForIdentifiers_withCompletionHandler(
	const char* identifiers[],
	long identifiersCount, 
	unsigned long invocationId, LoadPlayersForIdentifierCallback completionHandler, 
	void** exception
    )
{
	@try {
		NSLog(@"GKPlayer_loadPlayersForIdentifiers_withCompletionHandler()");
	    [GKPlayer loadPlayersForIdentifiers:[Converters StringArray:identifiers withCount:identifiersCount] withCompletionHandler:^(NSArray<GKPlayer*>* players,
NSError* error)
		{
			long playersCount = [players count];
			void** playersBuffer = (void**) malloc(sizeof(void*) * playersCount);
			[Converters NSArrayToRetainedCArray:players withBuffer:playersBuffer];
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



//InitMethods
void* GKPlayer_anonymousGuestPlayerWithIdentifier(
    const char* guestIdentifier,
    void** exceptionPtr)
{
    @try 
    {
        GKPlayer* iGKPlayer = [GKPlayer anonymousGuestPlayerWithIdentifier:[NSString stringWithUTF8String:guestIdentifier]];
            return (__bridge_retained void*) iGKPlayer;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

//InstanceMethods
bool GKPlayer_scopedIDsArePersistent(
    void* ptr,
    void** exception
    )
{
	@try 
	{
		GKPlayer* iGKPlayer = (__bridge GKPlayer*) ptr;
	    BOOL val = [iGKPlayer scopedIDsArePersistent];
	    return val;
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	return NO;
}



//VoidMethods
//Properties
const char* GKPlayer_GetPropGamePlayerID(void* ptr)
{
	GKPlayer* iGKPlayer = (__bridge GKPlayer*) ptr;
	NSString* val = [iGKPlayer gamePlayerID];
	return [val UTF8String];
}


const char* GKPlayer_GetPropTeamPlayerID(void* ptr)
{
	GKPlayer* iGKPlayer = (__bridge GKPlayer*) ptr;
	NSString* val = [iGKPlayer teamPlayerID];
	return [val UTF8String];
}


const char* GKPlayer_GetPropAlias(void* ptr)
{
	GKPlayer* iGKPlayer = (__bridge GKPlayer*) ptr;
	NSString* val = [iGKPlayer alias];
	return [val UTF8String];
}


const char* GKPlayer_GetPropDisplayName(void* ptr)
{
	GKPlayer* iGKPlayer = (__bridge GKPlayer*) ptr;
	NSString* val = [iGKPlayer displayName];
	return [val UTF8String];
}


const char* GKPlayer_GetPropGuestIdentifier(void* ptr)
{
	GKPlayer* iGKPlayer = (__bridge GKPlayer*) ptr;
	NSString* val = [iGKPlayer guestIdentifier];
	return [val UTF8String];
}


#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
bool GKPlayer_GetPropIsInvitable(void* ptr)
{
	GKPlayer* iGKPlayer = (__bridge GKPlayer*) ptr;
	BOOL val = [iGKPlayer isInvitable];
	return val;
}
#endif



void GKPlayer_Dispose(void* ptr)
{
    GKPlayer* val = (__bridge GKPlayer*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKPlayer");
}

}
