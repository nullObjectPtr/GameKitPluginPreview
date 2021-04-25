//
//  NSException.mm
//
//  Created by Jonathan on 12/31/19.
//  Copyright © 2019 HovelHouseApps. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <GameKit/GameKit.h>
#import "GameKitInitializer.h"

// MatchDelegate

MatchDelegate_match_player_didChangeConnectionState KMatchDelegate_match_player_didChangeConnectionState;

MatchDelegate_match_didFailWithError KMatchDelegate_match_didFailWithError;

MatchDelegate_match_didReceiveData_fromRemotePlayer KMatchDelegate_match_didReceiveData_fromRemotePlayer;

MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer KMatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer;

MatchDelegate_match_shouldReinviteDisconnectedPlayer KMatchDelegate_match_shouldReinviteDisconnectedPlayer;

// MatchmakerViewControllerDelegate

MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch KMatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch;

MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled KMatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled;

MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError KMatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError;

MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept KMatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept;

MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers KMatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers;

// LocalPlayerListener

LocalPlayerListener_player_didAcceptInvite KLocalPlayerListener_player_didAcceptInvite;

LocalPlayerListener_player_didReceiveChallenge KLocalPlayerListener_player_didReceiveChallenge;

LocalPlayerListener_player_wantsToPlayChallenge KLocalPlayerListener_player_wantsToPlayChallenge;

LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend KLocalPlayerListener_player_issuedChallengeWasCompleted_byFriend;

LocalPlayerListener_player_matchEnded KLocalPlayerListener_player_matchEnded;

LocalPlayerListener_player_didRequestMatchWithRecipients KLocalPlayerListener_player_didRequestMatchWithRecipients;

LocalPlayerListener_player_didCompleteChallenge_issuedByFriend KLocalPlayerListener_player_didCompleteChallenge_issuedByFriend;

LocalPlayerListener_player_receivedExchangeCancellation_forMatch KLocalPlayerListener_player_receivedExchangeCancellation_forMatch;

LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch KLocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch;

LocalPlayerListener_player_receivedExchangeRequest_forMatch KLocalPlayerListener_player_receivedExchangeRequest_forMatch;

LocalPlayerListener_player_didRequestMatchWithOtherPlayers KLocalPlayerListener_player_didRequestMatchWithOtherPlayers;

LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive KLocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive;

LocalPlayerListener_player_wantsToQuitMatch KLocalPlayerListener_player_wantsToQuitMatch;

// ChallengeListener

ChallengeListener_player_didReceiveChallenge KChallengeListener_player_didReceiveChallenge;

ChallengeListener_player_wantsToPlayChallenge KChallengeListener_player_wantsToPlayChallenge;

ChallengeListener_player_didCompleteChallenge_issuedByFriend KChallengeListener_player_didCompleteChallenge_issuedByFriend;

ChallengeListener_player_issuedChallengeWasCompleted_byFriend KChallengeListener_player_issuedChallengeWasCompleted_byFriend;

// TurnBasedEventListener

TurnBasedEventListener_player_receivedExchangeCancellation_forMatch KTurnBasedEventListener_player_receivedExchangeCancellation_forMatch;

TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch KTurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch;

TurnBasedEventListener_player_receivedExchangeRequest_forMatch KTurnBasedEventListener_player_receivedExchangeRequest_forMatch;

TurnBasedEventListener_player_didRequestMatchWithOtherPlayers KTurnBasedEventListener_player_didRequestMatchWithOtherPlayers;

TurnBasedEventListener_player_matchEnded KTurnBasedEventListener_player_matchEnded;

TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive KTurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive;

TurnBasedEventListener_player_wantsToQuitMatch KTurnBasedEventListener_player_wantsToQuitMatch;

// GKTurnBasedMatchmakerViewControllerDelegate

GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled;

GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError;

// GKGameCenterControllerDelegate

GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish KGKGameCenterControllerDelegate_gameCenterViewControllerDidFinish;




