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
uint GKLeaderboardEntry_GetPropContext(void* ptr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14, *))
    { 
        GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
        NSUInteger val = [iGKLeaderboardEntry context];
        return val;
    }
    else
    {
        return 0;
    } 
}

double GKLeaderboardEntry_GetPropDate(void* ptr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14,  *))
    { 
        GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
        NSDate* val = [iGKLeaderboardEntry date];
        return [val timeIntervalSince1970];
    }
    else
    {
        return 0.0;
    } 
}

const char* GKLeaderboardEntry_GetPropFormattedScore(void* ptr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14,  *))
    { 
        GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
        NSString* val = [iGKLeaderboardEntry formattedScore];
        return [val UTF8String];
    }
    else
    {
        return nil;
    } 
}

void* GKLeaderboardEntry_GetPropPlayer(void* ptr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14,  *))
    { 
        GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
        GKPlayer* val = [iGKLeaderboardEntry player];
        return (__bridge_retained void*) val;
    }
    else
    {
        return nil;
    } 
}

NSInteger GKLeaderboardEntry_GetPropRank(void* ptr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14,  *))
    { 
        GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
        NSInteger val = [iGKLeaderboardEntry rank];
        return val;
    }
    else
    {
        return 0;
    } 
}

NSInteger GKLeaderboardEntry_GetPropScore(void* ptr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14,  *))
    { 
        GKLeaderboardEntry* iGKLeaderboardEntry = (__bridge GKLeaderboardEntry*) ptr;
        NSInteger val = [iGKLeaderboardEntry score];
        return val;
    }
    else
    {
        return 0;
    } 
}



void GKLeaderboardEntry_Dispose(void* ptr)
{
    if(@available(macOS 11, iOS 14, tvOS 14, *))
    {
        GKLeaderboardEntry* val = (__bridge GKLeaderboardEntry*) ptr;
        if(val != nil)
        {
            CFRelease(ptr);
        }
        //NSLog(@"Dispose...GKLeaderboardEntry");
    }
}

}
