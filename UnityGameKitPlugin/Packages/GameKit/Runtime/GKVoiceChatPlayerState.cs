//
//  GKVoiceChatPlayerState.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

namespace HovelHouse.GameKit
{
    public enum GKVoiceChatPlayerState : long
    {
        Connected = 0,
        Disconnected = 1,
        Speaking = 2,
        Silent = 3,
        Connecting = 4
    }
}
