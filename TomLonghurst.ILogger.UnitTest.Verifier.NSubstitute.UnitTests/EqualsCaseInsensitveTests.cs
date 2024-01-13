using Microsoft.Extensions.Logging;
using NSubstitute;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.UnitTests;

public class EqualsCaseInsensitveTests
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
                    Message = "SOME MESSAGE",
                    MessageMatchMethod = MessageMatchMethod.Equals,
                    StringComparison = StringComparison.OrdinalIgnoreCase,
                }
            },
            LogLevel = LogLevel.Information
        });
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
                    Message = "SOME MESSAGE",
                    MessageMatchMethod = MessageMatchMethod.Equals,
                    StringComparison = StringComparison.OrdinalIgnoreCase,
                }
            },
            LogLevel = LogLevel.Error
        });       
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
                    Message = "SOME MESSAGE",
                    MessageMatchMethod = MessageMatchMethod.Equals,
                    StringComparison = StringComparison.OrdinalIgnoreCase,
                }
            },
            LogLevel = LogLevel.Warning
        });
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
                    Message = "SOME MESSAGE",
                    MessageMatchMethod = MessageMatchMethod.Equals,
                    StringComparison = StringComparison.OrdinalIgnoreCase,
                }
            },
            LogLevel = LogLevel.Debug
        });
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
                    Message = "SOME MESSAGE",
                    MessageMatchMethod = MessageMatchMethod.Equals,
                    StringComparison = StringComparison.OrdinalIgnoreCase,
                }
            },
            LogLevel = LogLevel.Trace
        });
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
                    Message = "SOME MESSAGE",
                    MessageMatchMethod = MessageMatchMethod.Equals,
                    StringComparison = StringComparison.OrdinalIgnoreCase,
                }
            },
            LogLevel = LogLevel.Critical
        });
    }
    
    [Test]
    public void Info_Message2()
    {
        _logger.LogInformation(123, new TestException("My exception message"), "Value was: {Value}", "Zero");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            ExceptionOptions =
            {
                ExceptionType = typeof(TestException),
                Message = "My exception message",
                StringComparison = StringComparison.Ordinal,
                MessageMatchMethod = MessageMatchMethod.Equals
            },
            MessageOptions =
            {
                MessageTemplateOptions =
                {
                    MessageTemplate = "Value was: {Value}",
                    StringComparison = StringComparison.Ordinal,
                    MessageMatchMethod = MessageMatchMethod.Equals
                },
                FormattedMessageOptions =
                {
                    Message = "Value was: Zero",
                    StringComparison = StringComparison.Ordinal,
                    MessageMatchMethod = MessageMatchMethod.Equals
                },
                MessageParametersOptions =
                {
                    Parameters = new []{ new KeyValuePair<string, object>("Value", "Zero") },
                    StringComparison = StringComparison.Ordinal,
                    MessageMatchMethod = MessageMatchMethod.Equals
                }
            },
            LogLevel = LogLevel.Information,
            Times = 1
        });
    }
}