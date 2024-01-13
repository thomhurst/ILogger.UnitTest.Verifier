using System.Runtime.CompilerServices;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;

internal static class ScopeLoggerHelper
{
    public static readonly ConditionalWeakTable<Microsoft.Extensions.Logging.ILogger, ScopedHolder> ConditionalWeakTable = new();
}