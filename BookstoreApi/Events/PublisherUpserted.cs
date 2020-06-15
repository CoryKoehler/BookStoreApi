using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace BookstoreApi.Events
{
    [EventVersion("PublisherUpserted", 1)]
    public class PublisherUpserted : AggregateEvent<PublisherAggregate, PublisherId>
    {
        public int LegacyId { get; }
        public string Name { get; }
        public string Country { get; }
   

        public PublisherUpserted(int legacyId, string name, string country)
        {
            LegacyId = legacyId;
            Name = name;
            Country = country;

        }
    }
}
