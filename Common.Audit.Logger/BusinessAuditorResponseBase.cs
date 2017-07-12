﻿using System;
using System.Collections.Generic;
using System.Linq;
using Hqv.CSharp.Common.Components;
using Hqv.CSharp.Common.Logging;

namespace Hqv.CSharp.Common.Audit.Logger
{
    /// <summary>
    /// Audit response base. Seems to be the direction I'm going with on auditing.
    /// </summary>
    public class BusinessAuditorResponseBase : IAuditorResponseBase
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
        private readonly ILogger _logger;

        public BusinessAuditorResponseBase(Settings settings, ILogger logger) 
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
                version: version,
                entityObject: _settings.ShouldDetailAuditOnSuccessfulEvent ? response : null);
            _logger.LogInfo(businessEvent);
        }

        public void AuditFailure(string entityName, string entityKey, string eventName, ResponseBase response, int version = 1)
        {
            var businessEvent = new BusinessEvent(
                entityName: entityName,
                entityKey: entityKey,
                eventName: eventName,
                version: version,
                entityObject: response);
            _logger.LogError(businessEvent, CreateLoggingException(response.Errors));
        }

        private static Exception CreateLoggingException(IEnumerable<Exception> exceptions)
        {
            var exs = exceptions as Exception[] ?? exceptions.ToArray();
            if (!exs.Any())
            {
                return null;
            }
            return exs.Count() == 1 ? exs.First() : new AggregateException(exs);
        }        
    }
}