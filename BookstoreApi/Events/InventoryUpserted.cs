using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using EventFlow.Aggregates;
using EventFlow.EventStores;

namespace BookstoreApi.Events
{
    [EventVersion("InventoryUpserted", 1)]
    public class InventoryUpserted : AggregateEvent<InventoryAggregate, InventoryId>
    {
        public int LegacyId { get; set; }
        public int LegacyBookId { get; set; }
        public int StockLevelUsed { get; set; }
        public int StockLevelNew { get; set; }


        public InventoryUpserted(int legacyId, int legacyBookId, int stockLevelUsed, int stockLevelNew)
        {
            LegacyId = legacyId;
            LegacyBookId = legacyBookId;
            StockLevelUsed = stockLevelUsed;
            StockLevelNew = stockLevelNew;
        }
    }
}
