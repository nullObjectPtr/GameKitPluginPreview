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
void GKTurnBasedExchange_cancelWithLocalizableMessageKey_arguments_completionHandler(
    void* ptr,
    const char* key,
    const char* arguments[],
	long argumentsCount,
    unsigned long invocationId, StaticCompletionCallback completionHandler,
    void** exception
    )
{
	@try 
	{
		GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	    [iGKTurnBasedExchange cancelWithLocalizableMessageKey:[NSString stringWithUTF8String:key] arguments:[Converters StringArray:arguments withCount:argumentsCount] completionHandler:^(NSError* error)
		{
			
			completionHandler(invocationId, (__bridge_retained void*) error);
			
		}
];
	}
	@catch(NSException* ex)
	{
		*exception = (__bridge_retained void*) ex;
	}
	
}



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


double GKTurnBasedExchange_GetPropCompletionDate(void* ptr)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	NSDate* val = [iGKTurnBasedExchange completionDate];
	return [val timeIntervalSince1970];
}


double GKTurnBasedExchange_GetPropSendDate(void* ptr)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	NSDate* val = [iGKTurnBasedExchange sendDate];
	return [val timeIntervalSince1970];
}


double GKTurnBasedExchange_GetPropTimeoutDate(void* ptr)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	NSDate* val = [iGKTurnBasedExchange timeoutDate];
	return [val timeIntervalSince1970];
}



void GKTurnBasedExchange_GetPropRecipients(void* ptr, void** buffer, long* count)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	NSArray<GKTurnBasedParticipant*>* val = [iGKTurnBasedExchange recipients];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}

void GKTurnBasedExchange_GetPropReplies(void* ptr, void** buffer, long* count)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	NSArray<GKTurnBasedExchangeReply*>* val = [iGKTurnBasedExchange replies];

	*buffer = [Converters NSArrayToRetainedCArray:val];
	*count = [val count];
}
long GKTurnBasedExchange_GetPropStatus(void* ptr)
{
	GKTurnBasedExchange* iGKTurnBasedExchange = (__bridge GKTurnBasedExchange*) ptr;
	GKTurnBasedExchangeStatus val = [iGKTurnBasedExchange status];
	return val;
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
