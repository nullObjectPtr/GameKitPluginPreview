//
//  GKTurnBasedParticipantStatus.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKTurnBasedParticipantStatus : long
    {
        Unknown = 0,
        Invited = 1,
        Declined = 2,
        Matching = 3,
        Active = 4,
        Done = 5
    }
}
