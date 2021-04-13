//
//  GKGameCenterViewController.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKGameCenterViewController.h"
#import "Converters.h"
#import "GKGameCenterControllerDelegate.h"

extern "C" {

//ClassMethods
//InitMethods
void* GKGameCenterViewController_initWithState(
    long state,
    void** exceptionPtr)
{
    if(@available(macOS 11, tvOS 14, iOS 14, *))
    {
        @try
        {
            GKGameCenterViewController* iGKGameCenterViewController = [[GKGameCenterViewController alloc] initWithState:(GKGameCenterViewControllerState)state];
                return (__bridge_retained void*) iGKGameCenterViewController;
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*)ex;
        }
    }

    return nil;
}

void* GKGameCenterViewController_initWithAchievementID(
    const char* achievementID,
    void** exceptionPtr)
{
    if(@available(macOS 11, tvOS 14, iOS 14, *))
    {
        @try
        {
            GKGameCenterViewController* iGKGameCenterViewController = [[GKGameCenterViewController alloc] initWithAchievementID:[NSString stringWithUTF8String:achievementID]];
                return (__bridge_retained void*) iGKGameCenterViewController;
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*)ex;
        }
    }

    return nil;
}

void* GKGameCenterViewController_initWithLeaderboard_playerScope(
    void* leaderboard,
    long playerScope,
    void** exceptionPtr)
{
    if(@available(macOS 11, tvOS 14, iOS 14, *))
    {
        @try
        {
            GKGameCenterViewController* iGKGameCenterViewController = [[GKGameCenterViewController alloc] initWithLeaderboard:(__bridge GKLeaderboard*) leaderboard playerScope:(GKLeaderboardPlayerScope)playerScope];
                return (__bridge_retained void*) iGKGameCenterViewController;
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*)ex;
        }
    }

    return nil;
}

void* GKGameCenterViewController_initWithLeaderboardID_playerScope_timeScope(
    const char* leaderboardID,
    long playerScope,
    long timeScope,
    void** exceptionPtr)
{
    if(@available(macOS 11, tvOS 14, iOS 14, *))
    {
        @try
        {
            GKGameCenterViewController* iGKGameCenterViewController = [[GKGameCenterViewController alloc] initWithLeaderboardID:[NSString stringWithUTF8String:leaderboardID] playerScope:(GKLeaderboardPlayerScope)playerScope timeScope:(GKLeaderboardTimeScope)timeScope];
                return (__bridge_retained void*) iGKGameCenterViewController;
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*)ex;
        }
    }

    return nil;
}

void* GKGameCenterViewController_registerDidFinish(const void* ptr)
{
    id iGKGameCenterViewController = (__bridge GKGameCenterViewController*) ptr;
    id del = [[MyGameCenterControllerDelegate alloc] initWithController:iGKGameCenterViewController];
    [iGKGameCenterViewController setGameCenterDelegate:del];
    return (__bridge_retained void*) del;
}

void GKGameCenterViewController_unregisterDidFinish(const void* ptr)
{
    id iGKGameCenterViewController = (__bridge GKGameCenterViewController*) ptr;
    id del = [iGKGameCenterViewController gameCenterDelegate];
    if(del != nil)
    {
        CFRelease((__bridge void*) del);
    }
    [iGKGameCenterViewController setGameCenterDelegate:nil];
}

//InstanceMethods
//VoidMethods
//Properties

void GKGameCenterViewController_Dispose(void* ptr)
{
    GKGameCenterViewController* val = (__bridge GKGameCenterViewController*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKGameCenterViewController");
}

}
