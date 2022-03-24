using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Moq;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Helpers;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq;

internal static class Verifier
{
    public static Expression<Action<Microsoft.Extensions.Logging.ILogger>> GetVerifierExpression(
        LoggerVerifyOptions loggerVerifyOptions, Microsoft.Extensions.Logging.ILogger loggerMockObject)
    {
        return logger => logger.Log(
            It.Is<LogLevel>(l => MatchHelper.MatchLogLevel(l, loggerVerifyOptions)),
            It.Is<EventId>(e => MatchHelper.MatchEventId(e, loggerVerifyOptions)),
            It.Is<It.IsAnyType>((@object, @type) => MatchHelper.MatchText(@object, loggerVerifyOptions)),
            It.Is<Exception>(e => MatchHelper.MatchException(e, loggerVerifyOptions)),
            It.IsAny<Func<It.IsAnyType, Exception?, string>>());
    }
    
    public static Expression<Action<ILogger<T>>> GetGenericVerifierExpression<T>(LoggerVerifyOptions loggerVerifyOptions)
    {
        return logger => logger.Log(
            It.Is<LogLevel>(l => MatchHelper.MatchLogLevel(l, loggerVerifyOptions)),
            It.Is<EventId>(e => MatchHelper.MatchEventId(e, loggerVerifyOptions)),
            It.Is<It.IsAnyType>((@object, @type) => MatchHelper.MatchText(@object, loggerVerifyOptions)),
            It.Is<Exception>(e => MatchHelper.MatchException(e, loggerVerifyOptions)),
            It.IsAny<Func<It.IsAnyType, Exception?, string>>());
    }
}