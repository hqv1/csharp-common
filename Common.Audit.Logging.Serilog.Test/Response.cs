using Hqv.CSharp.Common.Components;

namespace Hqv.CSharp.Common.Audit.Logging.Serilog.Test
{
    public class Response : ResponseBase
    {
        public Response(RequestBase request) : base(request)
        {
        }
    }
}