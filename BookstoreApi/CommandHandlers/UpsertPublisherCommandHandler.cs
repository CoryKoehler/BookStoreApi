using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using BookstoreApi.Commands;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.CommandHandlers
{
    public class UpsertPublisherCommandHandler : CommandHandler<PublisherAggregate, PublisherId, UpsertPublisherExecutionResult, UpsertPublisherCommand>
    {
        public UpsertPublisherCommandHandler()
        {

        }

        public override async Task<UpsertPublisherExecutionResult> ExecuteCommandAsync(PublisherAggregate aggregate,
            UpsertPublisherCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            aggregate.UpsertPublisher(command.LegacyId, command.Name, command.Country);

            return new UpsertPublisherExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
