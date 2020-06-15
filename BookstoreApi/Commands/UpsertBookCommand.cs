using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using EventFlow.Commands;

namespace BookstoreApi.Commands
{
    public class UpsertBookCommand : Command<BookAggregate, BookId, UpsertBookExecutionResult>
    {
        public int LegacyId { get; set; }
        public int Price { get; set; }
        public int Edition { get; set; }
        public int LegacyAuthorId { get; set; }
        public int LegacyPublisherId { get; set; }

        public UpsertBookCommand(int legacyId, int price, int edition, int legacyAuthorId, int legacyPublisherId) : base(BookId.New)
        {
            LegacyId = legacyId;
            Price = price;
            Edition = edition;
            LegacyAuthorId = legacyAuthorId;
            LegacyPublisherId = legacyPublisherId;
        }
    }
}
