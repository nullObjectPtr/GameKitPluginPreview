#import "GameKitInitializer.h"
#import "Converters.h"
#import "GKTurnBasedMatchmakerViewControllerDelegate.h"

void* GKTurnBasedMatchmakerViewControllerDelegate_init(
    void** exceptionPtr)
{
    @try
    {
        GKTurnBasedMatchmakerViewControllerDelegate* inst = [[GKTurnBasedMatchmakerViewControllerDelegate alloc] init];
            return (__bridge_retained void*) inst;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void GKTurnBasedMatchmakerViewControllerDelegate_Dispose(void* ptr)
{
    GKTurnBasedMatchmakerViewControllerDelegate* val = (__bridge GKTurnBasedMatchmakerViewControllerDelegate*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...GKTurnBasedMatchmakerViewControllerDelegate");
}

@implementation GKTurnBasedMatchmakerViewControllerDelegate

- (void)turnBasedMatchmakerViewControllerWasCancelled:(GKTurnBasedMatchmakerViewController *)viewController;
{
    NSLog(@"GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled");
    
    KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewControllerWasCancelled(
        (__bridge void*) self,
        (__bridge_retained void*) viewController
        );
    
}

- (void)turnBasedMatchmakerViewController:(GKTurnBasedMatchmakerViewController *)viewController didFailWithError:(NSError *)error;
{
    NSLog(@"GKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError");
    
    KGKTurnBasedMatchmakerViewControllerDelegate_turnBasedMatchmakerViewController_didFailWithError(
        (__bridge void*) self,
        (__bridge_retained void*) viewController,
        (__bridge_retained void*) error
        );
    
}



@end
