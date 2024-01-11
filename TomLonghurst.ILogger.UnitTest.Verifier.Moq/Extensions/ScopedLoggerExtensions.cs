using System.Runtime.CompilerServices;
using Moq;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;

public static class ScopedLoggerExtensions
{
    public static Mock<Microsoft.Extensions.Logging.ILogger> WithMockedScoping(this Mock<Microsoft.Extensions.Logging.ILogger> logger)
    {
        var scopedHolder = new ScopedHolder();
        ScopeLoggerHelper.ConditionalWeakTable.Add(logger, scopedHolder);
        logger.Setup(x => x.BeginScope(It.IsAny<object>()))
            .Callback<object>(state => scopedHolder.AddState(state));
        
        return logger;
    }
}