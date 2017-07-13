using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Hqv.CSharp.Common.Logging.NLog
{
    public class Logger : ILogger
    {
        private readonly global::NLog.ILogger _logger;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public Logger(global::NLog.ILogger logger)
        {
            _logger = logger;
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Debug(exception, CreateMessage(message));
        }

        public void Debug(Exception exception, object obj)
        {
            _logger.Debug(exception, CreateMessage(obj));
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Debug(CreateMessage(message));
        }

        public void Debug(object obj)
        {
            _logger.Debug(CreateMessage(obj));
        }

        public void Info(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Info(exception, CreateMessage(message));
        }

        public void Info(Exception exception, object obj)
        {
            _logger.Info(exception, CreateMessage(obj));
        }

        public void Info(string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Info(CreateMessage(message));
        }

        public void Info(object obj)
        {
            _logger.Info(CreateMessage(obj));
        }

        public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Warn(exception, CreateMessage(message));
        }

        public void Warning(Exception exception, object obj)
        {
            _logger.Warn(exception, CreateMessage(obj));
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Warn(CreateMessage(message));
        }

        public void Warning(object obj)
        {
            _logger.Warn(CreateMessage(obj));
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Error(exception, CreateMessage(message));
        }

        public void Error(Exception exception, object obj)
        {
            _logger.Error(exception, CreateMessage(obj));
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Error(CreateMessage(message));
        }

        public void Error(object obj)
        {
            _logger.Error(CreateMessage(obj));
        }

        public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Fatal(exception, CreateMessage(message));
        }

        public void Fatal(Exception exception, object obj)
        {
            _logger.Fatal(exception, CreateMessage(obj));
        }

        public void Fatal(string messageTemplate, params object[] propertyValues)
        {
            var message = string.Format(messageTemplate, propertyValues);
            _logger.Fatal(CreateMessage(message));
        }

        public void Fatal(object obj)
        {
            _logger.Fatal(CreateMessage(obj));
        }
        
        private string CreateMessage(object obj)
        {
            return JsonConvert.SerializeObject(new { description = obj }, _jsonSerializerSettings);
        }
    }
}
