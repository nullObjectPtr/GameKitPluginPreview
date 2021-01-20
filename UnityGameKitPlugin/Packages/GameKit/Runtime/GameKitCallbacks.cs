//
//  GameKitCallbacks.cs
//
//  Created by Jonathan Culp <jonathanculp@gmail.com> on 09/24/2020
//  Copyright © 2021 HovelHouseApps. All rights reserved.
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
        ulong invocationId,
    	IntPtr match,
    	IntPtr error);
    
	public delegate void StartBrowsingForNearbyPlayersDelegate(
        ulong invocationId,
    	IntPtr player,
    	bool reachable);
    
	public delegate void LoadRecentPlayersWithCompletionDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] recentPlayers,
		long recentPlayersCount,
    	IntPtr error);
    
	public delegate void LoadChallengableFriendsWithCompletionDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] recentPlayers,
		long recentPlayersCount,
    	IntPtr error);
    
	public delegate void CompletionDelegate(
         IntPtr _this,
        ulong invocationId,
    	IntPtr error);
    
	public delegate void StaticCompletionDelegate(
        ulong invocationId,
    	IntPtr error);
    
	public delegate void GKPlayerDelegate(
        ulong invocationId,
    	IntPtr player);
    
	public delegate void MatchCompletionDelegate(
        ulong invocationId,
    	IntPtr match,
    	IntPtr error);
    
	public delegate void GKPlayersDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] players,
		long playersCount,
    	IntPtr error);
    
	public delegate void LoadPlayersForIdentifierDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] players,
		long playersCount,
    	IntPtr error);
    
	public delegate void QueryActivityDelegate(
        ulong invocationId,
    	long activity,
    	IntPtr error);
    
	public delegate void GKAchievementsDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] achievements,
		long achievementsCount,
    	IntPtr error);
    
	public delegate void GKAchievementDescriptionsDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] descriptions,
		long descriptionsCount,
    	IntPtr error);
    
	public delegate void LoadReceivedChallengesCompletionDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] challenges,
		long challengesCount,
    	IntPtr error);
    
	public delegate void LoadLeaderboardsWithIDsCompletionDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] leaderboards,
		long leaderboardsCount,
    	IntPtr error);
    
	public delegate void LoadLeaderboardsDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] leaderboards,
		long leaderboardsCount,
    	IntPtr error);
    
	public delegate void GKLeaderboardDelegate(
        ulong invocationId,
    	IntPtr leaderboards,
    	IntPtr error);
    
	public delegate void GKLeaderboardSetDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] leaderboardSets,
		long leaderboardSetsCount,
    	IntPtr error);
    
	public delegate void NSStringDelegate(
        ulong invocationId,
    	IntPtr leaderboardIdentifier,
    	IntPtr error);
    
	public delegate void LoadEntriesForPlayerScopeDelegate(
        ulong invocationId,
    	IntPtr localPlayerEntry,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 3)]
		IntPtr[] entries,
		long entriesCount,
    	long totalPlayerCount,
    	IntPtr error);
    
	public delegate void LoadLeaderboardEntriesDelegate(
        ulong invocationId,
    	IntPtr localPlayerEntry,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 3)]
		IntPtr[] entries,
		long entriesCount,
    	IntPtr error);
    
	public delegate void TurnBasedMatchDelegate(
        ulong invocationId,
    	IntPtr match,
    	IntPtr error);
    
	public delegate void TurnBasedExchangeDelegate(
        ulong invocationId,
    	IntPtr match,
    	IntPtr error);
    
	public delegate void LoadMatchesDelegate(
        ulong invocationId,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 2)]
		IntPtr[] matches,
		long matchesCount,
    	IntPtr error);
    
	public delegate void StaticTurnBasedMatchDelegate(
        ulong invocationId,
    	IntPtr match,
    	IntPtr error);
    
	public delegate void GKChallengeComposeCompletionDelegate(
        ulong invocationId,
    	IntPtr composeController,
    	bool didIssueChallenge,
    	[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 4)]
		IntPtr[] sentPlayerIDs,
		long sentPlayerIDsCount);
    
	public delegate void PlayerVoiceChatStateDidChangeDelegate(
		IntPtr _this,
        ulong invocationId,
    	IntPtr player,
    	GKVoiceChatPlayerState state);
    
	public delegate void ByteArrayDelegate(
        ulong invocationId,
    	IntPtr matchData, long matchDataLength,
    	IntPtr error);
    
	public delegate void VoidDelegate(
        ulong invocationId);
    
}

