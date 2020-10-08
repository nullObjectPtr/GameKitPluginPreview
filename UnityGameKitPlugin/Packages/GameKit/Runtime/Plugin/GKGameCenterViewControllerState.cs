//
//  GKGameCenterViewControllerState.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKGameCenterViewControllerState : long
    {
        GKGameCenterViewControllerStateDefault = -1,
        GKGameCenterViewControllerStateLeaderboards = 0,
        GKGameCenterViewControllerStateAchievements = 1,
        GKGameCenterViewControllerStateChallenges = 2,
        GKGameCenterViewControllerStateLocalPlayerProfile = 3,
        GKGameCenterViewControllerStateDashboard = 4
    }
}
