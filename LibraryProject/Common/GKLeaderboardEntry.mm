//
//  GKLeaderboardEntry.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKLeaderboardEntry.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties
#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 101500) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 130000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 130000)
uint GKLeaderboardEntry_GetPropContext(void* ptr)
{
	GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
	NSUInteger val = [iGKLeaderboardEntry context];
	return val;
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
double GKLeaderboardEntry_GetPropDate(void* ptr)
{
	GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
	NSDate* val = [iGKLeaderboardEntry date];
	return [val timeIntervalSince1970];
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
const char* GKLeaderboardEntry_GetPropFormattedScore(void* ptr)
{
	GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
	NSString* val = [iGKLeaderboardEntry formattedScore];
	return [val UTF8String];
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
void* GKLeaderboardEntry_GetPropPlayer(void* ptr)
{
	GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
	GKPlayer* val = [iGKLeaderboardEntry player];
	return (__bridge_retained void*) val;
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
NSInteger GKLeaderboardEntry_GetPropRank(void* ptr)
{
	GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
	NSInteger val = [iGKLeaderboardEntry rank];
	return val;
}
#endif

#if (defined(__MAC_OS_X_VERSION_MIN_REQUIRED) && __MAC_OS_X_VERSION_MIN_REQUIRED >= 110000) || (defined(__IPHONE_OS_VERSION_MIN_REQUIRED) && __IPHONE_OS_VERSION_MIN_REQUIRED >= 140000) || (defined(__TV_OS_VERSION_MIN_REQUIRED) && __TV_OS_VERSION_MIN_REQUIRED >= 140000)
NSInteger GKLeaderboardEntry_GetPropScore(void* ptr)
{
	GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
	NSInteger val = [iGKLeaderboardEntry score];
	return val;
}
#endif



void GKLeaderboardEntry_Dispose(void* ptr)
{
    GKLeaderboardEntry* val = (__bridge GKLeaderboardEntry*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKLeaderboardEntry");
}

}
