//
//  GKInviteRecipientResponse.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKInviteRecipientResponse : long
    {
        GKInviteRecipientResponseAccepted = 0,
        GKInviteRecipientResponseDeclined = 1,
        GKInviteRecipientResponseFailed = 2,
        GKInviteRecipientResponseIncompatible = 3,
        GKInviteRecipientResponseUnableToConnect = 4,
        GKInviteRecipientResponseNoAnswer = 5
    }
}
