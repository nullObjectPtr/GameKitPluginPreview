//
//  GKErrorCode.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKErrorCode : long
    {
        Unknown = 1,
        Cancelled = 2,
        CommunicationsFailure = 3,
        UserDenied = 4,
        InvalidCredentials = 5,
        NotAuthenticated = 6,
        AuthenticationInProgress = 7,
        InvalidPlayer = 8,
        ScoreNotSet = 9,
        ParentalControlsBlocked = 10,
        PlayerStatusExceedsMaximumLength = 11,
        PlayerStatusInvalid = 12,
        MatchRequestInvalid = 13,
        Underage = 14,
        GameUnrecognized = 15,
        NotSupported = 16,
        InvalidParameter = 17,
        UnexpectedConnection = 18,
        ChallengeInvalid = 19,
        TurnBasedMatchDataTooLarge = 20,
        TurnBasedTooManySessions = 21,
        TurnBasedInvalidParticipant = 22,
        TurnBasedInvalidTurn = 23,
        TurnBasedInvalidState = 24,
        InvitationsDisabled = 25,
        Offline = 25,
        PlayerPhotoFailure = 26,
        UbiquityContainerUnavailable = 27,
        MatchNotConnected = 28,
        GameSessionRequestInvalid = 29,
        RestrictedToAutomatch = 30,
        APINotAvailable = 31,
        NotAuthorized = 32,
        ConnectionTimeout = 33,
        APIObsolete = 34
    }
}
