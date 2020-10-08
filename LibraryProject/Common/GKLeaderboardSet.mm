//
//  GKLeaderboardSet.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKLeaderboardSet.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

const char* GKLeaderboardSet_GetPropTitle(void* ptr)
{
	GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
	NSString* val = [iGKLeaderboardSet title];
	return [val UTF8String];
}


const char* GKLeaderboardSet_GetPropIdentifier(void* ptr)
{
	GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
	NSString* val = [iGKLeaderboardSet identifier];
	return [val UTF8String];
}

void GKLeaderboardSet_SetPropIdentifier(void* ptr, const char* identifier, void** exceptionPtr)
{
	@try 
	{
		GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
		[iGKLeaderboardSet setIdentifier:[NSString stringWithUTF8String:identifier]];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


const char* GKLeaderboardSet_GetPropGroupIdentifier(void* ptr)
{
	GKLeaderboardSet* iGKLeaderboardSet = (__bridge GKLeaderboardSet*) ptr;
	NSString* val = [iGKLeaderboardSet groupIdentifier];
	return [val UTF8String];
}



void GKLeaderboardSet_Dispose(void* ptr)
{
    GKLeaderboardSet* val = (__bridge GKLeaderboardSet*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKLeaderboardSet");
}

}
