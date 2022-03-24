namespace TomLonghurst.ILogger.UnitTest.Verifier.Moq.Models;

public class MessageOptions
{
    public FormattedMessageOptions FormattedMessageOptions { get; } = new FormattedMessageOptions();
    public MessageTemplateOptions MessageTemplateOptions { get; } = new MessageTemplateOptions();
    public MessageParametersOptions MessageParametersOptions { get; } = new MessageParametersOptions();
}