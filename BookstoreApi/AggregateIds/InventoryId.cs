using EventFlow.Core;

namespace BookstoreApi.AggregateIds
{
    public class InventoryId : Identity<InventoryId>
    {
        public InventoryId(string value) : base(value) { }
    }
}
