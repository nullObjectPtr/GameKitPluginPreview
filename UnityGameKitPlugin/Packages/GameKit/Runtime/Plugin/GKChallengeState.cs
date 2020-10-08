//
//  GKChallengeState.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKChallengeState : long
    {
        Invalid = 0,
        Pending = 1,
        Completed = 2,
        Declined = 3
    }
}
