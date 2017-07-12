using System;
using Hqv.CSharp.Common.Audit;

namespace Hqv.CSharp.Common.Log.NLog.Test
{
    public class WidgetCleanerBusinessEvent : IBusinessEvent
    {
        public WidgetCleanerBusinessEvent(string entityKey, object entityObject, object additionalMetadata)
        {            
            EntityName = "Widget";
            EntityKey = entityKey;
            EventName = "Cleaned";
            Version = 1;
            EventDateTime = DateTime.Now;
            EntityObject = entityObject;
            AdditionalMetadata = additionalMetadata;
        }

        public string CorrelationId { get; set; }
        public string EntityName { get; }
        public string EntityKey { get; }
        public string EventName { get; }
        public int Version { get; }
        public DateTime EventDateTime { get; }
        public object EntityObject { get; set; }
        public object AdditionalMetadata { get; set; }
    }
}