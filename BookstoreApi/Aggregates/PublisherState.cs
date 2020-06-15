using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class PublisherState : AggregateState<PublisherAggregate, PublisherId, PublisherState>,
        IApply<PublisherUpserted>
    {
        public int LegacyId { get; private set; }
        public string PublisherName { get; private set; }
        public string Country { get; private set; }

        public PublisherState()
        {

        }

        public void Apply(PublisherUpserted aggregateEvent)
        {
            LegacyId = aggregateEvent.LegacyId;
            PublisherName = aggregateEvent.Name;
            Country = aggregateEvent.Country;
        }
    }
}
