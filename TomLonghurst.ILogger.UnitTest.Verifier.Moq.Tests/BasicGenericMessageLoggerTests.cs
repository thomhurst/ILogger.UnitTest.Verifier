using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Tests;

public class BasicGenericMessageLoggerTests
{
    private TestLogger _logger;
    private Mock<ILogger<BasicGenericMessageLoggerTests>> _loggerMock;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<BasicGenericMessageLoggerTests>>();
        _logger = new TestLogger(_loggerMock.Object);
    }

    [Test]
    public void Basic_Message_Only()
    {
        _logger.LogInformation("Some message");
        _loggerMock.Verify("Some message");
        _loggerMock.VerifyInformation("Some message");
    }

    [Test]
    public void Info_Message()
    {
        _logger.LogInformation("Some message");
        _loggerMock.Verify("Some message", LogLevel.Information);
        _loggerMock.VerifyInformation("Some message");
    }
    
    [Test]
    public void Error_Message()
    {
        _logger.LogError("Some message");
        _loggerMock.Verify("Some message", LogLevel.Error);
        _loggerMock.VerifyError("Some message");
    }
    
    [Test]
    public void Warning_Message()
    {
        _logger.LogWarning("Some message");
        _loggerMock.Verify("Some message", LogLevel.Warning);
        _loggerMock.VerifyWarning("Some message");
    }
    
    [Test]
    public void Debug_Message()
    {
        _logger.LogDebug("Some message");
        _loggerMock.Verify("Some message", LogLevel.Debug);
        _loggerMock.VerifyDebug("Some message");
    }
    
    [Test]
    public void Trace_Message()
    {
        _logger.LogTrace("Some message");
        _loggerMock.Verify("Some message", LogLevel.Trace);
        _loggerMock.VerifyTrace("Some message");
    }
    
    [Test]
    public void Critical_Message()
    {
        _logger.LogCritical("Some message");
        _loggerMock.Verify("Some message", LogLevel.Critical);
        _loggerMock.VerifyCritical("Some message");
    }
}