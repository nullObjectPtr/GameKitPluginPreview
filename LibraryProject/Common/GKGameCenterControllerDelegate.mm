#import "GameKitInitializer.h"
#import "Converters.h"
#import "GKGameCenterControllerDelegate.h"



@implementation MyGameCenterControllerDelegate

- (id) initWithController:(GKGameCenterViewController*) controller {    
    self = [super init];
    [self setController:controller];
    return self;
}

- (void)gameCenterViewControllerDidFinish:(nonnull GKGameCenterViewController *)gameCenterViewController {
    KGKGameCenterControllerDelegate_gameCenterViewControllerDidFinish(
        (__bridge void*) _controller
        );
}

@end
