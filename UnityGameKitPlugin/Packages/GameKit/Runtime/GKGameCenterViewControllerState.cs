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
        Default = -1,
        Leaderboards = 0,
        Achievements = 1,
        Challenges = 2,
        LocalPlayerProfile = 3,
        Dashboard = 4
    }
}
