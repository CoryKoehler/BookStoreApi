using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using BookstoreApi.Commands;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.CommandHandlers
{
    public class UpsertOrderCommandHandler : CommandHandler<OrderAggregate, OrderId, UpsertOrderExecutionResult, UpsertOrderCommand>
    {
        public UpsertOrderCommandHandler()
        {

        }

        public override async Task<UpsertOrderExecutionResult> ExecuteCommandAsync(OrderAggregate aggregate,
            UpsertOrderCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            aggregate.UpsertOrder(command.LegacyId, command.LegacyCustomerId, command.OrderDate, command.OrderTotal, command.OrderedItems);

            return new UpsertOrderExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
