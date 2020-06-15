using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using EventFlow.Commands;

namespace BookstoreApi.Commands
{
    public class UpsertCustomerCommand : Command<CustomerAggregate, CustomerId, UpsertCustomerExecutionResult>
    {
        public int LegacyId { get; set; }
        public string Name { get; }
        public string Address { get; }
        public string PostalCode { get; }
        public string State { get; }
        public string Country { get; }
        public string PhoneNumber { get; }


        public UpsertCustomerCommand(int legacyId, string name, string address, string postalCode, string state, string country, string phoneNumber) : base(CustomerId.New)
        {
            LegacyId = legacyId;
            Name = name;
            Address = address;
            PostalCode = postalCode;
            State = state;
            Country = country;
            PhoneNumber = phoneNumber;
        }
    }
}