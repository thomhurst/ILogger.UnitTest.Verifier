using Microsoft.Extensions.Logging;
using Moq;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;

public static class GenericLoggerExtensions
{
    public static void Verify<T>(this Mock<ILogger<T>> loggerMock, string message)
    {
        Verify(loggerMock, message, null);
    }

    public static void Verify<T>(this Mock<ILogger<T>> loggerMock, string message, LogLevel? logLevel)
    {
        Verify(loggerMock, message, logLevel, null);
    }
    
    public static void Verify<T>(this Mock<ILogger<T>> loggerMock, string message, LogLevel? logLevel, Func<Times>? times)
    {
        Verify(loggerMock, new LoggerVerifyOptions
        {
            Message = message,
            LogLevel = logLevel,
            Times = times?.Invoke()
        });
    }
    
    public static void Verify<T>(this Mock<ILogger<T>> loggerMock, LoggerVerifyOptions loggerVerifyOptions)
    {
        loggerMock.Verify(Verifier.GetGenericVerifierExpression<T>(loggerVerifyOptions),
            loggerVerifyOptions.Times ?? Times.Once()
        );
    }

    public static void VerifyTrace<T>(this Mock<ILogger<T>> loggerMock, string message)
    {
        VerifyTrace(loggerMock, message, null);
    }

    public static void VerifyTrace<T>(this Mock<ILogger<T>> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Trace, times);
    }

    public static void VerifyError<T>(this Mock<ILogger<T>> loggerMock, string message)
    {
        VerifyError(loggerMock, message, null);
    }

    public static void VerifyError<T>(this Mock<ILogger<T>> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Error, times);
    }

    public static void VerifyInformation<T>(this Mock<ILogger<T>> loggerMock, string message)
    {
        VerifyInformation(loggerMock, message, null);
    }

    public static void VerifyInformation<T>(this Mock<ILogger<T>> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Information, times);
    }

    public static void VerifyWarning<T>(this Mock<ILogger<T>> loggerMock, string message)
    {
        VerifyWarning(loggerMock, message, null);
    }

    public static void VerifyWarning<T>(this Mock<ILogger<T>> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Warning, times);
    }

    public static void VerifyCritical<T>(this Mock<ILogger<T>> loggerMock, string message)
    {
        VerifyCritical(loggerMock, message, null);
    }

    public static void VerifyCritical<T>(this Mock<ILogger<T>> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Critical, times);
    }

    public static void VerifyDebug<T>(this Mock<ILogger<T>> loggerMock, string message)
    {
        VerifyDebug(loggerMock, message, null);
    }

    public static void VerifyDebug<T>(this Mock<ILogger<T>> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Debug, times);
    }
}