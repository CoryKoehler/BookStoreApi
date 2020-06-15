using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace BookstoreApi.Events
{
    [EventVersion("BookUpserted", 1)]
    public class BookUpserted : AggregateEvent<BookAggregate, BookId>
    {
        public int LegacyId { get; }
        public int Price { get; }
        public int Edition { get; }
        public int LegacyAuthorId { get; }
        public int LegacyPublisherId { get; }

        public BookUpserted(int legacyId, int price, int edition, int legacyAuthorId, int legacyPublisherId)
        {
            LegacyId = legacyId;
            Price = price;
            Edition = edition;
            LegacyAuthorId = legacyAuthorId;
            LegacyPublisherId = legacyPublisherId;
        }
    }
}
