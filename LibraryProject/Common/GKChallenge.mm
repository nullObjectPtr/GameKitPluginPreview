//
//  GKChallenge.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKChallenge.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

void* GKChallenge_GetPropIssuingPlayer(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	GKPlayer* val = [iGKChallenge issuingPlayer];
	return (__bridge_retained void*) val;
}


void* GKChallenge_GetPropReceivingPlayer(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	GKPlayer* val = [iGKChallenge receivingPlayer];
	return (__bridge_retained void*) val;
}


const char* GKChallenge_GetPropMessage(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	NSString* val = [iGKChallenge message];
	return [val UTF8String];
}


long GKChallenge_GetPropState(void* ptr)
{
	GKChallenge* iGKChallenge = (__bridge GKChallenge*) ptr;
	GKChallengeState val = [iGKChallenge state];
	return val;
}



void GKChallenge_Dispose(void* ptr)
{
    GKChallenge* val = (__bridge GKChallenge*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKChallenge");
}

}
