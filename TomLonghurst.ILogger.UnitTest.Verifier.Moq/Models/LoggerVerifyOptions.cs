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
     * <summary>The message to check was logged</summary>
     */
    public string? Message { get; set; }
    
    /**
     * <summary>The event id to check was logged</summary>
     */
    public EventId? EventId { get; set; }

    /**
     * <summary>Used to match the text exactly, or a partial match using contains</summary>
     */
    public MessageMatchMethod MessageMatchMethod { get; set; } = MessageMatchMethod.Equals;
    
    /**
     * <summary>The string comparison method. Use for ignoring casing etc.</summary>
     */
    public StringComparison StringComparison { get; set; } = StringComparison.Ordinal;
    
    /**
     * <summary>The exception type to check was logged</summary>
     */
    public Type? ExceptionType { get; set; }
    
    /**
     * <summary>The amount of times to verify the logger was called</summary>
     */
    public Times? Times { get; set; }
}

public enum MessageMatchMethod
{
    Equals,
    Contains
}