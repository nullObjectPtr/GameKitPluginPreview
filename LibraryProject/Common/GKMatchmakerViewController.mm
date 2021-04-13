//
//  GKMatchmakerViewController.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKMatchmakerViewController.h"
#import "Converters.h"
#import "MatchmakerViewControllerDelegate.h"

extern "C" {

//ClassMethods
//InitMethods
void* GKMatchmakerViewController_initWithMatchRequest(
    void* request,
    void** exceptionPtr)
{
    @try 
    {
        GKMatchmakerViewController* iGKMatchmakerViewController = [[GKMatchmakerViewController alloc] initWithMatchRequest:(__bridge GKMatchRequest*) request];
            return (__bridge_retained void*) iGKMatchmakerViewController;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void* GKMatchmakerViewController_initWithInvite(
    void* invite,
    void** exceptionPtr)
{
    @try 
    {
        GKMatchmakerViewController* iGKMatchmakerViewController = [[GKMatchmakerViewController alloc] initWithInvite:(__bridge GKInvite*) invite];
            return (__bridge_retained void*) iGKMatchmakerViewController;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

//InstanceMethods
void GKMatchmakerViewController_addPlayersToMatch(
    void* ptr,
    void* match,
    void** exception
    )
{ 
        @try
        {
            GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
            [iGKMatchmakerViewController addPlayersToMatch:(__bridge GKMatch*) match];
        }
        @catch(NSException* ex)
        {
            *exception = (__bridge_retained void*) ex;
        }

}



void GKMatchmakerViewController_setHostedPlayer_didConnect(
    void* ptr,
    void* player,
    bool connected,
    void** exception
    )
{ 
        @try
        {
            GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
            [iGKMatchmakerViewController setHostedPlayer:(__bridge GKPlayer*) player didConnect:connected];
        }
        @catch(NSException* ex)
        {
            *exception = (__bridge_retained void*) ex;
        }

}



//VoidMethods
//Properties
void* GKMatchmakerViewController_GetPropMatchmakerDelegate(void* ptr)
{ 
        GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
        MatchmakerViewControllerDelegate* val = [iGKMatchmakerViewController matchmakerDelegate];
        return (__bridge_retained void*) val;
    
}

void GKMatchmakerViewController_SetPropMatchmakerDelegate(void* ptr, void* matchmakerDelegate, void** exceptionPtr)
{ 
        @try
        {
            GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
            [iGKMatchmakerViewController setMatchmakerDelegate:(__bridge MatchmakerViewControllerDelegate*) matchmakerDelegate];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
}

bool GKMatchmakerViewController_GetPropHosted(void* ptr)
{ 
        GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
        BOOL val = [iGKMatchmakerViewController isHosted];
        return val;
    
}

void GKMatchmakerViewController_SetPropHosted(void* ptr, bool hosted, void** exceptionPtr)
{ 
        @try
        {
            GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
            [iGKMatchmakerViewController setHosted:hosted];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
}

long GKMatchmakerViewController_GetPropMatchmakingMode(void* ptr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14,  *))
    { 
        GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
        GKMatchmakingMode val = [iGKMatchmakerViewController matchmakingMode];
        return val;
    }
    else
    {
        return 0;
    } 
}

void GKMatchmakerViewController_SetPropMatchmakingMode(void* ptr, long matchmakingMode, void** exceptionPtr)
{ 
    if(@available(macOS 11, iOS 14, tvOS 14,  *))
    { 
        @try
        {
            GKMatchmakerViewController* iGKMatchmakerViewController = (__bridge GKMatchmakerViewController*) ptr;
            [iGKMatchmakerViewController setMatchmakingMode:(GKMatchmakingMode)matchmakingMode];
        }
        @catch(NSException* ex)
        {
            *exceptionPtr = (__bridge_retained void*) ex;
        }
    }
}



void GKMatchmakerViewController_Dispose(void* ptr)
{
    GKMatchmakerViewController* val = (__bridge GKMatchmakerViewController*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKMatchmakerViewController");
}

}
