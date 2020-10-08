//
//  MatchDelegate.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/22/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>

// Init Methods
extern "C" void* MatchDelegate_init(
    void** exceptionPtr);
    
extern "C" void MatchDelegate_Dispose(void* ptr);

@interface MatchDelegate : NSObject <GKMatchDelegate>

@end
