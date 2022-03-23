using Microsoft.Extensions.Logging;
using Moq;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Helpers;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;

public static class LoggerExtensions
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
        loggerMock.Verify(Verifier.GetVerifierExpression(loggerVerifyOptions),
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
}