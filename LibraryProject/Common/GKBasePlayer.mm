//
//  GKBasePlayer.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKBasePlayer.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties
const char* GKBasePlayer_GetPropDisplayName(void* ptr)
{
	GKBasePlayer* iGKBasePlayer = (__bridge GKBasePlayer*) ptr;
	NSString* val = [iGKBasePlayer displayName];
	return [val UTF8String];
}


const char* GKBasePlayer_GetPropPlayerID(void* ptr)
{
	GKBasePlayer* iGKBasePlayer = (__bridge GKBasePlayer*) ptr;
	NSString* val = [iGKBasePlayer playerID];
	return [val UTF8String];
}




void GKBasePlayer_Dispose(void* ptr)
{
    GKBasePlayer* val = (__bridge GKBasePlayer*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKBasePlayer");
}

}
