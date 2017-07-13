using Hqv.CSharp.Common.Components;

namespace Hqv.CSharp.Common.Audit.Logging.Serilog.Test
{
    public class Request: RequestBase
    {
        public Request(string correlationId) : base(correlationId)
        {
        }
    }
}