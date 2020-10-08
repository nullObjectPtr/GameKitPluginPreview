//
//  GKTurnBasedMatch.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKTurnBasedMatch.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties


void GKTurnBasedMatch_Dispose(void* ptr)
{
    GKTurnBasedMatch* val = (__bridge GKTurnBasedMatch*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKTurnBasedMatch");
}

}
