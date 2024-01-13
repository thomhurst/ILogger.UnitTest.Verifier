using Microsoft.Extensions.Logging;
using NSubstitute;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.UnitTests;

public class ContainsTests
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
        _logger.LogInformation("Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = "message",
                    MessageMatchMethod = MessageMatchMethod.Contains,
                }
            },
            LogLevel = LogLevel.Information
        });
        _loggerMock.VerifyInformation("Some message");
    }
    
    [Test]
    public void Error_Message()
    {
        _logger.LogError("Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = "message",
                    MessageMatchMethod = MessageMatchMethod.Contains,
                }
            },
            LogLevel = LogLevel.Error
        });       
        _loggerMock.VerifyError("Some message");
    }
    
    [Test]
    public void Warning_Message()
    {
        _logger.LogWarning("Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = "message",
                    MessageMatchMethod = MessageMatchMethod.Contains,
                }
            },
            LogLevel = LogLevel.Warning
        });
        _loggerMock.VerifyWarning("Some message");
    }
    
    [Test]
    public void Debug_Message()
    {
        _logger.LogDebug("Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = "message",
                    MessageMatchMethod = MessageMatchMethod.Contains,
                }
            },
            LogLevel = LogLevel.Debug
        });
        _loggerMock.VerifyDebug("Some message");
    }
    
    [Test]
    public void Trace_Message()
    {
        _logger.LogTrace("Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = "message",
                    MessageMatchMethod = MessageMatchMethod.Contains,
                }
            },
            LogLevel = LogLevel.Trace
        });
        _loggerMock.VerifyTrace("Some message");
    }
    
    [Test]
    public void Critical_Message()
    {
        _logger.LogCritical("Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                FormattedMessageOptions =
                {
                    Message = "message",
                    MessageMatchMethod = MessageMatchMethod.Contains,
                }
            },
            LogLevel = LogLevel.Critical
        });
        _loggerMock.VerifyCritical("Some message");
    }
}