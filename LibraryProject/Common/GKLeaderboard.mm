//
//  GKLeaderboard.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKLeaderboard.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

const char* GKLeaderboard_GetPropTitle(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSString* val = [iGKLeaderboard title];
	return [val UTF8String];
}


const char* GKLeaderboard_GetPropGroupIdentifier(void* ptr)
{
	GKLeaderboard* iGKLeaderboard = (__bridge GKLeaderboard*) ptr;
	NSString* val = [iGKLeaderboard groupIdentifier];
	return [val UTF8String];
}



void GKLeaderboard_Dispose(void* ptr)
{
    GKLeaderboard* val = (__bridge GKLeaderboard*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKLeaderboard");
}

}
