//
//  GKTurnBasedExchangeReply.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKTurnBasedExchangeReply.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties
const char* GKTurnBasedExchangeReply_GetPropMessage(void* ptr)
{
	GKTurnBasedExchangeReply* iGKTurnBasedExchangeReply = (__bridge GKTurnBasedExchangeReply*) ptr;
	NSString* val = [iGKTurnBasedExchangeReply message];
	return [val UTF8String];
}


double GKTurnBasedExchangeReply_GetPropReplyDate(void* ptr)
{
	GKTurnBasedExchangeReply* iGKTurnBasedExchangeReply = (__bridge GKTurnBasedExchangeReply*) ptr;
	NSDate* val = [iGKTurnBasedExchangeReply replyDate];
	return [val timeIntervalSince1970];
}


void* GKTurnBasedExchangeReply_GetPropRecipient(void* ptr)
{
	GKTurnBasedExchangeReply* iGKTurnBasedExchangeReply = (__bridge GKTurnBasedExchangeReply*) ptr;
	GKTurnBasedParticipant* val = [iGKTurnBasedExchangeReply recipient];
	return (__bridge_retained void*) val;
}




void GKTurnBasedExchangeReply_Dispose(void* ptr)
{
    GKTurnBasedExchangeReply* val = (__bridge GKTurnBasedExchangeReply*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKTurnBasedExchangeReply");
}

}
