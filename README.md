# ILogger.UnitTest.Verifier
Verify ILogger calls more easily.

[![nuget](https://img.shields.io/nuget/v/TomLonghurst.ILogger.UnitTest.Verifier.Moq.svg)](https://www.nuget.org/packages/TomLonghurst.ILogger.UnitTest.Verifier.Moq/)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/f654e7d05b0d45e89a1182207024c3a3)](https://www.codacy.com/gh/thomhurst/ILogger.UnitTest.Verifier/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=thomhurst/ILogger.UnitTest.Verifier&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/thomhurst/ilogger.unittest.verifier/badge)](https://www.codefactor.io/repository/github/thomhurst/ilogger.unittest.verifier)

## Installation
.NET 6 Required

Install via Nuget
`Install-Package TomLonghurst.ILogger.UnitTest.Verifier.Moq`

## Why?
Because verifying calls to `ILogger` is a pain in the ****!

## Moq

### Examples

#### Log Level Extensions

```csharp
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
```

### Fluent Options Extension

```csharp
    [Test]
    public void Info_Message()
    {
        _logger.LogInformation(123, new TestException(), "Some message");
        _loggerMock.Verify(new LoggerVerifyOptions
        {
            EventId = 123,
            ExceptionType = typeof(TestException),
            Message = "SOME MESSAGE",
            MessageMatchMethod = MessageMatchMethod.Equals,
            StringComparison = StringComparison.OrdinalIgnoreCase,
            LogLevel = LogLevel.Information
        });
    }
```
