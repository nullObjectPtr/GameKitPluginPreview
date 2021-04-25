//
//  Callbacks.h
//  PluginCodeGenerator
//
//  Created by Jonathan on 1/8/20.
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//

typedef void (*AuthenticateHandler)(void* ptr, void* viewController, void* error);
typedef void (*RecipientResponseHandler)(void* ptr, void* player, long response);
typedef void (*FindMatchForRequestCallback)(unsigned long invocationId, void* match, void* error);
typedef void (*StartBrowsingForNearbyPlayersCallback)(unsigned long invocationId, void* player, bool reachable);
typedef void (*LoadRecentPlayersWithCompletionCallback)(unsigned long invocationId, void* recentPlayers[],
	long recentPlayersCount, void* error);
typedef void (*LoadChallengableFriendsWithCompletionCallback)(unsigned long invocationId, void* recentPlayers[],
	long recentPlayersCount, void* error);
typedef void (*CompletionCallback)(void* ptr, unsigned long invocationId, void* error);
typedef void (*StaticCompletionCallback)(unsigned long invocationId, void* error);
typedef void (*GKPlayerCallback)(unsigned long invocationId, void* player);
typedef void (*MatchCompletionCallback)(unsigned long invocationId, void* match, void* error);
typedef void (*GKPlayersCallback)(unsigned long invocationId, void* players[],
	long playersCount, void* error);
typedef void (*LoadPlayersForIdentifierCallback)(unsigned long invocationId, void* players[],
	long playersCount, void* error);
typedef void (*QueryActivityCallback)(unsigned long invocationId, NSInteger activity, void* error);
typedef void (*GKAchievementsCallback)(unsigned long invocationId, void* achievements[],
	long achievementsCount, void* error);
typedef void (*GKAchievementDescriptionsCallback)(unsigned long invocationId, void* descriptions[],
	long descriptionsCount, void* error);
typedef void (*LoadReceivedChallengesCompletionCallback)(unsigned long invocationId, void* challenges[],
	long challengesCount, void* error);
typedef void (*LoadLeaderboardsWithIDsCompletionCallback)(unsigned long invocationId, void* leaderboards[],
	long leaderboardsCount, void* error);
typedef void (*LoadLeaderboardsCallback)(unsigned long invocationId, void* leaderboards[],
	long leaderboardsCount, void* error);
typedef void (*GKLeaderboardCallback)(unsigned long invocationId, void* leaderboards, void* error);
typedef void (*GKLeaderboardSetCallback)(unsigned long invocationId, void* leaderboardSets[],
	long leaderboardSetsCount, void* error);
typedef void (*NSStringCallback)(unsigned long invocationId, const char* leaderboardIdentifier, void* error);
typedef void (*LoadEntriesForPlayerScopeCallback)(unsigned long invocationId, void* localPlayerEntry, void* entries[],
	long entriesCount, NSInteger totalPlayerCount, void* error);
typedef void (*LoadLeaderboardEntriesCallback)(unsigned long invocationId, void* localPlayerEntry, void* entries[],
	long entriesCount, void* error);
typedef void (*TurnBasedMatchCallback)(unsigned long invocationId, void* match, void* error);
typedef void (*TurnBasedExchangeCallback)(unsigned long invocationId, void* match, void* error);
typedef void (*LoadMatchesCallback)(unsigned long invocationId, void* matches[],
	long matchesCount, void* error);
typedef void (*StaticTurnBasedMatchCallback)(unsigned long invocationId, void* match, void* error);
typedef void (*GKChallengeComposeCompletionCallback)(unsigned long invocationId, void* composeController, bool didIssueChallenge, const char* sentPlayerIDs[],
	long sentPlayerIDsCount);
typedef void (*playerVoiceChatStateDidChangeCallback)(void* ptr, unsigned long invocationId, void* player, long state);
typedef void (*ByteArrayCallback)(unsigned long invocationId, const void* matchData, long matchDataLength, void* error);
typedef void (*VoidCallback)(unsigned long invocationId);
typedef void (*ImageCallback)(unsigned long invocationId, void* image, void* error);


