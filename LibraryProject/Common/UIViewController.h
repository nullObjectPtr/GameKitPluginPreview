//
//  UIViewController.h
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
extern "C" void UIViewController_present(
	void* ptr,
	void** exception
    );

extern "C" void UIViewController_dismiss(
	void* ptr,
	void** exception
    );


// Void methods 

// Properties 



extern "C" void UIViewController_Dispose(void* ptr);
