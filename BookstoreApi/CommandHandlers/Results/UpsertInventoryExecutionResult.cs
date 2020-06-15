using EventFlow.Aggregates.ExecutionResults;

namespace BookstoreApi.CommandHandlers.Results
{
    public class UpsertInventoryExecutionResult : ExecutionResult
    {
        public UpsertInventoryExecutionResult(string inventoryId, bool isSuccess)
        {
            InventoryId = inventoryId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string InventoryId { get; }
    }
}