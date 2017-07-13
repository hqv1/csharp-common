namespace Hqv.CSharp.Common.Components
{
    public abstract class RequestBase
    {
        protected RequestBase(string correlationId)
        {
            CorrelationId = correlationId;
        }
        public string CorrelationId { get; }
    }
}