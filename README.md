# ILogger.UnitTest.Verifier
Verify ILogger calls more easily.


## Moq

[![nuget](https://img.shields.io/nuget/v/TomLonghurst.ILogger.UnitTest.Verifier.Moq.svg)](https://www.nuget.org/packages/TomLonghurst.ILogger.UnitTest.Verifier.Moq/)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/f654e7d05b0d45e89a1182207024c3a3)](https://www.codacy.com/gh/thomhurst/ILogger.UnitTest.Verifier/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=thomhurst/ILogger.UnitTest.Verifier&amp;utm_campaign=Badge_Grade)
[![CodeFactor](https://www.codefactor.io/repository/github/thomhurst/ilogger.unittest.verifier/badge)](https://www.codefactor.io/repository/github/thomhurst/ilogger.unittest.verifier)

## Installation

Install via Nuget
`Install-Package TomLonghurst.ILogger.UnitTest.Verifier.Moq`

## Why?
Because verifying calls to `ILogger` is a pain in the ****!

### Usage
In your tests, create a Mock<ILogger> or Mock<ILogger<T>> and inject this into your classes under test.
Then you can call `.Verify(LoggerVerifyOptions)` or `.Verify[Information/Warning/Debug/Critical/Trace/Error](String)`

## Examples

### Log Level Extensions

#### App Code
```csharp
private readonly field ILogger _logger;

public SomeClass(ILogger logger)
{
    _logger = logger;
}

// ...

public void SomeMethod(SomeInput someInput)
{
    // ...
    // Use ILogger as normal - Any way you like.
    _logger.LogInformation("Something happened");
    // ...
}
```

#### Test Code

```csharp
private Mock<ILogger> _loggerMock;
private SomeClass _someClass;

public void Setup()
{
    _loggerMock = new Mock<ILogger>();
    _someClass = new SomeClass(_loggerMock.Object);
}

[Test]
public void VerifyLoggerCalled()
{
    _someClass.SomeMethod(input);
    
    // Use the Verify/Verify[LogLevel] extension methods on Mock<ILogger> or Mock<ILogger<T>>
    _loggerMock.VerifyInformation("Something happened");
    // or
    _loggerMock.Verify(new LoggerVerifyOptions
    {
        Message = "Something happened",
        MessageMatchMethod = MessageMatchMethod.Equals,
        LogLevel = LogLevel.Information,
    });
}
```

#### Other Examples
    
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
            LogLevel = LogLevel.Information,
            Times = Times.Once()
        });
    }
```
