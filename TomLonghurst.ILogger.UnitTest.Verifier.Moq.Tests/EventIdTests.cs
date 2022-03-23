using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Tests;

public class EventIdTests
{
    private TestLogger _logger;
    private Mock<Microsoft.Extensions.Logging.ILogger> _loggerMock;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<Microsoft.Extensions.Logging.ILogger>();
        _logger = new TestLogger(_loggerMock.Object);
    }

    [Test]
    public void Info_Message()
    {
        _logger.LogInformation(123, new TestException(), "Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            LogLevel = LogLevel.Information
        });
    }
    
    [Test]
    public void Error_Message()
    {
        _logger.LogError(123, new TestException(), "Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            LogLevel = LogLevel.Error
        });       
    }
    
    [Test]
    public void Warning_Message()
    {
        _logger.LogWarning(123, new TestException(), "Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            LogLevel = LogLevel.Warning
        });
    }
    
    [Test]
    public void Debug_Message()
    {
        _logger.LogDebug(123, new TestException(), "Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            LogLevel = LogLevel.Debug
        });
    }
    
    [Test]
    public void Trace_Message()
    {
        _logger.LogTrace(123, new TestException(), "Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            LogLevel = LogLevel.Trace
        });
    }
    
    [Test]
    public void Critical_Message()
    {
        _logger.LogCritical(123, new TestException(), "Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            LogLevel = LogLevel.Critical
        });
    }
}