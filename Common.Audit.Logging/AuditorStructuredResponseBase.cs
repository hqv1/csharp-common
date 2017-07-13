using Hqv.CSharp.Common.Components;
using Hqv.CSharp.Common.Logging;

namespace Hqv.CSharp.Common.Audit.Logging
{
    /// <summary>
    /// Auditor for response base using ILoggerStructured
    /// </summary>
    public class AuditorStructuredResponseBase : IAuditorResponseBase
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
        }

        private readonly Settings _settings;
        private readonly ILoggerStructured _logger;

        public AuditorStructuredResponseBase(Settings settings, ILoggerStructured logger)
        {
            _settings = settings;
            _logger = logger;
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
            _logger.Info("Business event succeeded for {@BusinessEvent}", businessEvent);
        }

        public void AuditFailure(string entityName, string entityKey, string eventName, ResponseBase response, int version = 1)
        {
            var businessEvent = new BusinessEvent(
                entityName: entityName,
                entityKey: entityKey,
                eventName: eventName,
                correlationId: response.Request?.CorrelationId,
                version: version,
                entityObject: response);
            _logger.Error("Business event failed for {@BusinessEvent}", businessEvent);
        }
        
    }
}