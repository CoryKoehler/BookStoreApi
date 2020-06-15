using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using BookstoreApi.Controllers;
using EventFlow.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreApi.Commands
{
    public class UpsertOrderCommand : Command<OrderAggregate, OrderId, UpsertOrderExecutionResult>
    {
        public int LegacyId { get; }
        public int LegacyCustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public List<Entities.OrderedItem> OrderedItems { get; set; }


        public UpsertOrderCommand(int legacyId, int legacyCustomerId, DateTime orderDate, decimal orderTotal, List<OrderedItemDto> orderedItems)
            : base(OrderId.New)
        {
            LegacyId = legacyId;
            LegacyCustomerId = legacyCustomerId;
            OrderDate = orderDate;
            OrderTotal = orderTotal;
            OrderedItems = new List<Entities.OrderedItem>();
            OrderedItems.AddRange(orderedItems.Select(_ => new Entities.OrderedItem(OrderedItemId.New, _.LegacyBookId, _.Quantity, _.Price)));
        }
    }
}
