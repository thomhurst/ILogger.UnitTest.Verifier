using System;
using Microsoft.Extensions.Logging;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Tests;

public class TestLogger : Microsoft.Extensions.Logging.ILogger
{
    private readonly Microsoft.Extensions.Logging.ILogger _logger;

    public TestLogger(Microsoft.Extensions.Logging.ILogger logger)
    {
        _logger = logger;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        _logger.Log(logLevel, eventId, state, exception, formatter);
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return _logger.IsEnabled(logLevel);
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        _logger.BeginScope(state);
        return new NoopDisposable();
    }
    
    private class NoopDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}