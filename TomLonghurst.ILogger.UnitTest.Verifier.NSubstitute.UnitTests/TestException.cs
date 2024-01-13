namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.UnitTests;

public class TestException : Exception
{
    public TestException(string message) : base(message)
    {
    }
    
    public TestException() : base("Something went wrong!")
    {
    }
}