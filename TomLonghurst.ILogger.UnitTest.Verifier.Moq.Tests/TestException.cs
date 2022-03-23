using System;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Tests;

public class TestException : Exception
{
    public TestException() : base("Something went wrong!")
    {
    }
}