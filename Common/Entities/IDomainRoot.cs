using System;
using System.Collections.Generic;
using Hqv.CSharp.Common.Audit;

namespace Hqv.CSharp.Common.Entities
{
    /// <summary>
    /// Interface for domain root
    /// </summary>
    public interface IDomainRoot
    {
        string Key { get; }

        string CorrelationId { get; }

        bool IsValid { get; }

        IEnumerable<Exception> Exceptions { get; }
        IEnumerable<Message> Warnings { get; }
        IEnumerable<IBusinessEvent> BusinessEvents { get; }
    }
}