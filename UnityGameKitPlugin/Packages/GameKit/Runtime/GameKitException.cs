using System;

namespace HovelHouse.GameKit
{
    public class GameKitException : Exception
    {
        public NSException NSException { get; }
        public GameKitException(NSException nativeException, string message) : base(message)
        {
            NSException = nativeException;
        }
    }
}