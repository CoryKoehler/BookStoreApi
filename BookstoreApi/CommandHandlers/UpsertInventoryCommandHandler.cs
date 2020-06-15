using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using BookstoreApi.Commands;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.CommandHandlers
{
    public class UpsertInventoryCommandHandler : CommandHandler<InventoryAggregate, InventoryId, UpsertInventoryExecutionResult, UpsertInventoryCommand>
    {
        public UpsertInventoryCommandHandler()
        {

        }

        public override async Task<UpsertInventoryExecutionResult> ExecuteCommandAsync(InventoryAggregate aggregate,
            UpsertInventoryCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            aggregate.UpsertInventory(command.LegacyId, command.LegacyBookId, command.StockLevelUsed, command.StockLevelNew);

            return new UpsertInventoryExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
