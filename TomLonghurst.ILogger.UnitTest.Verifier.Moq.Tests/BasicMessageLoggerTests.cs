using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Tests;

public class BasicMessageLoggerTests
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
        _logger.LogInformation("Some message");
        _loggerMock.Verify("Some message");
    }
    
    [Test]
    public void Error_Message()
    {
        _logger.LogError("Some message");
        _loggerMock.Verify("Some message");
    }
    
    [Test]
    public void Warning_Message()
    {
        _logger.LogWarning("Some message");
        _loggerMock.Verify("Some message");
    }
    
    [Test]
    public void Debug_Message()
    {
        _logger.LogDebug("Some message");
        _loggerMock.Verify("Some message");
    }
    
    [Test]
    public void Trace_Message()
    {
        _logger.LogTrace("Some message");
        _loggerMock.Verify("Some message");
    }
    
    [Test]
    public void Critical_Message()
    {
        _logger.LogCritical("Some message");
        _loggerMock.Verify("Some message");
    }
}