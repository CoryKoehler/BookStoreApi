using EventFlow.Core;

namespace BookstoreApi.AggregateIds
{
    public class BookId : Identity<BookId>
    {
        public BookId(string value) : base(value) { }
    }
}
