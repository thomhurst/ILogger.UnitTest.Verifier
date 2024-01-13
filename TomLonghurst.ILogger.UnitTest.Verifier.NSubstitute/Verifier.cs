using Microsoft.Extensions.Logging;
using NSubstitute;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Helpers;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute;

internal static class Verifier
{
    public static void PerformVerification
    (
        LoggerVerifyOptions loggerVerifyOptions,
        Microsoft.Extensions.Logging.ILogger loggerMockObject
    )
    {
        loggerMockObject.Received(loggerVerifyOptions.Times).Log(
            Arg.Is<LogLevel>(l => MatchHelper.MatchLogLevel(l, loggerVerifyOptions)),
            Arg.Is<EventId>(e => MatchHelper.MatchEventId(e, loggerVerifyOptions)),
            Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(@object => MatchHelper.MatchText(@object, loggerVerifyOptions, loggerMockObject)),
            Arg.Is<Exception>(e => MatchHelper.MatchException(e, loggerVerifyOptions)),
            Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception?, string>>());
    }

    public static void PerformVerification<T>
    (
        LoggerVerifyOptions loggerVerifyOptions,
        ILogger<T> loggerMock
    )
    {
        loggerMock.Received(loggerVerifyOptions.Times).Log(
            Arg.Is<LogLevel>(l => MatchHelper.MatchLogLevel(l, loggerVerifyOptions)),
            Arg.Is<EventId>(e => MatchHelper.MatchEventId(e, loggerVerifyOptions)),
            Arg.Is<IReadOnlyList<KeyValuePair<string, object>>>(@object => MatchHelper.MatchText(@object, loggerVerifyOptions, loggerMock)),
            Arg.Is<Exception>(e => MatchHelper.MatchException(e, loggerVerifyOptions)),
            Arg.Any<Func<IReadOnlyList<KeyValuePair<string, object>>, Exception?, string>>());
    }
}