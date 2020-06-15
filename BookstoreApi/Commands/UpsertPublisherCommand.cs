using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using EventFlow.Commands;

namespace BookstoreApi.Commands
{
    public class UpsertPublisherCommand : Command<PublisherAggregate, PublisherId, UpsertPublisherExecutionResult>
    {
        public int LegacyId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }


        public UpsertPublisherCommand(int legacyId, string name, string country) : base(PublisherId.New)
        {
            LegacyId = legacyId;
            Name = name;
            Country = country;
        }
    }
}
