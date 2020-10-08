#import "GameKitInitializer.h"
#import "Converters.h"
#import "MatchDelegate.h"

void* MatchDelegate_init(
    void** exceptionPtr)
{
    @try
    {
        MatchDelegate* inst = [[MatchDelegate alloc] init];
            return (__bridge_retained void*) inst;
    }
    @catch(NSException* ex)
    {
        *exceptionPtr = (__bridge_retained void*)ex;
    }

    return nil;
}

void MatchDelegate_Dispose(void* ptr)
{
    MatchDelegate* val = (__bridge MatchDelegate*) ptr;
    if(val != nil)
    {
        CFRelease(ptr);
    }
    NSLog(@"Dispose...MatchDelegate");
}

@implementation MatchDelegate

- (void)match:(GKMatch *)match player:(GKPlayer *)player didChangeConnectionState:(GKPlayerConnectionState)state;
{
    NSLog(@"MatchDelegate_match_player_didChangeConnectionState");
    
    KMatchDelegate_match_player_didChangeConnectionState(
        (__bridge void*) self,
        (__bridge_retained void*) match,
        (__bridge_retained void*) player,
        state
        );
    
}

- (void)match:(GKMatch *)match didFailWithError:(NSError *)error;
{
    NSLog(@"MatchDelegate_match_didFailWithError");
    
    KMatchDelegate_match_didFailWithError(
        (__bridge void*) self,
        (__bridge_retained void*) match,
        (__bridge_retained void*) error
        );
    
}

- (void)match:(GKMatch *)match didReceiveData:(NSData *)data fromRemotePlayer:(GKPlayer *)player;
{
    KMatchDelegate_match_didReceiveData_fromRemotePlayer(
        (__bridge void*) self,
        [data bytes], [data length],
        [[player gamePlayerID] UTF8String]
        );
}
- (void)match:(GKMatch *)match didReceiveData:(NSData *)data forRecipient:(GKPlayer *)recipient fromRemotePlayer:(GKPlayer *)player;
{
    KMatchDelegate_match_didReceiveData_forRecipient_fromRemotePlayer(
        (__bridge void*) self,
        [data bytes], [data length],
        [[recipient gamePlayerID] UTF8String],
        [[player gamePlayerID] UTF8String]
        );
}
- (BOOL)match:(GKMatch *)match shouldReinviteDisconnectedPlayer:(GKPlayer *)player;
{
    NSLog(@"MatchDelegate_match_shouldReinviteDisconnectedPlayer");
    
    return KMatchDelegate_match_shouldReinviteDisconnectedPlayer(
        (__bridge void*) self,
        (__bridge_retained void*) match,
        (__bridge_retained void*) player
        );
    
}



@end
