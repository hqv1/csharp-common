using System;

namespace Hqv.CSharp.Common.Logging.Serilog
{
    public class Logger : IHqvLoggerStructured
    {
        private readonly global::Serilog.ILogger _logger;

        public Logger(global::Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(Exception exception, object obj)
        {
            _logger.Debug(exception, "{@Obj}", obj);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            _logger.Debug(messageTemplate, propertyValues);
        }

        public void Debug(object obj)
        {
            _logger.Debug("{@Obj}", obj);
        }

        public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Debug(exception, messageTemplate, propertyValues);
        }

        public void Info(Exception exception, object obj)
        {
            _logger.Information(exception, "{@Obj}", obj);
        }

        public void Info(string messageTemplate, params object[] propertyValues)
        {
            _logger.Information(messageTemplate, propertyValues);
        }

        public void Info(object obj)
        {
            _logger.Information("{@Obj}", obj);
        }

        public void Info(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Information(exception, messageTemplate, propertyValues);
        }

        public void Warning(Exception exception, object obj)
        {
            _logger.Warning(exception, "{@Obj}", obj);
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            _logger.Warning(messageTemplate, propertyValues);
        }

        public void Warning(object obj)
        {
            _logger.Warning("{@Obj}", obj);
        }

        public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Warning(exception, messageTemplate, propertyValues);
        }

        public void Error(Exception exception, object obj)
        {
            _logger.Error(exception, "{@Obj}", obj);
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            _logger.Error(messageTemplate, propertyValues);
        }

        public void Error(object obj)
        {
            _logger.Error("{@Obj}", obj);
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Error(exception, messageTemplate, propertyValues);
        }

        public void Fatal(Exception exception, object obj)
        {
            _logger.Fatal(exception, "{@Obj}", obj);
        }

        public void Fatal(string messageTemplate, params object[] propertyValues)
        {
            _logger.Fatal(messageTemplate, propertyValues);
        }

        public void Fatal(object obj)
        {
            _logger.Fatal("{@Obj}", obj);
        }

        public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            _logger.Fatal(exception, messageTemplate, propertyValues);
        }
    }
}
