#import "GameKitInitializer.h"
#import "Converters.h"
#import "ChallengeListener.h"

void* ChallengeListener_init(
    void** exceptionPtr)
{
    @try
    {
        ChallengeListener* inst = [[ChallengeListener alloc] init];
            return (__bridge_retained void*) inst;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void ChallengeListener_Dispose(void* ptr)
{
    ChallengeListener* val = (__bridge ChallengeListener*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...ChallengeListener");
}

@implementation ChallengeListener

- (void)player:(GKPlayer *)player didReceiveChallenge:(GKChallenge *)challenge;
{
    NSLog(@"ChallengeListener_player_didReceiveChallenge");
    
    KChallengeListener_player_didReceiveChallenge(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge
        );
    
}

- (void)player:(GKPlayer *)player wantsToPlayChallenge:(GKChallenge *)challenge;
{
    NSLog(@"ChallengeListener_player_wantsToPlayChallenge");
    
    KChallengeListener_player_wantsToPlayChallenge(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge
        );
    
}

- (void)player:(GKPlayer *)player didCompleteChallenge:(GKChallenge *)challenge issuedByFriend:(GKPlayer *)friendPlayer;
{
    NSLog(@"ChallengeListener_player_didCompleteChallenge_issuedByFriend");
    
    KChallengeListener_player_didCompleteChallenge_issuedByFriend(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge,
        (__bridge_retained void*) friendPlayer
        );
    
}

- (void)player:(GKPlayer *)player issuedChallengeWasCompleted:(GKChallenge *)challenge byFriend:(GKPlayer *)friendPlayer;
{
    NSLog(@"ChallengeListener_player_issuedChallengeWasCompleted_byFriend");
    
    KChallengeListener_player_issuedChallengeWasCompleted_byFriend(
        (__bridge void*) self,
        (__bridge_retained void*) player,
        (__bridge_retained void*) challenge,
        (__bridge_retained void*) friendPlayer
        );
    
}



@end
