using EventFlow.Core;

namespace BookstoreApi.AggregateIds
{
    public class CustomerId : Identity<CustomerId>
    {
        public CustomerId(string value) : base(value) { }
    }
}
