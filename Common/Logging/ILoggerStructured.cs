using System;

namespace Hqv.CSharp.Common.Logging
{
    /// <summary>
    /// Interface for structured logging. See https://github.com/serilog.
    /// </summary>
    public interface ILoggerStructured
    {
        void LogDebug(string messageTemplate, params object[] propertyValues);
        void LogDebug(Exception exception, string messageTemplate, params object[] propertyValues);

        void LogInfo(string messageTemplate, params object[] propertyValues);
        void LogInfo(Exception exception, string messageTemplate, params object[] propertyValues);

        void LogWarning(string messageTemplate, params object[] propertyValues);
        void LogWarning(Exception exception, string messageTemplate, params object[] propertyValues);

        void LogError(string messageTemplate, params object[] propertyValues);
        void LogError(Exception exception, string messageTemplate, params object[] propertyValues);

        void LogFatal(string messageTemplate, params object[] propertyValues);
        void LogFatal(Exception exception, string messageTemplate, params object[] propertyValues);
    }
}