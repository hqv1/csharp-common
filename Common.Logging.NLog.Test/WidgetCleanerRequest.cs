using Hqv.CSharp.Common.Components;

namespace Hqv.CSharp.Common.Log.NLog.Test
{
    public class WidgetCleanerRequest : RequestBase
    {
        public WidgetCleanerRequest(string correlationId) : base(correlationId)
        {
        }
    }
}