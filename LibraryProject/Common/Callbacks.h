//
//  Callbacks.h
//  PluginCodeGenerator
//
//  Created by Jonathan on 1/8/20.
//  Copyright © 2020 HovelHouseApps. All rights reserved.
//

typedef void (*AuthenticateHandler)(void* ptr, void* viewController, void* error);
typedef void (*RecipientResponseHandler)(void* ptr, void* player, long response);
typedef void (*FindMatchForRequestCallback)(void* ptr, unsigned long invocationId, void* match, void* error);
typedef void (*StartBrowsingForNearbyPlayersCallback)(void* ptr, unsigned long invocationId, void* player, bool reachable);
typedef void (*LoadRecentPlayersWithCompletionCallback)(void* ptr, unsigned long invocationId, void* recentPlayers[],
	long recentPlayersCount, void* error);
typedef void (*LoadChallengableFriendsWithCompletionCallback)(void* ptr, unsigned long invocationId, void* recentPlayers[],
	long recentPlayersCount, void* error);
typedef void (*CompletionCallback)(void* ptr, unsigned long invocationId, void* error);
typedef void (*GKPlayerCallback)(void* ptr, unsigned long invocationId, void* player);
typedef void (*MatchCompletionCallback)(void* ptr, unsigned long invocationId, void* match, void* error);
typedef void (*FindPlayersForHostedRequestCallback)(void* ptr, unsigned long invocationId, void* players[],
	long playersCount, void* error);
typedef void (*QueryActivityCallback)(void* ptr, unsigned long invocationId, NSInteger activity, void* error);

