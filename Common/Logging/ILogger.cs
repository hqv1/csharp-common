using System;

namespace Hqv.CSharp.Common.Logging
{
    /// <summary>
    /// Logger interface. Created a customer interface instead of using the Microsoft or other
    /// vendor specific interface so we can switch them up if needed. 
    /// </summary>
    public interface ILogger
    {
        void Debug(Exception exception, string messageTemplate, params object[] propertyValues);
        void Debug(Exception exception, object obj);
        void Debug(string messageTemplate, params object[] propertyValues);
        void Debug(object obj);

        void Info(Exception exception, string messageTemplate, params object[] propertyValues);
        void Info(Exception exception, object obj);
        void Info(string messageTemplate, params object[] propertyValues);
        void Info(object obj);


        void Warning(Exception exception, string messageTemplate, params object[] propertyValues);
        void Warning(Exception exception, object obj);
        void Warning(string messageTemplate, params object[] propertyValues);
        void Warning(object obj);


        void Error(Exception exception, string messageTemplate, params object[] propertyValues);
        void Error(Exception exception, object obj);
        void Error(string messageTemplate, params object[] propertyValues);
        void Error(object obj);

        void Fatal(Exception exception, string messageTemplate, params object[] propertyValues);
        void Fatal(Exception exception, object obj);
        void Fatal(string messageTemplate, params object[] propertyValues);
        void Fatal(object obj);        
    }
}
