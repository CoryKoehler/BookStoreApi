using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using BookstoreApi.Commands;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.CommandHandlers
{
    public class UpsertBookCommandHandler : CommandHandler<BookAggregate, BookId, UpsertBookExecutionResult, UpsertBookCommand>
    {
        public UpsertBookCommandHandler()
        {

        }

        public override async Task<UpsertBookExecutionResult> ExecuteCommandAsync(BookAggregate aggregate,
            UpsertBookCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            aggregate.UpsertBook(command.LegacyId, command.Price, command.Edition, command.LegacyAuthorId, command.LegacyPublisherId);

            return new UpsertBookExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
