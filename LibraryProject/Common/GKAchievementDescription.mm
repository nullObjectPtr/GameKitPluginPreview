//
//  GKAchievementDescription.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKAchievementDescription.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

const char* GKAchievementDescription_GetPropIdentifier(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	NSString* val = [iGKAchievementDescription identifier];
	return [val UTF8String];
}


const char* GKAchievementDescription_GetPropTitle(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	NSString* val = [iGKAchievementDescription title];
	return [val UTF8String];
}


const char* GKAchievementDescription_GetPropUnachievedDescription(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	NSString* val = [iGKAchievementDescription unachievedDescription];
	return [val UTF8String];
}


const char* GKAchievementDescription_GetPropAchievedDescription(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	NSString* val = [iGKAchievementDescription achievedDescription];
	return [val UTF8String];
}


NSInteger GKAchievementDescription_GetPropMaximumPoints(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	NSInteger val = [iGKAchievementDescription maximumPoints];
	return val;
}


bool GKAchievementDescription_GetPropHidden(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	BOOL val = [iGKAchievementDescription isHidden];
	return val;
}


bool GKAchievementDescription_GetPropReplayable(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	BOOL val = [iGKAchievementDescription isReplayable];
	return val;
}


const char* GKAchievementDescription_GetPropGroupIdentifier(void* ptr)
{
	GKAchievementDescription* iGKAchievementDescription = (__bridge GKAchievementDescription*) ptr;
	NSString* val = [iGKAchievementDescription groupIdentifier];
	return [val UTF8String];
}



void GKAchievementDescription_Dispose(void* ptr)
{
    GKAchievementDescription* val = (__bridge GKAchievementDescription*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKAchievementDescription");
}

}
