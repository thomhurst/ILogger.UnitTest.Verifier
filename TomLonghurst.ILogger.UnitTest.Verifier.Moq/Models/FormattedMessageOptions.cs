namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

public class FormattedMessageOptions
{
    /**
     * <summary>The message to check was logged</summary>
     */
    public string? Message { get; set; }
    
    /**
     * <summary>Used to match the text exactly, or a partial match using contains</summary>
     */
    public MessageMatchMethod MessageMatchMethod { get; set; } = MessageMatchMethod.Equals;
    
    /**
     * <summary>The string comparison method. Use for ignoring casing etc.</summary>
     */
    public StringComparison StringComparison { get; set; } = StringComparison.Ordinal;
}