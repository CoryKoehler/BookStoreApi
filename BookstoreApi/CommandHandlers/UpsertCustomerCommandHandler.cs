using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using BookstoreApi.Commands;
using EventFlow.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace BookstoreApi.CommandHandlers
{
    public class UpsertCustomerCommandHandler : CommandHandler<CustomerAggregate, CustomerId, UpsertCustomerExecutionResult, UpsertCustomerCommand>
    {
        public UpsertCustomerCommandHandler()
        {

        }

        public override async Task<UpsertCustomerExecutionResult> ExecuteCommandAsync(CustomerAggregate aggregate,
            UpsertCustomerCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            
            aggregate.UpsertCustomer(command.LegacyId, command.Name, command.Address, command.PostalCode, command.State, command.Country, command.PhoneNumber);

            return new UpsertCustomerExecutionResult(aggregate.Id.GetGuid().ToString(), true);
        }
    }
}
