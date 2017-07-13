using System;

namespace Hqv.CSharp.Common.Logging
{
    /// <summary>
    /// Interface for structured logging. See https://github.com/serilog.
    /// </summary>
    public interface ILoggerStructured
    {
        void Debug(string messageTemplate, params object[] propertyValues);
        void Debug(Exception exception, string messageTemplate, params object[] propertyValues);

        void Info(string messageTemplate, params object[] propertyValues);
        void Info(Exception exception, string messageTemplate, params object[] propertyValues);

        void Warning(string messageTemplate, params object[] propertyValues);
        void Warning(Exception exception, string messageTemplate, params object[] propertyValues);

        void Error(string messageTemplate, params object[] propertyValues);
        void Error(Exception exception, string messageTemplate, params object[] propertyValues);

        void Fatal(string messageTemplate, params object[] propertyValues);
        void Fatal(Exception exception, string messageTemplate, params object[] propertyValues);
    }
}