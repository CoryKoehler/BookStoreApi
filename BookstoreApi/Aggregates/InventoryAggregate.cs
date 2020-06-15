using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class InventoryAggregate : AggregateRoot<InventoryAggregate, InventoryId>
    {
        private readonly InventoryState _state = new InventoryState();

        public InventoryAggregate(InventoryId id) : base(id)
        {
            Register(_state);
        }

        public int LegacyId => _state.LegacyId;
        public int LegacyBookId => _state.LegacyBookId;
        public int StockLevelUsed => _state.StockLevelUsed;
        public int StockLevelNew => _state.StockLevelNew;

        public virtual void UpsertInventory(int legacyId, int legacyBookId, int stockLevelUsed, int stockLevelNew)
        {
            Emit(new InventoryUpserted(legacyId, legacyBookId, stockLevelUsed, stockLevelNew), new Metadata());
        }

    }
}
