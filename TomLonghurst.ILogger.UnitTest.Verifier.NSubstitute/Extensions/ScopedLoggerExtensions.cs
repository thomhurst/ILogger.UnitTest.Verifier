using NSubstitute;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;

public static class ScopedLoggerExtensions
{
    public static Microsoft.Extensions.Logging.ILogger WithMockedScoping(this Microsoft.Extensions.Logging.ILogger logger)
    {
        var scopedHolder = new ScopedHolder();
        ScopeLoggerHelper.ConditionalWeakTable.Add(logger, scopedHolder);
        logger.When(x => x.BeginScope(Arg.Any<object>()))
            .Do(state => scopedHolder.AddState(state.Args().First()));
        
        return logger;
    }
}