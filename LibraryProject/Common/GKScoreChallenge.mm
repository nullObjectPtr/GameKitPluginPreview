//
//  GKScoreChallenge.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKScoreChallenge.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties

void* GKScoreChallenge_GetPropScore(void* ptr)
{
	GKScoreChallenge* iGKScoreChallenge = (__bridge GKScoreChallenge*) ptr;
	GKScore* val = [iGKScoreChallenge score];
	return (__bridge_retained void*) val;
}



void GKScoreChallenge_Dispose(void* ptr)
{
    GKScoreChallenge* val = (__bridge GKScoreChallenge*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKScoreChallenge");
}

}
