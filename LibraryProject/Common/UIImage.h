//
//  UIImage.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/23/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import "Callbacks.h"

// Class Methods 
extern "C" void* UIImage_systemImageNamed(
	const char* name,
    void** exception
    );

extern "C" void UIImage_PNGRepresentation(
    const void* image,
    const void** buffer,
    long* const bufferLen,
    void** exception
    );

extern "C" void UIImage_JPEGRepresentation(
	void* image,
    float compressionQuality,
    const void** buffer,
    long* const bufferLen,
    void** exception
    );


// Init Methods 

// Instance methods 

// Void methods 

// Properties 



extern "C" void UIImage_Dispose(void* ptr);
