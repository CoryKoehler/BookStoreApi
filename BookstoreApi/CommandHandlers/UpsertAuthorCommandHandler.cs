using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using BookstoreApi.Commands;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.CommandHandlers
{
    public class UpsertAuthorCommandHandler : CommandHandler<AuthorAggregate, AuthorId, UpsertAuthorExecutionResult, UpsertAuthorCommand>
    {
        public UpsertAuthorCommandHandler()
        {

        }

        public override async Task<UpsertAuthorExecutionResult> ExecuteCommandAsync(AuthorAggregate aggregate,
            UpsertAuthorCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            aggregate.UpsertAuthor(command.LegacyId, command.Name, command.Country);

            return new UpsertAuthorExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
