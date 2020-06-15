using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace BookstoreApi.Events
{
    [EventVersion("CustomerUpserted", 1)]
    public class CustomerUpserted : AggregateEvent<CustomerAggregate, CustomerId>
    {
        public int LegacyId { get; }
        public string Name { get; }
        public string Address { get; }
        public string PostalCode { get; }
        public string State { get; }
        public string Country { get; }
        public string PhoneNumber { get; }


        public CustomerUpserted(int legacyId, string name, string address, string postalCode, string state, string country, string phoneNumber)
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
