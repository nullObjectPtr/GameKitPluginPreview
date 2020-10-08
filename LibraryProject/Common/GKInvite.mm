//
//  GKInvite.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKInvite.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

uint GKInvite_GetPropPlayerGroup(void* ptr)
{
	GKInvite* iGKInvite = (__bridge GKInvite*) ptr;
	NSUInteger val = [iGKInvite playerGroup];
	return val;
}


void* GKInvite_GetPropSender(void* ptr)
{
	GKInvite* iGKInvite = (__bridge GKInvite*) ptr;
	GKPlayer* val = [iGKInvite sender];
	return (__bridge_retained void*) val;
}


bool GKInvite_GetPropHosted(void* ptr)
{
	GKInvite* iGKInvite = (__bridge GKInvite*) ptr;
	BOOL val = [iGKInvite isHosted];
	return val;
}



void GKInvite_Dispose(void* ptr)
{
    GKInvite* val = (__bridge GKInvite*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKInvite");
}

}
