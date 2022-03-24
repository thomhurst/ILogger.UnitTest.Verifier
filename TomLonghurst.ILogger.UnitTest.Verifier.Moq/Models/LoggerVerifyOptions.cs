using Microsoft.Extensions.Logging;
using Moq;

namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

public record LoggerVerifyOptions
{
    /**
     * <summary>The log level to verify. By default will match any log level</summary>
     */
    public LogLevel? LogLevel { get; set; }

    /**
     * <summary>The event id to check was logged</summary>
     */
    public EventId? EventId { get; set; }

    public ExceptionOptions ExceptionOptions { get; } = new ExceptionOptions();
    
    public MessageOptions MessageOptions { get; } = new MessageOptions();

    /**
     * <summary>The amount of times to verify the logger was called</summary>
     */
    public Times? Times { get; set; }
}