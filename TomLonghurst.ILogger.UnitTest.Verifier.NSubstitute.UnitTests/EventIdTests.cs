using Microsoft.Extensions.Logging;
using NSubstitute;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.UnitTests;

public class EventIdTests
{
    private TestLogger _logger = null!;
    private Microsoft.Extensions.Logging.ILogger _loggerMock = null!;

    [SetUp]
    public void Setup()
    {
        _loggerMock = Substitute.For<Microsoft.Extensions.Logging.ILogger>();
        _logger = new TestLogger(_loggerMock);
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