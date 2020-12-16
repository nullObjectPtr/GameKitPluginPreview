//
//  GKTurnBasedMatchStatus.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKTurnBasedMatchStatus : long
    {
        Unknown = 0,
        Open = 1,
        Ended = 2,
        Matching = 3
    }
}
