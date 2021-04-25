//
//  GKTurnBasedParticipant.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKTurnBasedParticipant.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties
void* GKTurnBasedParticipant_GetPropPlayer(void* ptr)
{
	GKTurnBasedParticipant* iGKTurnBasedParticipant = (__bridge GKTurnBasedParticipant*) ptr;
	GKPlayer* val = [iGKTurnBasedParticipant player];
	return (__bridge_retained void*) val;
}


long GKTurnBasedParticipant_GetPropStatus(void* ptr)
{
	GKTurnBasedParticipant* iGKTurnBasedParticipant = (__bridge GKTurnBasedParticipant*) ptr;
	GKTurnBasedParticipantStatus val = [iGKTurnBasedParticipant status];
	return val;
}


double GKTurnBasedParticipant_GetPropLastTurnDate(void* ptr)
{
	GKTurnBasedParticipant* iGKTurnBasedParticipant = (__bridge GKTurnBasedParticipant*) ptr;
	NSDate* val = [iGKTurnBasedParticipant lastTurnDate];
	return [val timeIntervalSince1970];
}


long GKTurnBasedParticipant_GetPropMatchOutcome(void* ptr)
{
	GKTurnBasedParticipant* iGKTurnBasedParticipant = (__bridge GKTurnBasedParticipant*) ptr;
	GKTurnBasedMatchOutcome val = [iGKTurnBasedParticipant matchOutcome];
	return val;
}

void GKTurnBasedParticipant_SetPropMatchOutcome(void* ptr, long matchOutcome, void** exceptionPtr)
{
	@try
	{
		GKTurnBasedParticipant* iGKTurnBasedParticipant = (__bridge GKTurnBasedParticipant*) ptr;
		[iGKTurnBasedParticipant setMatchOutcome:(GKTurnBasedMatchOutcome)matchOutcome];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}




void GKTurnBasedParticipant_Dispose(void* ptr)
{
    GKTurnBasedParticipant* val = (__bridge GKTurnBasedParticipant*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKTurnBasedParticipant");
}

}
