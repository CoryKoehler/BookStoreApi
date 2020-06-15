using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using EventFlow.Commands;

namespace BookstoreApi.Commands
{
    public class UpsertAuthorCommand : Command<AuthorAggregate, AuthorId, UpsertAuthorExecutionResult>
    {
        public int LegacyId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }


        public UpsertAuthorCommand(int legacyId, string name, string country) : base(AuthorId.New)
        {
            LegacyId = legacyId;
            Name = name;
            Country = country;
        }
    }
}
