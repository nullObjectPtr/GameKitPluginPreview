//
//  GameKitCallbacks.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//  Unauthorized copying of this file, via any medium is strictly prohibited
//  Proprietary and confidential
//

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace HovelHouse.GameKit
{

	public delegate void AuthenticateHandler(
        IntPtr _this,
    	IntPtr viewController,
    	IntPtr error);
    
	public delegate void RecipientResponseHandler(
        IntPtr _this,
    	IntPtr player,
    	GKInviteRecipientResponse response);
    
	public delegate void FindMatchForRequestDelegate(
        IntPtr _this, 
        ulong invocationId,
    	IntPtr match,
    	IntPtr error);
    
	public delegate void StartBrowsingForNearbyPlayersDelegate(
        IntPtr _this, 
        ulong invocationId,
    	IntPtr player,
    	bool reachable);
    
	public delegate void LoadRecentPlayersWithCompletionDelegate(
        IntPtr _this, 
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 3)]
		IntPtr[] recentPlayers,
		long recentPlayersCount,
    	IntPtr error);
    
	public delegate void LoadChallengableFriendsWithCompletionDelegate(
        IntPtr _this, 
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 3)]
		IntPtr[] recentPlayers,
		long recentPlayersCount,
    	IntPtr error);
    
	public delegate void CompletionDelegate(
        IntPtr _this, 
        ulong invocationId,
    	IntPtr error);
    
	public delegate void GKPlayerDelegate(
        IntPtr _this, 
        ulong invocationId,
    	IntPtr player);
    
	public delegate void MatchCompletionDelegate(
        IntPtr _this, 
        ulong invocationId,
    	IntPtr match,
    	IntPtr error);
    
	public delegate void FindPlayersForHostedRequestDelegate(
        IntPtr _this, 
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 3)]
		IntPtr[] players,
		long playersCount,
    	IntPtr error);
    
	public delegate void QueryActivityDelegate(
        IntPtr _this, 
        ulong invocationId,
    	long activity,
    	IntPtr error);
    
}

