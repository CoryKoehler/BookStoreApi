using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class AuthorState : AggregateState<AuthorAggregate, AuthorId, AuthorState>,
        IApply<AuthorUpserted>
    {
        public int LegacyId { get; private set; }
        public string AuthorName { get; private set; }
        public string Country { get; private set; }

        public AuthorState()
        {

        }

        public void Apply(AuthorUpserted aggregateEvent)
        {
            LegacyId = aggregateEvent.LegacyId;
            AuthorName = aggregateEvent.Name;
            Country = aggregateEvent.Country;
        }
    }
}
