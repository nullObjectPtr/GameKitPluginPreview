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
