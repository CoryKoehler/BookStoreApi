using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace BookstoreApi.Events
{
    [EventVersion("AuthorUpserted", 1)]
    public class AuthorUpserted : AggregateEvent<AuthorAggregate, AuthorId>
    {
        public int LegacyId { get; }
        public string Name { get; }
        public string Country { get; }
   

        public AuthorUpserted(int legacyId, string name, string country)
        {
            LegacyId = legacyId;
            Name = name;
            Country = country;

        }
    }
}
