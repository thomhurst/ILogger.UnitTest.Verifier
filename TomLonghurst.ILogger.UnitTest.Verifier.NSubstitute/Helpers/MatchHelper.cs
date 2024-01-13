using Microsoft.Extensions.Logging;
using NSubstitute;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Extensions;
using TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Models;

namespace TomLonghurst.ILogger.UnitTest.Verifier.NSubstitute.Helpers;

internal static class MatchHelper
{
    public static bool MatchLogLevel(LogLevel? logLevel, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.LogLevel == null)
        {
            return true;
        }

        return logLevel == loggerVerifyOptions.LogLevel;
    }

    public static bool MatchText(IReadOnlyList<KeyValuePair<string, object>>? message, LoggerVerifyOptions loggerVerifyOptions, Microsoft.Extensions.Logging.ILogger logger)
    {
        var values = message ?? new List<KeyValuePair<string, object>>();
        return MatchMessage(message?.ToString(), loggerVerifyOptions) 
               && MatchMessageTemplate(values.FirstOrDefault(x => x.Key == "{OriginalFormat}").Value?.ToString(), loggerVerifyOptions)
               && MatchParameters(values, loggerVerifyOptions, logger);
    }

    private static bool MatchParameters(IReadOnlyList<KeyValuePair<string, object>> values,
        LoggerVerifyOptions loggerVerifyOptions, Microsoft.Extensions.Logging.ILogger logger)
    {
        foreach (var parameter in loggerVerifyOptions.MessageOptions.MessageParametersOptions.Parameters ?? Array.Empty<KeyValuePair<string, object>>())
        {
            var loggedValue = FindParameter(values, parameter, logger);
            
            if (!loggedValue.Any() || !loggedValue.First().Value.Equals(parameter.Value))
            {
                return false;
            }
        }
        return true;
    }

    private static List<KeyValuePair<string, object>> FindParameter(IReadOnlyList<KeyValuePair<string, object>>? values,
        KeyValuePair<string, object> parameter, Microsoft.Extensions.Logging.ILogger logger)
    {
        var keyValuePairs = (values?.Where(x => x.Key == parameter.Key) ?? Array.Empty<KeyValuePair<string, object>>()).ToList();
        
            if (ScopeLoggerHelper.ConditionalWeakTable.TryGetValue(logger, out var scopedHolder))
            {
                var list = scopedHolder.GetStates();
                foreach (var state in list)
                {
                    if (state is IEnumerable<KeyValuePair<string, object>> dict)
                    {
                        keyValuePairs.AddRange(dict.Where(x => x.Key == parameter.Key));
                    }
                }
            }

            return keyValuePairs.ToList();
    }

    private static bool MatchMessageTemplate(string? messageTemplate, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.MessageOptions.MessageTemplateOptions.MessageTemplate == null)
        {
            return true;
        }

        return string.Equals(messageTemplate, loggerVerifyOptions.MessageOptions.MessageTemplateOptions.MessageTemplate);
    }

    private static bool MatchMessage(string? message, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.MessageOptions.FormattedMessageOptions.Message == null)
        {
            return true;
        }

        if (loggerVerifyOptions.MessageOptions.FormattedMessageOptions.MessageMatchMethod == MessageMatchMethod.Equals)
        {
            return string.Equals(message, loggerVerifyOptions.MessageOptions.FormattedMessageOptions.Message, loggerVerifyOptions.MessageOptions.FormattedMessageOptions.StringComparison);
        }

        return message.Contains(loggerVerifyOptions.MessageOptions.FormattedMessageOptions.Message, loggerVerifyOptions.MessageOptions.FormattedMessageOptions.StringComparison);
    }

    public static bool MatchException(Exception e, LoggerVerifyOptions loggerVerifyOptions)
    {
        return MatchExceptionType(e, loggerVerifyOptions) && MatchExceptionMessage(e, loggerVerifyOptions);
    }

    private static bool MatchExceptionMessage(Exception exception, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.ExceptionOptions.Message == null)
        {
            return true;
        }
        
        if (loggerVerifyOptions.ExceptionOptions.MessageMatchMethod == MessageMatchMethod.Equals)
        {
            return string.Equals(exception.Message, loggerVerifyOptions.ExceptionOptions.Message, loggerVerifyOptions.ExceptionOptions.StringComparison);
        }

        return exception.Message.Contains(loggerVerifyOptions.ExceptionOptions.Message, loggerVerifyOptions.ExceptionOptions.StringComparison);
    }

    private static bool MatchExceptionType(Exception e, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.ExceptionOptions.ExceptionType == null)
        {
            return true;
        }

        return e.GetType() == loggerVerifyOptions.ExceptionOptions.ExceptionType;
    }

    public static bool MatchEventId(EventId? eventId, LoggerVerifyOptions loggerVerifyOptions)
    {
        if (loggerVerifyOptions.EventId == null)
        {
            return true;
        }

        return eventId == loggerVerifyOptions.EventId;
    }
}