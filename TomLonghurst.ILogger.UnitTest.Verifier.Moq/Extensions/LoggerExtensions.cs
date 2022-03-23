using Microsoft.Extensions.Logging;
using Moq;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;

public static partial class LoggerExtensions
{
    public static void Verify(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message)
    {
        Verify(loggerMock, message, null);
    }

    public static void Verify(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, LogLevel? logLevel)
    {
        Verify(loggerMock, message, logLevel, null);
    }
    
    public static void Verify(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, LogLevel? logLevel, Func<Times>? times)
    {
        Verify(loggerMock, new LoggerVerifyOptions
        {
            Message = message,
            LogLevel = logLevel,
            Times = times?.Invoke()
        });
    }
    
    public static void Verify(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, LoggerVerifyOptions loggerVerifyOptions)
    {
        loggerMock.Verify(logger => logger.Log(
                It.Is<LogLevel>(l => MatchLogLevel(l, loggerVerifyOptions)),
                It.Is<EventId>(e => MatchEventId(e, loggerVerifyOptions)),
                It.Is<It.IsAnyType>((@object, @type) => MatchText(@object.ToString(), loggerVerifyOptions)),
                It.Is<Exception>(e => MatchException(e, loggerVerifyOptions)),
                It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            loggerVerifyOptions.Times ?? Times.Once()
        );
    }

    public static void VerifyTrace(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times = null)
    {
        Verify(loggerMock, message, LogLevel.Trace, times);
    }

    public static void VerifyError(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times = null)
    {
        Verify(loggerMock, message, LogLevel.Error, times);
    }

    public static void VerifyInformation(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times = null)
    {
        Verify(loggerMock, message, LogLevel.Information, times);
    }

    public static void VerifyWarning(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times = null)
    {
        Verify(loggerMock, message, LogLevel.Warning, times);
    }

    public static void VerifyCritical(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times = null)
    {
        Verify(loggerMock, message, LogLevel.Critical, times);
    }

    public static void VerifyDebug(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times = null)
    {
        Verify(loggerMock, message, LogLevel.Debug, times);
    }

    private static bool MatchLogLevel(LogLevel? logLevel, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.LogLevel == null)
        {
            return true;
        }

        return logLevel == loggerVerifyOptions.LogLevel;
    }

    private static bool MatchText(string? message, LoggerVerifyOptions loggerVerifyOptions)
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

    private static bool MatchException(Exception e, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.ExceptionType == null)
        {
            return true;
        }
        
        return e.GetType() == loggerVerifyOptions.ExceptionType;
    }

    private static bool MatchEventId(EventId? eventId, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (eventId == null)
        {
            return true;
        }

        return eventId == loggerVerifyOptions.EventId;
    }
}