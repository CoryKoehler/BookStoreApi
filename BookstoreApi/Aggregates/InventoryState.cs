using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class InventoryState : AggregateState<InventoryAggregate, InventoryId, InventoryState>,
        IApply<InventoryUpserted>
    {
        public int LegacyId { get; private set; }
        public int LegacyBookId { get; private set; }
        public int StockLevelUsed { get; private set; }
        public int StockLevelNew { get; private set; }

        public InventoryState()
        {

        }

        public void Apply(InventoryUpserted aggregateEvent)
        {
            LegacyId = aggregateEvent.LegacyId;
            LegacyBookId = aggregateEvent.LegacyBookId;
            StockLevelUsed = aggregateEvent.StockLevelUsed;
            StockLevelNew = aggregateEvent.StockLevelNew;
        }
    }
}
