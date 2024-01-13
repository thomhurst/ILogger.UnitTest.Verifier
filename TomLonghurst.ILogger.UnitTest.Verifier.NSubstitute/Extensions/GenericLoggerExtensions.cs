using Microsoft.Extensions.Logging;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;

public static class GenericLoggerExtensions
{
    public static void Verify<T>(this ILogger<T> loggerMock, string message)
    {
        Verify(loggerMock, message, null);
    }

    public static void Verify<T>(this ILogger<T> loggerMock, string message, LogLevel? logLevel)
    {
        Verify(loggerMock, message, logLevel, null);
    }
    
    public static void Verify<T>(this ILogger<T> loggerMock, string message, LogLevel? logLevel, Func<int>? times)
    {
        Verify(loggerMock, new LoggerVerifyOptions
        {
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = message
                }
            },
            LogLevel = logLevel,
            Times = times?.Invoke() ?? 1
        });
    }
    
    public static void Verify<T>(this ILogger<T> loggerMock, LoggerVerifyOptions loggerVerifyOptions)
    {
        Verifier.PerformVerification(loggerVerifyOptions, loggerMock);
    }

    public static void VerifyTrace<T>(this ILogger<T> loggerMock, string message)
    {
        VerifyTrace(loggerMock, message, null);
    }

    public static void VerifyTrace<T>(this ILogger<T> loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Trace, times);
    }

    public static void VerifyError<T>(this ILogger<T> loggerMock, string message)
    {
        VerifyError(loggerMock, message, null);
    }

    public static void VerifyError<T>(this ILogger<T> loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Error, times);
    }

    public static void VerifyInformation<T>(this ILogger<T> loggerMock, string message)
    {
        VerifyInformation(loggerMock, message, null);
    }

    public static void VerifyInformation<T>(this ILogger<T> loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Information, times);
    }

    public static void VerifyWarning<T>(this ILogger<T> loggerMock, string message)
    {
        VerifyWarning(loggerMock, message, null);
    }

    public static void VerifyWarning<T>(this ILogger<T> loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Warning, times);
    }

    public static void VerifyCritical<T>(this ILogger<T> loggerMock, string message)
    {
        VerifyCritical(loggerMock, message, null);
    }

    public static void VerifyCritical<T>(this ILogger<T> loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Critical, times);
    }

    public static void VerifyDebug<T>(this ILogger<T> loggerMock, string message)
    {
        VerifyDebug(loggerMock, message, null);
    }

    public static void VerifyDebug<T>(this ILogger<T> loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Debug, times);
    }
}