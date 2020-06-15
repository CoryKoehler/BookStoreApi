using EventFlow.Core;

namespace BookstoreApi.AggregateIds
{
    public class OrderedItemId : Identity<OrderedItemId>
    {
        public OrderedItemId(string value) : base(value) { }
    }
}
