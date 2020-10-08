#import "GameKitInitializer.h"
#import "Converters.h"
#import "TurnBasedEventListener.h"

void* TurnBasedEventListener_init(
    void** exceptionPtr)
{
    @try
    {
        TurnBasedEventListener* inst = [[TurnBasedEventListener alloc] init];
            return (__bridge_retained void*) inst;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void TurnBasedEventListener_Dispose(void* ptr)
{
    TurnBasedEventListener* val = (__bridge TurnBasedEventListener*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...TurnBasedEventListener");
}

@implementation TurnBasedEventListener

- (void)player:(GKPlayer *)player receivedExchangeCancellation:(GKTurnBasedExchange *)exchange forMatch:(GKTurnBasedMatch *)match;
{
    NSLog(@"TurnBasedEventListener_player_receivedExchangeCancellation_forMatch");
    
    KTurnBasedEventListener_player_receivedExchangeCancellation_forMatch(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) exchange,
        (__bridge_retained void*) match
        );
    
}

- (void)player:(GKPlayer *)player receivedExchangeReplies:(NSArray<GKTurnBasedExchangeReply *> *)replies forCompletedExchange:(GKTurnBasedExchange *)exchange forMatch:(GKTurnBasedMatch *)match;
{
    NSLog(@"TurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch");
    long repliesCount = [replies count];
			void** repliesBuffer = (void**) malloc(sizeof(void*) * repliesCount);
			[Converters NSArrayToRetainedCArray:replies withBuffer:repliesBuffer];
    KTurnBasedEventListener_player_receivedExchangeReplies_forCompletedExchange_forMatch(
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
    NSLog(@"TurnBasedEventListener_player_receivedExchangeRequest_forMatch");
    
    KTurnBasedEventListener_player_receivedExchangeRequest_forMatch(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) exchange,
        (__bridge_retained void*) match
        );
    
}

- (void)player:(GKPlayer *)player didRequestMatchWithOtherPlayers:(NSArray<GKPlayer *> *)playersToInvite;
{
    NSLog(@"TurnBasedEventListener_player_didRequestMatchWithOtherPlayers");
    long playersToInviteCount = [playersToInvite count];
			void** playersToInviteBuffer = (void**) malloc(sizeof(void*) * playersToInviteCount);
			[Converters NSArrayToRetainedCArray:playersToInvite withBuffer:playersToInviteBuffer];
    KTurnBasedEventListener_player_didRequestMatchWithOtherPlayers(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        playersToInviteBuffer, playersToInviteCount
        );
    free(playersToInviteBuffer);
}

- (void)player:(GKPlayer *)player matchEnded:(GKTurnBasedMatch *)match;
{
    NSLog(@"TurnBasedEventListener_player_matchEnded");
    
    KTurnBasedEventListener_player_matchEnded(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) match
        );
    
}

- (void)player:(GKPlayer *)player receivedTurnEventForMatch:(GKTurnBasedMatch *)match didBecomeActive:(BOOL)didBecomeActive;
{
    NSLog(@"TurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive");
    
    KTurnBasedEventListener_player_receivedTurnEventForMatch_didBecomeActive(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) match,
        didBecomeActive
        );
    
}

- (void)player:(GKPlayer *)player wantsToQuitMatch:(GKTurnBasedMatch *)match;
{
    NSLog(@"TurnBasedEventListener_player_wantsToQuitMatch");
    
    KTurnBasedEventListener_player_wantsToQuitMatch(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) match
        );
    
}



@end
