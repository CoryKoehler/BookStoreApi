using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;
using System;
using System.Collections.Generic;

namespace BookstoreApi.Aggregates
{
    public class OrderAggregate : AggregateRoot<OrderAggregate, OrderId>
    {
        private readonly OrderState _state = new OrderState();

        public OrderAggregate(OrderId id) : base(id)
        {
            Register(_state);
        }

        public int LegacyId => _state.LegacyId;
        public int LegacyCustomerId => _state.LegacyCustomerId;
        public DateTime OrderDate => _state.OrderDate;
        public decimal OrderTotal => _state.OrderTotal;
        public List<Entities.OrderedItem> OrderedItems => _state.OrderedItems;

        public virtual void UpsertOrder(int legacyId, int legacyCustomerId, DateTime orderDate, decimal orderTotal, List<Entities.OrderedItem> orderedItems)
        {
            Emit(new OrderUpserted(legacyId, legacyCustomerId, orderDate, orderTotal, orderedItems), new Metadata());
        }

    }
}
