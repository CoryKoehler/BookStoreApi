using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class CustomerAggregate : AggregateRoot<CustomerAggregate, CustomerId>
    {
        private readonly CustomerState _state = new CustomerState();

        public CustomerAggregate(CustomerId id) : base(id)
        {
            Register(_state);
        }

        public int LegacyId => _state.LegacyId;
        public string CustomerName => _state.CustomerName;
        public string Address => _state.Address;
        public string PostalCode => _state.PostalCode;
        public string State => _state.State;
        public string Country => _state.Country;
        public string PhoneNumber => _state.PhoneNumber;

        public virtual void UpsertCustomer(int legacyId, string customerName, string address, string postalCode, string state, string country, string phoneNumber)
        {
            Emit(new CustomerUpserted(legacyId, customerName, address, postalCode, state, country, phoneNumber), new Metadata());
        }

    }
}
