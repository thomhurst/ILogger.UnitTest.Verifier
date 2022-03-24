namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

public class MessageParametersOptions
{
    /**
     * <summary>An array of parameter names and values</summary>
     */
    public KeyValuePair<string, object>[]? Parameters { get; set; }
        
    /**
     * <summary>Used to match the value exactly, or a partial match using contains</summary>
     */
    public MessageMatchMethod MessageMatchMethod { get; set; } = MessageMatchMethod.Equals;
    
    /**
     * <summary>The string comparison method. Use for ignoring casing etc.</summary>
     */
    public StringComparison StringComparison { get; set; } = StringComparison.Ordinal;
}