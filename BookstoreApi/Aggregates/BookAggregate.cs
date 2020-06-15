using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class BookAggregate : AggregateRoot<BookAggregate, BookId>
    {
        private readonly BookState _state = new BookState();

        public BookAggregate(BookId id) : base(id)
        {
            Register(_state);
        }

        public int LegacyId => _state.LegacyId;
        public int Price => _state.Price;
        public int Edition => _state.Edition;
        public int LegacyAuthorId => _state.LegacyAuthorId;
        public AuthorId AuthorId => _state.AuthorId;
        public int LegacyPublisherId => _state.LegacyPublisherId;
        public PublisherId PublisherId => _state.PublisherId;

        public virtual void UpsertBook(int legacyId, int price, int edition, int legacyAuthorId, int legacyPublisherId)
        {
            Emit(new BookUpserted(legacyId, price, edition, legacyAuthorId, legacyPublisherId), new Metadata());
        }

    }
}
