//
//  GKLeaderboardScore.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKLeaderboardScore.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties
uint GKLeaderboardScore_GetPropContext(void* ptr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
        NSUInteger val = [iGKLeaderboardScore context];
        return val;
    }
    else
    {
        return 0;
    }
}

void GKLeaderboardScore_SetPropContext(void* ptr, uint context, void** exceptionPtr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        @try
        {
            GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
            [iGKLeaderboardScore setContext:context];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}

const char* GKLeaderboardScore_GetPropLeaderboardID(void* ptr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
        NSString* val = [iGKLeaderboardScore leaderboardID];
        return [val UTF8String];
    }
    else
    {
        return nil;
    }
}

void GKLeaderboardScore_SetPropLeaderboardID(void* ptr, const char* leaderboardID, void** exceptionPtr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        @try
        {
            GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
            [iGKLeaderboardScore setLeaderboardID:[NSString stringWithUTF8String:leaderboardID]];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}

void* GKLeaderboardScore_GetPropPlayer(void* ptr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
        GKPlayer* val = [iGKLeaderboardScore player];
        return (__bridge_retained void*) val;
    }
    else
    {
        return nil;
    }
}

void GKLeaderboardScore_SetPropPlayer(void* ptr, void* player, void** exceptionPtr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        @try
        {
            GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
            [iGKLeaderboardScore setPlayer:(__bridge GKPlayer*) player];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}

NSInteger GKLeaderboardScore_GetPropValue(void* ptr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
        NSInteger val = [iGKLeaderboardScore value];
        return val;
    }
    else
    {
        return 0;
    }
}

void GKLeaderboardScore_SetPropValue(void* ptr, NSInteger value, void** exceptionPtr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        @try
        {
            GKLeaderboardScore* iGKLeaderboardScore = (__bridge GKLeaderboardScore*) ptr;
            [iGKLeaderboardScore setValue:value];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}



void GKLeaderboardScore_Dispose(void* ptr)
{
    if(@available(macOS 10.16, iOS 14, tvOS 14, *))
    {
        GKLeaderboardScore* val = (__bridge GKLeaderboardScore*) ptr;
        if(val != nil)
        {
            CFRelease(ptr);
        }
        //NSLog(@"Dispose...GKLeaderboardScore");
    }
}

}
