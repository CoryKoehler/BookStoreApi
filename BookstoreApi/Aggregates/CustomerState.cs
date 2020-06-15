using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class CustomerState : AggregateState<CustomerAggregate, CustomerId, CustomerState>,
        IApply<CustomerUpserted>
    {
        public int LegacyId { get; private set; }
        public string CustomerName { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string PhoneNumber { get; private set; }

        public CustomerState()
        {

        }

        public void Apply(CustomerUpserted aggregateEvent)
        {
            LegacyId = aggregateEvent.LegacyId;
            CustomerName = aggregateEvent.Name;
            Address = aggregateEvent.Address;
            PostalCode = aggregateEvent.PostalCode;
            State = aggregateEvent.State;
            Country = aggregateEvent.Country;
            PhoneNumber = aggregateEvent.PhoneNumber;
        }
    }
}
