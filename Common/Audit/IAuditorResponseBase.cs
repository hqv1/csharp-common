using Hqv.CSharp.Common.Components;

namespace Hqv.CSharp.Common.Audit
{
    public interface IAuditorResponseBase
    {
        void AuditSuccess(string entityName, string entityKey, string eventName, ResponseBase response,
            int version = 1);

        void AuditFailure(string entityName, string entityKey, string eventName, ResponseBase response,
            int version = 1);
    }
}