﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
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
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = message
                }
            },
            LogLevel = logLevel,
            Times = times?.Invoke()
        });
    }
    
    public static void Verify(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, LoggerVerifyOptions loggerVerifyOptions)
    {
        loggerMock.Verify(Verifier.GetVerifierExpression(loggerVerifyOptions, loggerMock),
            loggerVerifyOptions.Times ?? Times.Once()
        );
    }

    public static void VerifyTrace(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message)
    {
        VerifyTrace(loggerMock, message, null);
    }

    public static void VerifyTrace(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Trace, times);
    }

    public static void VerifyError(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message)
    {
        VerifyError(loggerMock, message, null);
    }

    public static void VerifyError(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Error, times);
    }

    public static void VerifyInformation(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message)
    {
        VerifyInformation(loggerMock, message, null);
    }

    public static void VerifyInformation(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Information, times);
    }

    public static void VerifyWarning(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message)
    {
        VerifyWarning(loggerMock, message, null);
    }

    public static void VerifyWarning(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Warning, times);
    }

    public static void VerifyCritical(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message)
    {
        VerifyCritical(loggerMock, message, null);
    }

    public static void VerifyCritical(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Critical, times);
    }

    public static void VerifyDebug(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message)
    {
        VerifyDebug(loggerMock, message, null);
    }

    public static void VerifyDebug(this Mock<Microsoft.Extensions.Logging.ILogger> loggerMock, string message, Func<Times>? times)
    {
        Verify(loggerMock, message, LogLevel.Debug, times);
    }
}