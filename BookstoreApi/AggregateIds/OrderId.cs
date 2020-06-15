using EventFlow.Core;

namespace BookstoreApi.AggregateIds
{
    public class OrderId : Identity<OrderId>
    {
        public OrderId(string value) : base(value) { }
    }
}
