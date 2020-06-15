using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.Entities;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using System;
using System.Collections.Generic;

namespace BookstoreApi.Events
{
    [EventVersion("OrderUpserted", 1)]
    public class OrderUpserted : AggregateEvent<OrderAggregate, OrderId>
    {
        public int LegacyId { get; }
        public int LegacyCustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public List<OrderedItem> OrderedItems { get; set; }


        public OrderUpserted(int legacyId, int legacyCustomerId, DateTime orderDate, decimal orderTotal, List<OrderedItem> orderedItems)
        {
            LegacyId = legacyId;
            LegacyCustomerId = legacyCustomerId;
            OrderDate = orderDate;
            OrderTotal = orderTotal;
            OrderedItems = orderedItems;
        }
    }
}
