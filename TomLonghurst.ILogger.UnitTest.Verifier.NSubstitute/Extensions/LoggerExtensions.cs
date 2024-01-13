using Microsoft.Extensions.Logging;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;

public static class LoggerExtensions
{
    public static void Verify(this Microsoft.Extensions.Logging.ILogger loggerMock, string message)
    {
        Verify(loggerMock, message, null);
    }

    public static void Verify(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, LogLevel? logLevel)
    {
        Verify(loggerMock, message, logLevel, null);
    }
    
    public static void Verify(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, LogLevel? logLevel, Func<int>? times)
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
    
    public static void Verify(this Microsoft.Extensions.Logging.ILogger loggerMock, LoggerVerifyOptions loggerVerifyOptions)
    {
        Verifier.PerformVerification(loggerVerifyOptions, loggerMock);
    }

    public static void VerifyTrace(this Microsoft.Extensions.Logging.ILogger loggerMock, string message)
    {
        VerifyTrace(loggerMock, message, null);
    }

    public static void VerifyTrace(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Trace, times);
    }

    public static void VerifyError(this Microsoft.Extensions.Logging.ILogger loggerMock, string message)
    {
        VerifyError(loggerMock, message, null);
    }

    public static void VerifyError(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Error, times);
    }

    public static void VerifyInformation(this Microsoft.Extensions.Logging.ILogger loggerMock, string message)
    {
        VerifyInformation(loggerMock, message, null);
    }

    public static void VerifyInformation(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Information, times);
    }

    public static void VerifyWarning(this Microsoft.Extensions.Logging.ILogger loggerMock, string message)
    {
        VerifyWarning(loggerMock, message, null);
    }

    public static void VerifyWarning(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Warning, times);
    }

    public static void VerifyCritical(this Microsoft.Extensions.Logging.ILogger loggerMock, string message)
    {
        VerifyCritical(loggerMock, message, null);
    }

    public static void VerifyCritical(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Critical, times);
    }

    public static void VerifyDebug(this Microsoft.Extensions.Logging.ILogger loggerMock, string message)
    {
        VerifyDebug(loggerMock, message, null);
    }

    public static void VerifyDebug(this Microsoft.Extensions.Logging.ILogger loggerMock, string message, Func<int>? times)
    {
        Verify(loggerMock, message, LogLevel.Debug, times);
    }
}