//
//  GameKitInitializer.h
//

// MatchDelegate
typedef void (*MatchDelegate_match_player_didChangeConnectionState)(void* ptr, void* match, void* player, long state);
typedef void (*MatchDelegate_match_didFailWithError)(void* ptr, void* match, void* error);
typedef void (*MatchDelegate_match_didReceiveData_fromRemotePlayer)(void* ptr, const void* data, long dataLength, const char* player);
typedef void (*MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer)(void* ptr, const void* data, long dataLength, const char* recipient, const char* player);
typedef bool (*MatchDelegate_match_shouldReinviteDisconnectedPlayer)(void* ptr, void* match, void* player);

// MatchmakerViewControllerDelegate
typedef void (*MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch)(void* ptr, void* viewController, void* match);
typedef void (*MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled)(void* ptr, void* viewController);
typedef void (*MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError)(void* ptr, void* viewController, void* error);
typedef void (*MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept)(void* ptr, void* viewController, void* player);
typedef void (*MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers)(void* ptr, void* viewController, void* players[],
	long playersCount);

// LocalPlayerListener
typedef void (*LocalPlayerListener_player_didAcceptInvite)(void* ptr, void* player, void* invite);
typedef void (*LocalPlayerListener_player_didReceiveChallenge)(void* ptr, void* player, void* challenge);
typedef void (*LocalPlayerListener_player_wantsToPlayChallenge)(void* ptr, void* player, void* challenge);
typedef void (*LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend)(void* ptr, void* player, void* challenge, void* friendPlayer);
typedef void (*LocalPlayerListener_player_matchEnded)(void* ptr, void* player, void* match);
typedef void (*LocalPlayerListener_player_didRequestMatchWithRecipients)(void* ptr, void* player, void* recipientPlayers[],
	long recipientPlayersCount);
typedef void (*LocalPlayerListener_player_didCompleteChallenge_issuedByFriend)(void* ptr, void* player, void* challenge, void* friendPlayer);
typedef void (*LocalPlayerListener_player_receivedExchangeCancellation_forMatch)(void* ptr, void* player, void* exchange, void* match);
typedef void (*LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch)(void* ptr, void* player, void* replies[],
	long repliesCount, void* exchange, void* match);
typedef void (*LocalPlayerListener_player_receivedExchangeRequest_forMatch)(void* ptr, void* player, void* exchange, void* match);
typedef void (*LocalPlayerListener_player_didRequestMatchWithOtherPlayers)(void* ptr, void* player, void* playersToInvite[],
	long playersToInviteCount);
typedef void (*LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive)(void* ptr, void* player, void* match, bool didBecomeActive);
typedef void (*LocalPlayerListener_player_wantsToQuitMatch)(void* ptr, void* player, void* match);

// ChallengeListener
typedef void (*ChallengeListener_player_didReceiveChallenge)(void* ptr, void* player, void* challenge);
typedef void (*ChallengeListener_player_wantsToPlayChallenge)(void* ptr, void* player, void* challenge);
typedef void (*ChallengeListener_player_didCompleteChallenge_issuedByFriend)(void* ptr, void* player, void* challenge, void* friendPlayer);
typedef void (*ChallengeListener_player_issuedChallengeWasCompleted_byFriend)(void* ptr, void* player, void* challenge, void* friendPlayer);

// TurnBasedEventListener
typedef void (*TurnBasedEventListener_player_receivedExchangeCancellation_forMatch)(void* ptr, void* player, void* exchange, void* match);
typedef void (*TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch)(void* ptr, void* player, void* replies[],
	long repliesCount, void* exchange, void* match);
typedef void (*TurnBasedEventListener_player_receivedExchangeRequest_forMatch)(void* ptr, void* player, void* exchange, void* match);
typedef void (*TurnBasedEventListener_player_didRequestMatchWithOtherPlayers)(void* ptr, void* player, void* playersToInvite[],
	long playersToInviteCount);
typedef void (*TurnBasedEventListener_player_matchEnded)(void* ptr, void* player, void* match);
typedef void (*TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive)(void* ptr, void* player, void* match, bool didBecomeActive);
typedef void (*TurnBasedEventListener_player_wantsToQuitMatch)(void* ptr, void* player, void* match);

