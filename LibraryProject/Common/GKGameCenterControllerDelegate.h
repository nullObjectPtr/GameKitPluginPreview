//
//  GKGameCenterControllerDelegate.h
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/22/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>

@interface MyGameCenterControllerDelegate : NSObject <GKGameCenterControllerDelegate>
{
    
}

@property (nonatomic, retain) GKGameCenterViewController* controller;

- (id) initWithController:(GKGameCenterViewController*) controller;

@end
    