extern "C" {

    // MatchDelegate
    void RegisterDelegateFor_MatchDelegate_match_player_didChangeConnectionState(MatchDelegate_match_player_didChangeConnectionState del)
    {
    	NSLog(@"did register MatchDelegate_match_player_didChangeConnectionState");
    	KMatchDelegate_match_player_didChangeConnectionState = del;
	}
    void RegisterDelegateFor_MatchDelegate_match_didFailWithError(MatchDelegate_match_didFailWithError del)
    {
    	NSLog(@"did register MatchDelegate_match_didFailWithError");
    	KMatchDelegate_match_didFailWithError = del;
	}
    void RegisterDelegateFor_MatchDelegate_match_didReceiveData_fromRemotePlayer(MatchDelegate_match_didReceiveData_fromRemotePlayer del)
    {
    	NSLog(@"did register MatchDelegate_match_didReceiveData_fromRemotePlayer");
    	KMatchDelegate_match_didReceiveData_fromRemotePlayer = del;
	}
    void RegisterDelegateFor_MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer(MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer del)
    {
    	NSLog(@"did register MatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer");
    	KMatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer = del;
	}
    void RegisterDelegateFor_MatchDelegate_match_shouldReinviteDisconnectedPlayer(MatchDelegate_match_shouldReinviteDisconnectedPlayer del)
    {
    	NSLog(@"did register MatchDelegate_match_shouldReinviteDisconnectedPlayer");
    	KMatchDelegate_match_shouldReinviteDisconnectedPlayer = del;
	}
    
    // MatchmakerViewControllerDelegate
    void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch(MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch del)
    {
    	NSLog(@"did register MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch");
    	KMatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch = del;
	}
    void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled(MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled del)
    {
    	NSLog(@"did register MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled");
    	KMatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled = del;
	}
    void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError(MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError del)
    {
    	NSLog(@"did register MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError");
    	KMatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError = del;
	}
    void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept(MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept del)
    {
    	NSLog(@"did register MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept");
    	KMatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept = del;
	}
    void RegisterDelegateFor_MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers(MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers del)
    {
    	NSLog(@"did register MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers");
    	KMatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers = del;
	}
    
    // LocalPlayerListener
    void RegisterDelegateFor_LocalPlayerListener_player_didAcceptInvite(LocalPlayerListener_player_didAcceptInvite del)
    {
    	NSLog(@"did register LocalPlayerListener_player_didAcceptInvite");
    	KLocalPlayerListener_player_didAcceptInvite = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_didReceiveChallenge(LocalPlayerListener_player_didReceiveChallenge del)
    {
    	NSLog(@"did register LocalPlayerListener_player_didReceiveChallenge");
    	KLocalPlayerListener_player_didReceiveChallenge = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_wantsToPlayChallenge(LocalPlayerListener_player_wantsToPlayChallenge del)
    {
    	NSLog(@"did register LocalPlayerListener_player_wantsToPlayChallenge");
    	KLocalPlayerListener_player_wantsToPlayChallenge = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend(LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend del)
    {
    	NSLog(@"did register LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend");
    	KLocalPlayerListener_player_issuedChallengeWasCompleted_byFriend = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_matchEnded(LocalPlayerListener_player_matchEnded del)
    {
    	NSLog(@"did register LocalPlayerListener_player_matchEnded");
    	KLocalPlayerListener_player_matchEnded = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_didRequestMatchWithRecipients(LocalPlayerListener_player_didRequestMatchWithRecipients del)
    {
    	NSLog(@"did register LocalPlayerListener_player_didRequestMatchWithRecipients");
    	KLocalPlayerListener_player_didRequestMatchWithRecipients = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_didCompleteChallenge_issuedByFriend(LocalPlayerListener_player_didCompleteChallenge_issuedByFriend del)
    {
    	NSLog(@"did register LocalPlayerListener_player_didCompleteChallenge_issuedByFriend");
    	KLocalPlayerListener_player_didCompleteChallenge_issuedByFriend = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeCancellation_forMatch(LocalPlayerListener_player_receivedExchangeCancellation_forMatch del)
    {
    	NSLog(@"did register LocalPlayerListener_player_receivedExchangeCancellation_forMatch");
    	KLocalPlayerListener_player_receivedExchangeCancellation_forMatch = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch del)
    {
    	NSLog(@"did register LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch");
    	KLocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_receivedExchangeRequest_forMatch(LocalPlayerListener_player_receivedExchangeRequest_forMatch del)
    {
    	NSLog(@"did register LocalPlayerListener_player_receivedExchangeRequest_forMatch");
    	KLocalPlayerListener_player_receivedExchangeRequest_forMatch = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_didRequestMatchWithOtherPlayers(LocalPlayerListener_player_didRequestMatchWithOtherPlayers del)
    {
    	NSLog(@"did register LocalPlayerListener_player_didRequestMatchWithOtherPlayers");
    	KLocalPlayerListener_player_didRequestMatchWithOtherPlayers = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive(LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive del)
    {
    	NSLog(@"did register LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive");
    	KLocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive = del;
	}
    void RegisterDelegateFor_LocalPlayerListener_player_wantsToQuitMatch(LocalPlayerListener_player_wantsToQuitMatch del)
    {
    	NSLog(@"did register LocalPlayerListener_player_wantsToQuitMatch");
    	KLocalPlayerListener_player_wantsToQuitMatch = del;
	}
    
    // ChallengeListener
    void RegisterDelegateFor_ChallengeListener_player_didReceiveChallenge(ChallengeListener_player_didReceiveChallenge del)
    {
    	NSLog(@"did register ChallengeListener_player_didReceiveChallenge");
    	KChallengeListener_player_didReceiveChallenge = del;
	}
    void RegisterDelegateFor_ChallengeListener_player_wantsToPlayChallenge(ChallengeListener_player_wantsToPlayChallenge del)
    {
    	NSLog(@"did register ChallengeListener_player_wantsToPlayChallenge");
    	KChallengeListener_player_wantsToPlayChallenge = del;
	}
    void RegisterDelegateFor_ChallengeListener_player_didCompleteChallenge_issuedByFriend(ChallengeListener_player_didCompleteChallenge_issuedByFriend del)
    {
    	NSLog(@"did register ChallengeListener_player_didCompleteChallenge_issuedByFriend");
    	KChallengeListener_player_didCompleteChallenge_issuedByFriend = del;
	}
    void RegisterDelegateFor_ChallengeListener_player_issuedChallengeWasCompleted_byFriend(ChallengeListener_player_issuedChallengeWasCompleted_byFriend del)
    {
    	NSLog(@"did register ChallengeListener_player_issuedChallengeWasCompleted_byFriend");
    	KChallengeListener_player_issuedChallengeWasCompleted_byFriend = del;
	}
    
    // TurnBasedEventListener
    void RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeCancellation_forMatch(TurnBasedEventListener_player_receivedExchangeCancellation_forMatch del)
    {
    	NSLog(@"did register TurnBasedEventListener_player_receivedExchangeCancellation_forMatch");
    	KTurnBasedEventListener_player_receivedExchangeCancellation_forMatch = del;
	}
    void RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch del)
    {
    	NSLog(@"did register TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch");
    	KTurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch = del;
	}
    void RegisterDelegateFor_TurnBasedEventListener_player_receivedExchangeRequest_forMatch(TurnBasedEventListener_player_receivedExchangeRequest_forMatch del)
    {
    	NSLog(@"did register TurnBasedEventListener_player_receivedExchangeRequest_forMatch");
    	KTurnBasedEventListener_player_receivedExchangeRequest_forMatch = del;
	}
    void RegisterDelegateFor_TurnBasedEventListener_player_didRequestMatchWithOtherPlayers(TurnBasedEventListener_player_didRequestMatchWithOtherPlayers del)
    {
    	NSLog(@"did register TurnBasedEventListener_player_didRequestMatchWithOtherPlayers");
    	KTurnBasedEventListener_player_didRequestMatchWithOtherPlayers = del;
	}
    void RegisterDelegateFor_TurnBasedEventListener_player_matchEnded(TurnBasedEventListener_player_matchEnded del)
    {
    	NSLog(@"did register TurnBasedEventListener_player_matchEnded");
    	KTurnBasedEventListener_player_matchEnded = del;
	}
    void RegisterDelegateFor_TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive(TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive del)
    {
    	NSLog(@"did register TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive");
    	KTurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive = del;
	}
    void RegisterDelegateFor_TurnBasedEventListener_player_wantsToQuitMatch(TurnBasedEventListener_player_wantsToQuitMatch del)
    {
    	NSLog(@"did register TurnBasedEventListener_player_wantsToQuitMatch");
    	KTurnBasedEventListener_player_wantsToQuitMatch = del;
	}
    
    // GKTurnBasedMatchmakerViewControllerDelegate
    void RegisterDelegateFor_GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled(GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled del)
    {
    	NSLog(@"did register GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled");
    	KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled = del;
	}
    void RegisterDelegateFor_GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError(GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError del)
    {
    	NSLog(@"did register GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError");
    	KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError = del;
	}
    
    // GKGameCenterControllerDelegate
    void RegisterDelegateFor_GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish(GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish del)
    {
    	NSLog(@"did register GKGameCenterControllerDelegate_gameCenterViewControllerDidFinish");
    	KGKGameCenterControllerDelegate_gameCenterViewControllerDidFinish = del;
	}
    
    

}