// GKTurnBasedMatchmakerViewControllerDelegate
typedef void (*GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled)(void* ptr, void* viewController);
typedef void (*GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError)(void* ptr, void* viewController, void* error);

// GKGameCenterControllerDelegate
typedef void (*GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish)(const void* gameCenterViewController);



// MatchDelegate

extern MatchDelegate_match_player_didChangeConnectionState KMatchDelegate_match_player_didChangeConnectionState;

extern MatchDelegate_match_didFailWithError KMatchDelegate_match_didFailWithError;

extern MatchDelegate_match_didReceiveData_fromRemotePlayer KMatchDelegate_match_didReceiveData_fromRemotePlayer;

extern MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer KMatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer;

extern MatchDelegate_match_shouldReinviteDisconnectedPlayer KMatchDelegate_match_shouldReinviteDisconnectedPlayer;

// MatchmakerViewControllerDelegate

extern MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch KMatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch;

extern MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled KMatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled;

extern MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError KMatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError;

extern MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept KMatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept;

extern MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers KMatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers;

// LocalPlayerListener

extern LocalPlayerListener_player_didAcceptInvite KLocalPlayerListener_player_didAcceptInvite;

extern LocalPlayerListener_player_didReceiveChallenge KLocalPlayerListener_player_didReceiveChallenge;

extern LocalPlayerListener_player_wantsToPlayChallenge KLocalPlayerListener_player_wantsToPlayChallenge;

extern LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend KLocalPlayerListener_player_issuedChallengeWasCompleted_byFriend;

extern LocalPlayerListener_player_matchEnded KLocalPlayerListener_player_matchEnded;

extern LocalPlayerListener_player_didRequestMatchWithRecipients KLocalPlayerListener_player_didRequestMatchWithRecipients;

extern LocalPlayerListener_player_didCompleteChallenge_issuedByFriend KLocalPlayerListener_player_didCompleteChallenge_issuedByFriend;

extern LocalPlayerListener_player_receivedExchangeCancellation_forMatch KLocalPlayerListener_player_receivedExchangeCancellation_forMatch;

extern LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch KLocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch;

extern LocalPlayerListener_player_receivedExchangeRequest_forMatch KLocalPlayerListener_player_receivedExchangeRequest_forMatch;

extern LocalPlayerListener_player_didRequestMatchWithOtherPlayers KLocalPlayerListener_player_didRequestMatchWithOtherPlayers;

extern LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive KLocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive;

extern LocalPlayerListener_player_wantsToQuitMatch KLocalPlayerListener_player_wantsToQuitMatch;

// ChallengeListener

extern ChallengeListener_player_didReceiveChallenge KChallengeListener_player_didReceiveChallenge;

extern ChallengeListener_player_wantsToPlayChallenge KChallengeListener_player_wantsToPlayChallenge;

extern ChallengeListener_player_didCompleteChallenge_issuedByFriend KChallengeListener_player_didCompleteChallenge_issuedByFriend;

extern ChallengeListener_player_issuedChallengeWasCompleted_byFriend KChallengeListener_player_issuedChallengeWasCompleted_byFriend;

// TurnBasedEventListener

extern TurnBasedEventListener_player_receivedExchangeCancellation_forMatch KTurnBasedEventListener_player_receivedExchangeCancellation_forMatch;

extern TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch KTurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch;

extern TurnBasedEventListener_player_receivedExchangeRequest_forMatch KTurnBasedEventListener_player_receivedExchangeRequest_forMatch;

extern TurnBasedEventListener_player_didRequestMatchWithOtherPlayers KTurnBasedEventListener_player_didRequestMatchWithOtherPlayers;

extern TurnBasedEventListener_player_matchEnded KTurnBasedEventListener_player_matchEnded;

extern TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive KTurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive;

extern TurnBasedEventListener_player_wantsToQuitMatch KTurnBasedEventListener_player_wantsToQuitMatch;

// GKTurnBasedMatchmakerViewControllerDelegate

extern GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled;

extern GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError;

// GKGameCenterControllerDelegate

extern GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish KGKGameCenterControllerDelegate_gameCenterViewControllerDidFinish;


