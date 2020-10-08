//
//  GKTurnBasedExchange.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKTurnBasedExchange.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

const char* GKTurnBasedExchange_GetPropExchangeID(void* ptr)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	NSString* val = [iGKTurnBasedExchange exchangeID];
	return [val UTF8String];
}


const char* GKTurnBasedExchange_GetPropMessage(void* ptr)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	NSString* val = [iGKTurnBasedExchange message];
	return [val UTF8String];
}


void* GKTurnBasedExchange_GetPropSender(void* ptr)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	GKTurnBasedParticipant* val = [iGKTurnBasedExchange sender];
	return (__bridge_retained void*) val;
}



void GKTurnBasedExchange_Dispose(void* ptr)
{
    GKTurnBasedExchange* val = (__bridge GKTurnBasedExchange*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKTurnBasedExchange");
}

}
