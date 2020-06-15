using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;
using System;
using System.Collections.Generic;

namespace BookstoreApi.Aggregates
{
    public class OrderState : AggregateState<OrderAggregate, OrderId, OrderState>,
        IApply<OrderUpserted>
    {
        public int LegacyId { get; private set; }
        public int LegacyCustomerId { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal OrderTotal { get; private set; }
        public List<Entities.OrderedItem> OrderedItems { get; private set; }

        public OrderState()
        {
            OrderedItems = new List<Entities.OrderedItem>();
        }

        public void Apply(OrderUpserted aggregateEvent)
        {
            LegacyId = aggregateEvent.LegacyId;
            LegacyCustomerId = aggregateEvent.LegacyCustomerId;
            OrderDate = aggregateEvent.OrderDate;
            OrderTotal = aggregateEvent.OrderTotal;
            OrderedItems = aggregateEvent.OrderedItems;
        }
    }
}
