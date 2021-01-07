//
//  GKTurnBasedExchangeStatus.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKTurnBasedExchangeStatus : long
    {
        Unknown = 0,
        Active = 1,
        Complete = 2,
        Resolved = 3,
        Canceled = 4
    }
}
