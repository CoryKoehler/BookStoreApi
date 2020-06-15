using System;
using System.Collections.Generic;

namespace BookstoreApi.Controllers
{
    public class UpsertOrderRequest
    {
        public int LegacyId { get; set; }
        public int LegacyCustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public List<OrderedItemDto> OrderedItems { get; set; }
    }

    public class OrderedItemDto
    {
        public int LegacyBookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
