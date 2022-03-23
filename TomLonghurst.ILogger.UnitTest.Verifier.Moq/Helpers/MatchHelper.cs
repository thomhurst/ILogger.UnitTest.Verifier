using Microsoft.Extensions.Logging;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Helpers;

internal static class MatchHelper
{
    public static bool MatchLogLevel(LogLevel? logLevel, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.LogLevel == null)
        {
            return true;
        }

        return logLevel == loggerVerifyOptions.LogLevel;
    }

    public static bool MatchText(string? message, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.Message == null)
        {
            return true;
        }
        
        if (loggerVerifyOptions.MessageMatchMethod == MessageMatchMethod.Equals)
        {
            return string.Equals(message, loggerVerifyOptions.Message, loggerVerifyOptions.StringComparison);
        }

        return message.Contains(loggerVerifyOptions.Message, loggerVerifyOptions.StringComparison);
    }

    public static bool MatchException(Exception e, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.ExceptionType == null)
        {
            return true;
        }
        
        return e.GetType() == loggerVerifyOptions.ExceptionType;
    }

    public static bool MatchEventId(EventId? eventId, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.EventId == null)
        {
            return true;
        }

        return eventId == loggerVerifyOptions.EventId;
    }
}