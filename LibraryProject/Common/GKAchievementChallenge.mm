//
//  GKAchievementChallenge.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKAchievementChallenge.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

void* GKAchievementChallenge_GetPropAchievement(void* ptr)
{
	GKAchievementChallenge* iGKAchievementChallenge = (__bridge GKAchievementChallenge*) ptr;
	GKAchievement* val = [iGKAchievementChallenge achievement];
	return (__bridge_retained void*) val;
}



void GKAchievementChallenge_Dispose(void* ptr)
{
    GKAchievementChallenge* val = (__bridge GKAchievementChallenge*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKAchievementChallenge");
}

}
