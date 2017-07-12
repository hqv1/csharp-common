using System;
using Hqv.CSharp.Common.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Hqv.CSharp.Common.Log.NLog
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
        

        public void LogInfo(string description, string correlationId = null)
        {            
            _logger.Info(CreateMessage(description, correlationId));
        }

        public void LogInfo(object obj, string correlationId = null)
        {            
            _logger.Info(CreateMessage(obj, correlationId));
        }

        public void LogWarning(string description, Exception exception = null, string correlationId = null)
        {         
            _logger.Warn(exception, CreateMessage(description, correlationId));
        }

        public void LogWarning(object obj, Exception exception = null, string correlationId = null)
        {            
            _logger.Warn(exception, CreateMessage(obj, correlationId));
        }

        public void LogError(string description, Exception exception = null, string correlationId = null)
        {            
            _logger.Error(exception, CreateMessage(description, correlationId));
        }

        public void LogError(object obj, Exception exception = null, string correlationId = null)
        {            
            _logger.Error(exception, CreateMessage(obj, correlationId));
        }

        private string CreateMessage(object obj, string correlationId)
        {
            return string.IsNullOrEmpty(correlationId)
                ? JsonConvert.SerializeObject(new {description = obj}, _jsonSerializerSettings)
                : JsonConvert.SerializeObject(new {description = obj, correlationId}, _jsonSerializerSettings);
        }
    }
}
