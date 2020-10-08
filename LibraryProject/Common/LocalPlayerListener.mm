#import "GameKitInitializer.h"
#import "Converters.h"
#import "LocalPlayerListener.h"

void* LocalPlayerListener_init(
    void** exceptionPtr)
{
    @try
    {
        LocalPlayerListener* inst = [[LocalPlayerListener alloc] init];
            return (__bridge_retained void*) inst;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void LocalPlayerListener_Dispose(void* ptr)
{
    LocalPlayerListener* val = (__bridge LocalPlayerListener*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...LocalPlayerListener");
}

@implementation LocalPlayerListener

- (void)player:(GKPlayer *)player didAcceptInvite:(GKInvite *)invite
{
    NSLog(@"LocalPlayerListener_player_didAcceptInvite");
    
    KLocalPlayerListener_player_didAcceptInvite(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) invite
        );
    
}

- (void)player:(GKPlayer *)player didReceiveChallenge:(GKChallenge *)challenge;
{
    NSLog(@"LocalPlayerListener_player_didReceiveChallenge");
    
    KLocalPlayerListener_player_didReceiveChallenge(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge
        );
    
}

- (void)player:(GKPlayer *)player wantsToPlayChallenge:(GKChallenge *)challenge;
{
    NSLog(@"LocalPlayerListener_player_wantsToPlayChallenge");
    
    KLocalPlayerListener_player_wantsToPlayChallenge(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge
        );
    
}

- (void)player:(GKPlayer *)player issuedChallengeWasCompleted:(GKChallenge *)challenge byFriend:(GKPlayer *)friendPlayer;
{
    NSLog(@"LocalPlayerListener_player_issuedChallengeWasCompleted_byFriend");
    
    KLocalPlayerListener_player_issuedChallengeWasCompleted_byFriend(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge,
        (__bridge_retained void*) friendPlayer
        );
    
}

- (void)player:(GKPlayer *)player matchEnded:(GKTurnBasedMatch *)match;
{
    NSLog(@"LocalPlayerListener_player_matchEnded");
    
    KLocalPlayerListener_player_matchEnded(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) match
        );
    
}

- (void)player:(GKPlayer *)player didRequestMatchWithRecipients:(NSArray<GKPlayer *> *)recipientPlayers
{
    NSLog(@"LocalPlayerListener_player_didRequestMatchWithRecipients");
    long recipientPlayersCount = [recipientPlayers count];
			void** recipientPlayersBuffer = (void**) malloc(sizeof(void*) * recipientPlayersCount);
			[Converters NSArrayToRetainedCArray:recipientPlayers withBuffer:recipientPlayersBuffer];
    KLocalPlayerListener_player_didRequestMatchWithRecipients(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        recipientPlayersBuffer, recipientPlayersCount
        );
    free(recipientPlayersBuffer);
}

- (void)player:(GKPlayer *)player didCompleteChallenge:(GKChallenge *)challenge issuedByFriend:(GKPlayer *)friendPlayer;
{
    NSLog(@"LocalPlayerListener_player_didCompleteChallenge_issuedByFriend");
    
    KLocalPlayerListener_player_didCompleteChallenge_issuedByFriend(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge,
        (__bridge_retained void*) friendPlayer
        );
    
}

- (void)player:(GKPlayer *)player receivedExchangeCancellation:(GKTurnBasedExchange *)exchange forMatch:(GKTurnBasedMatch *)match;
{
    NSLog(@"LocalPlayerListener_player_receivedExchangeCancellation_forMatch");
    
    KLocalPlayerListener_player_receivedExchangeCancellation_forMatch(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) exchange,
        (__bridge_retained void*) match
        );
    
}

- (void)player:(GKPlayer *)player receivedExchangeReplies:(NSArray<GKTurnBasedExchangeReply *> *)replies forCompletedExchange:(GKTurnBasedExchange *)exchange forMatch:(GKTurnBasedMatch *)match;
{
    NSLog(@"LocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch");
    long repliesCount = [replies count];
			void** repliesBuffer = (void**) malloc(sizeof(void*) * repliesCount);
			[Converters NSArrayToRetainedCArray:replies withBuffer:repliesBuffer];
    KLocalPlayerListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        repliesBuffer, repliesCount,
        (__bridge_retained void*) exchange,
        (__bridge_retained void*) match
        );
    free(repliesBuffer);
}

- (void)player:(GKPlayer *)player receivedExchangeRequest:(GKTurnBasedExchange *)exchange forMatch:(GKTurnBasedMatch *)match;
{
    NSLog(@"LocalPlayerListener_player_receivedExchangeRequest_forMatch");
    
    KLocalPlayerListener_player_receivedExchangeRequest_forMatch(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) exchange,
        (__bridge_retained void*) match
        );
    
}

- (void)player:(GKPlayer *)player didRequestMatchWithOtherPlayers:(NSArray<GKPlayer *> *)playersToInvite;
{
    NSLog(@"LocalPlayerListener_player_didRequestMatchWithOtherPlayers");
    long playersToInviteCount = [playersToInvite count];
			void** playersToInviteBuffer = (void**) malloc(sizeof(void*) * playersToInviteCount);
			[Converters NSArrayToRetainedCArray:playersToInvite withBuffer:playersToInviteBuffer];
    KLocalPlayerListener_player_didRequestMatchWithOtherPlayers(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        playersToInviteBuffer, playersToInviteCount
        );
    free(playersToInviteBuffer);
}

- (void)player:(GKPlayer *)player receivedTurnEventForMatch:(GKTurnBasedMatch *)match didBecomeActive:(BOOL)didBecomeActive;
{
    NSLog(@"LocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive");
    
    KLocalPlayerListener_player_receivedTurnEventForMatch_didBecomeActive(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) match,
        didBecomeActive
        );
    
}

- (void)player:(GKPlayer *)player wantsToQuitMatch:(GKTurnBasedMatch *)match;
{
    NSLog(@"LocalPlayerListener_player_wantsToQuitMatch");
    
    KLocalPlayerListener_player_wantsToQuitMatch(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) match
        );
    
}



@end
