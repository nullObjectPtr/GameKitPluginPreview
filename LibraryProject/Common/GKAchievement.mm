//
//  GKAchievement.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKAchievement.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
void* GKAchievement_initWithIdentifier(
    const char* identifier,
    void** exceptionPtr)
{
    @try 
    {
        GKAchievement* iGKAchievement = [[GKAchievement alloc] initWithIdentifier:[NSString stringWithUTF8String:identifier]];
            return (__bridge_retained void*) iGKAchievement;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void* GKAchievement_initWithIdentifier_player(
    const char* identifier,
    void* player,
    void** exceptionPtr)
{
    @try 
    {
        GKAchievement* iGKAchievement = [[GKAchievement alloc] initWithIdentifier:[NSString stringWithUTF8String:identifier] player:(__bridge GKPlayer*) player];
            return (__bridge_retained void*) iGKAchievement;
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

bool GKAchievement_GetPropCompleted(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	BOOL val = [iGKAchievement isCompleted];
	return val;
}


bool GKAchievement_GetPropShowsCompletionBanner(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	BOOL val = [iGKAchievement showsCompletionBanner];
	return val;
}

void GKAchievement_SetPropShowsCompletionBanner(void* ptr, bool showsCompletionBanner, void** exceptionPtr)
{
	@try 
	{
		GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
		[iGKAchievement setShowsCompletionBanner:showsCompletionBanner];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}


const char* GKAchievement_GetPropIdentifier(void* ptr)
{
	GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
	NSString* val = [iGKAchievement identifier];
	return [val UTF8String];
}

void GKAchievement_SetPropIdentifier(void* ptr, const char* identifier, void** exceptionPtr)
{
	@try 
	{
		GKAchievement* iGKAchievement = (__bridge GKAchievement*) ptr;
		[iGKAchievement setIdentifier:[NSString stringWithUTF8String:identifier]];
	}
	@catch(NSException* ex) 
	{
		*exceptionPtr = (__bridge_retained void*) ex;
	}
}



void GKAchievement_Dispose(void* ptr)
{
    GKAchievement* val = (__bridge GKAchievement*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKAchievement");
}

}
