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
//InitMethods
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
