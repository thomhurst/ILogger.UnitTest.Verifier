using Microsoft.Extensions.Logging;
using NSubstitute;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.UnitTests;

public class ScopedParameterTests
{
    private TestLogger _logger = null!;
    private Microsoft.Extensions.Logging.ILogger _loggerMock = null!;

    [SetUp]
    public void Setup()
    {
        _loggerMock = Substitute.For<Microsoft.Extensions.Logging.ILogger>().WithMockedScoping();
        _logger = new TestLogger(_loggerMock);
    }

    [TestCase(1)]
    [TestCase("val")]
    [TestCase(true)]
    public void Verify_Logger_Parameter(object value)
    {
        using (_logger.BeginScope(new KeyValuePair<string, object>[]
               {
                   new("param1", "value1"),
                   new("param2", "value2")
               }))
        {
            _logger.LogInformation("Some message {Value}", value);
        }

        _loggerMock.Verify(new LoggerVerifyOptions
        {
            MessageOptions =
            {
                MessageParametersOptions =
                {
                    Parameters = new []
                    {
                        new KeyValuePair<string, object>("Value", value),
                        new KeyValuePair<string, object>("param1", "value1"),
                        new KeyValuePair<string, object>("param2", "value2"),
                    }
                }
            }
        });
    }
}