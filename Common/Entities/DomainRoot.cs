using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hqv.CSharp.Common.Audit;

namespace Hqv.CSharp.Common.Entities
{
    /// <summary>
    /// Abstract base class for any domain root entity
    /// </summary>
    public abstract class DomainRoot<TModel> : IDomainRoot
        where TModel : class
    {        

        private readonly ConcurrentBag<Exception> _exceptions = new ConcurrentBag<Exception>();
        private readonly ConcurrentBag<Message> _warnings = new ConcurrentBag<Message>();
        private readonly ConcurrentBag<IBusinessEvent> _businessEvents = new ConcurrentBag<IBusinessEvent>();

        public TModel Model { get; set; }

        public abstract string Key { get; }

        public string CorrelationId { get; set; }

        public bool IsValid => !_exceptions.Any<Exception>();
        public IEnumerable<Exception> Exceptions => _exceptions;
        public IEnumerable<Message> Warnings => _warnings;
        public IEnumerable<IBusinessEvent> BusinessEvents => _businessEvents;

        public virtual void AddError(Exception ex)
        {
            _exceptions.Add(ex);
        }

        public virtual void AddErrors(IEnumerable<Exception> exs)
        {
            foreach (var ex in exs)
            {
                AddError(ex);
            }
        }

        public virtual void AddWarning(Message ex)
        {
            _warnings.Add(ex);
        }

        public virtual void AddWarnings(IEnumerable<Message> exs)
        {
            foreach (var ex in exs)
            {
                AddWarning(ex);
            }
        }

        public virtual void AddBusinessEvent(IBusinessEvent businessEvent)
        {
            _businessEvents.Add(businessEvent);
        }
    }
}
