using System;

namespace Hqv.CSharp.Common.Logging
{
    /// <summary>
    /// Logger interface. Created a customer interface instead of using the Microsoft or other
    /// vendor specific interface so we can switch them up if needed. 
    /// </summary>
    public interface ILogger
    {
        void LogInfo(string description, string correlationId = null);

        void LogInfo(object obj, string correlationId = null);

        void LogWarning(string description, Exception exception = null, string correlationId = null);

        void LogWarning(object obj, Exception exception = null, string correlationId = null);

        void LogError(string description, Exception exception = null, string correlationId = null);

        void LogError(object obj, Exception exception = null, string correlationId = null);
    }
}
