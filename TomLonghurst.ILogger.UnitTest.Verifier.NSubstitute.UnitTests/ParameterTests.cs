using Microsoft.Extensions.Logging;
using NSubstitute;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.UnitTests;

public class ParameterTests
{
    private TestLogger _logger = null!;
    private Microsoft.Extensions.Logging.ILogger _loggerMock = null!;

    [SetUp]
    public void Setup()
    {
        _loggerMock = Substitute.For<Microsoft.Extensions.Logging.ILogger>();
        _logger = new TestLogger(_loggerMock);
    }

    [TestCase(1)]
    [TestCase("val")]
    [TestCase(true)]
    public void Verify_Logger_Parameter_By_Reference(object value)
    {
        _logger.LogInformation("Some message {Value}", value);

            _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                MessageParametersOptions =
                {
                    Parameters = new []
                    {
                        new KeyValuePair<string, object>("Value", value),
                    }
                }
            }
        });
    }

    [TestCase(1, 1)]
    [TestCase("val", "val")]
    [TestCase(true, true)]
    public void Verify_Logger_Parameter_By_Value(object loggedValue, object expectedValue)
    {
        _logger.LogInformation("Some message {Value}", loggedValue);
        
        Assert.That(loggedValue, Is.Not.SameAs(expectedValue));

        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                MessageParametersOptions =
                {
                    Parameters = new []
                    {
                        new KeyValuePair<string, object>("Value", expectedValue),
                    }
                }
            }
        });
    }
}