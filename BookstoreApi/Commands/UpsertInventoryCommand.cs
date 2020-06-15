using BookstoreApi.AggregateIds;
using BookstoreApi.Aggregates;
using BookstoreApi.CommandHandlers.Results;
using EventFlow.Commands;

namespace BookstoreApi.Commands
{
    public class UpsertInventoryCommand : Command<InventoryAggregate, InventoryId, UpsertInventoryExecutionResult>
    {
        public int LegacyId { get; set; }
        public int LegacyBookId { get; set; }
        public int StockLevelUsed { get; set; }
        public int StockLevelNew { get; set; }

        public UpsertInventoryCommand(int legacyId, int legacyBookId, int stockLevelUsed, int stockLevelNew) : base(InventoryId.New)
        {
            LegacyId = legacyId;
            LegacyBookId = legacyBookId;
            StockLevelUsed = stockLevelUsed;
            StockLevelNew = stockLevelNew;
        }
    }
}
