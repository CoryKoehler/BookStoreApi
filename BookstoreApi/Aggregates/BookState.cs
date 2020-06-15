using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class BookState : AggregateState<BookAggregate, BookId, BookState>,
        IApply<BookUpserted>
    {
        public int LegacyId { get; private set; }
        public int Price { get; private set; }
        public int Edition { get; private set; }
        public int LegacyAuthorId { get; private set; }
        public AuthorId AuthorId { get; private set; }
        public int LegacyPublisherId { get; private set; }
        public PublisherId PublisherId { get; private set; }

        public BookState()
        {

        }

        public void Apply(BookUpserted aggregateEvent)
        {
            LegacyId = aggregateEvent.LegacyId;
            Price = aggregateEvent.Price;
            Edition = aggregateEvent.Edition;
            LegacyAuthorId = aggregateEvent.LegacyAuthorId;
            LegacyPublisherId = aggregateEvent.LegacyPublisherId;
        }
    }
}
