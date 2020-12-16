//
//  GKSavedGame.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GKSavedGame.h"
#import "Converters.h"


extern "C" {

//ClassMethods
//InitMethods
//InstanceMethods
//VoidMethods
//Properties
const char* GKSavedGame_GetPropDeviceName(void* ptr)
{
    NSString* val = @"TODO";
    return [val UTF8String];
}


const char* GKSavedGame_GetPropName(void* ptr)
{
	NSString* val = @"TODO";
	return [val UTF8String];
}


double GKSavedGame_GetPropModificationDate(void* ptr)
{
//	GKSavedGame* iGKSavedGame = (__bridge GKSavedGame*) ptr;
//	NSDate* val = [iGKSavedGame modificationDate];
//	return [val timeIntervalSince1970];
    return 0;
}




void GKSavedGame_Dispose(void* ptr)
{

}

}
