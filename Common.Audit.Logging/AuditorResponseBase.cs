using System;
using System.Collections.Generic;
using System.Linq;
using Hqv.CSharp.Common.Components;
using Hqv.CSharp.Common.Logging;

namespace Hqv.CSharp.Common.Audit.Logging
{
   
   
    /// <summary>
    /// Audit response base. Seems to be the direction I'm going with on auditing.
    /// Doing a hack for Serilog. Serilog is able to serialize exceptions within the response object, but NLog can't.
    /// So for NLog, I'm taking the list of exceptions, creating an aggregate exception and that's the exception going
    /// to the log. I'm added a [JsonIgnore] to Response to not serialize the exception. None of that is needed in 
    /// Serilog. So how to get AuditorResponseBase to know the difference? By using different Logger interfaces.
    /// </summary>
    public class AuditorResponseBase : IAuditor, IAuditorResponseBase
    {
        public class Settings
        {
            public Settings(bool shouldAuditOnSuccessfulEvent, bool shouldDetailAuditOnSuccessfulEvent)
            {
                ShouldAuditOnSuccessfulEvent = shouldAuditOnSuccessfulEvent;
                ShouldDetailAuditOnSuccessfulEvent = shouldDetailAuditOnSuccessfulEvent;
            }

            public bool ShouldAuditOnSuccessfulEvent { get; }
            public bool ShouldDetailAuditOnSuccessfulEvent { get; }
            public bool? ShouldCreateExceptionForAuditing { get; set; }
        }

        private readonly Settings _settings;
        private readonly IHqvLogger _logger;

        public AuditorResponseBase(Settings settings, IHqvLogger logger) 
        {
            _settings = settings;
            _logger = logger;

            if (_settings.ShouldCreateExceptionForAuditing == null)
            {
                if (logger is IHqvLoggerStructured) _settings.ShouldCreateExceptionForAuditing = false;
                else _settings.ShouldCreateExceptionForAuditing = true;
            }
        }

        public void AuditSuccess(IBusinessEvent businessEvent)
        {
            _logger.Info(businessEvent);
        }

        public void AuditFailure(IBusinessEvent businessEvent)
        {
            _logger.Error(businessEvent);
        }

        public void AuditSuccess(string entityName, string entityKey, string eventName, ResponseBase response, int version = 1)
        {
            if (!_settings.ShouldAuditOnSuccessfulEvent)
            {
                return;
            }
            var businessEvent = new BusinessEvent(                
                entityName: entityName,
                entityKey: entityKey,
                eventName: eventName,
                correlationId: response.Request?.CorrelationId,
                version: version,
                entityObject: _settings.ShouldDetailAuditOnSuccessfulEvent ? response : null);
            _logger.Info(businessEvent);
        }

        public void AuditFailure(string entityName, string entityKey, string eventName, ResponseBase response,
            int version = 1)
        {
            var businessEvent = new BusinessEvent(
                entityName: entityName,
                entityKey: entityKey,
                eventName: eventName,
                correlationId: response.Request?.CorrelationId,
                version: version,
                entityObject: response);

            if (_settings.ShouldCreateExceptionForAuditing == false)
                _logger.Error(businessEvent);
            else _logger.Error(CreateLoggingException(response.Errors), businessEvent);
        }

        private static Exception CreateLoggingException(IEnumerable<Exception> exceptions)
        {
            var exs = exceptions as Exception[] ?? exceptions.ToArray();
            if (!exs.Any())
            {
                return null;
            }
            return exs.Length == 1 ? exs.First() : new AggregateException(exs);
        }        
    }
}