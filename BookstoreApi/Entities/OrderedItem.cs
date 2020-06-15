using BookstoreApi.AggregateIds;
using EventFlow.Entities;

namespace BookstoreApi.Entities
{
    public class OrderedItem : Entity<OrderedItemId>
    {
        public int LegacyBookId { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public OrderedItem(OrderedItemId id, int legacyBookId, int quantity, decimal price) : base(id)
        {
            LegacyBookId = legacyBookId;
            Quantity = quantity;
            Price = price;
        }
    }
}
