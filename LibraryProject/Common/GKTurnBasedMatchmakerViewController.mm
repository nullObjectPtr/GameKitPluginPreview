//
//  GKTurnBasedMatchmakerViewController.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKTurnBasedMatchmakerViewController.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
void* GKTurnBasedMatchmakerViewController_initWithMatchRequest(
    void* request,
    void** exceptionPtr)
{
    @try 
    {
        GKTurnBasedMatchmakerViewController* iGKTurnBasedMatchmakerViewController = [[GKTurnBasedMatchmakerViewController alloc] initWithMatchRequest:(__bridge GKMatchRequest*) request];
            return (__bridge_retained void*) iGKTurnBasedMatchmakerViewController;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

//InstanceMethods
//VoidMethods
//Properties
bool GKTurnBasedMatchmakerViewController_GetPropShowExistingMatches(void* ptr)
{
	GKTurnBasedMatchmakerViewController* iGKTurnBasedMatchmakerViewController = (__bridge GKTurnBasedMatchmakerViewController*) ptr;
	BOOL val = [iGKTurnBasedMatchmakerViewController showExistingMatches];
	return val;
}

void GKTurnBasedMatchmakerViewController_SetPropShowExistingMatches(void* ptr, bool showExistingMatches, void** exceptionPtr)
{
	@try
	{
		GKTurnBasedMatchmakerViewController* iGKTurnBasedMatchmakerViewController = (__bridge GKTurnBasedMatchmakerViewController*) ptr;
		[iGKTurnBasedMatchmakerViewController setShowExistingMatches:showExistingMatches];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


void* GKTurnBasedMatchmakerViewController_GetPropTurnBasedMatchmakerDelegate(void* ptr)
{
	GKTurnBasedMatchmakerViewController* iGKTurnBasedMatchmakerViewController = (__bridge GKTurnBasedMatchmakerViewController*) ptr;
	id<GKTurnBasedMatchmakerViewControllerDelegate> val = [iGKTurnBasedMatchmakerViewController turnBasedMatchmakerDelegate];
	return (__bridge_retained void*) val;
}

void GKTurnBasedMatchmakerViewController_SetPropTurnBasedMatchmakerDelegate(void* ptr, void* turnBasedMatchmakerDelegate, void** exceptionPtr)
{
	@try
	{
        id<GKTurnBasedMatchmakerViewControllerDelegate> del = (__bridge id<GKTurnBasedMatchmakerViewControllerDelegate>) turnBasedMatchmakerDelegate;
		GKTurnBasedMatchmakerViewController* iGKTurnBasedMatchmakerViewController = (__bridge GKTurnBasedMatchmakerViewController*) ptr;
		[iGKTurnBasedMatchmakerViewController setTurnBasedMatchmakerDelegate:del];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}




void GKTurnBasedMatchmakerViewController_Dispose(void* ptr)
{
    GKTurnBasedMatchmakerViewController* val = (__bridge GKTurnBasedMatchmakerViewController*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKTurnBasedMatchmakerViewController");
}

}
