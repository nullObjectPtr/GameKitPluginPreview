//
//  GKAccessPoint.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 

// Init Methods 

// Instance methods 
extern "C" void GKAccessPoint_triggerAccessPointWithHandler(
	void* ptr,
	unsigned long invocationId, GKAccessPointCallback handler,
    void** exception
    );

extern "C" void GKAccessPoint_triggerAccessPointWithState_handler(
	void* ptr,
	long state,
    unsigned long invocationId, GKAccessPointCallback handler,
    void** exception
    );


// Void methods 

// Properties 

extern "C" void* GKAccessPoint_GetPropShared();


extern "C" long GKAccessPoint_GetPropLocation(void* ptr);
extern "C" void GKAccessPoint_SetPropLocation(void* ptr, long location, void** exceptionPtr);



extern "C" bool GKAccessPoint_GetPropActive(void* ptr);
extern "C" void GKAccessPoint_SetPropActive(void* ptr, bool active, void** exceptionPtr);



extern "C" bool GKAccessPoint_GetPropIsPresentingGameCenter(void* ptr);


extern "C" bool GKAccessPoint_GetPropVisible(void* ptr);


extern "C" bool GKAccessPoint_GetPropShowHighlights(void* ptr);
extern "C" void GKAccessPoint_SetPropShowHighlights(void* ptr, bool showHighlights, void** exceptionPtr);



extern "C" bool GKAccessPoint_GetPropFocused(void* ptr);
extern "C" void GKAccessPoint_SetPropFocused(void* ptr, bool focused, void** exceptionPtr);





extern "C" void GKAccessPoint_Dispose(void* ptr);
