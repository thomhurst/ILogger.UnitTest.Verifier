using System.Runtime.CompilerServices;
using Moq;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Extensions;

internal static class ScopeLoggerHelper
{
    public static readonly ConditionalWeakTable<Mock, ScopedHolder> ConditionalWeakTable = new();
}