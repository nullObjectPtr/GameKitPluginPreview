#import "GameKitInitializer.h"
#import "Converters.h"
#import "MatchmakerViewControllerDelegate.h"

void* MatchmakerViewControllerDelegate_init(
    void** exceptionPtr)
{
    @try
    {
        MatchmakerViewControllerDelegate* inst = [[MatchmakerViewControllerDelegate alloc] init];
            return (__bridge_retained void*) inst;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void MatchmakerViewControllerDelegate_Dispose(void* ptr)
{
    MatchmakerViewControllerDelegate* val = (__bridge MatchmakerViewControllerDelegate*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...MatchmakerViewControllerDelegate");
}

@implementation MatchmakerViewControllerDelegate

- (void)matchmakerViewController:(GKMatchmakerViewController*)viewController didFindMatch:(GKMatch *)match
{
    NSLog(@"MatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch");
    
    KMatchmakerViewControllerDelegate_matchmakerViewController_didFindMatch(
        (__bridge void*) self,
        (__bridge_retained void*) viewController,
        (__bridge_retained void*) match
        );
    
}

- (void)matchmakerViewControllerWasCancelled:(GKMatchmakerViewController*)viewController
{
    NSLog(@"MatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled");
    
    KMatchmakerViewControllerDelegate_matchmakerViewControllerWasCancelled(
        (__bridge void*) self,
        (__bridge_retained void*) viewController
        );
    
}

- (void)matchmakerViewController:(GKMatchmakerViewController*)viewController didFailWithError:(NSError *)error
{
    NSLog(@"MatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError");
    
    KMatchmakerViewControllerDelegate_matchmakerViewController_didFailWithError(
        (__bridge void*) self,
        (__bridge_retained void*) viewController,
        (__bridge_retained void*) error
        );
    
}

- (void)matchmakerViewController:(GKMatchmakerViewController*)viewController hostedPlayerDidAccept:(GKPlayer *)player
{
    NSLog(@"MatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept");
    
    KMatchmakerViewControllerDelegate_matchmakerViewController_hostedPlayerDidAccept(
        (__bridge void*) self,
        (__bridge_retained void*) viewController,
        (__bridge_retained void*) player
        );
    
}

- (void)matchmakerViewController:(GKMatchmakerViewController*)viewController didFindHostedPlayers:(NSArray<GKPlayer *> *)players;
{
    NSLog(@"MatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers");
    long playersCount = [players count];
			void** playersBuffer = nil;
			if(playersCount > 0)
			{
				playersBuffer = (void**) malloc(sizeof(void*) * playersCount);
				[Converters NSArrayToRetainedCArray:players withBuffer:playersBuffer];
			}
    KMatchmakerViewControllerDelegate_matchmakerViewController_didFindHostedPlayers(
        (__bridge void*) self,
        (__bridge_retained void*) viewController,
        playersBuffer, playersCount
        );
    free(playersBuffer);
}



@end
