using EventFlow.Aggregates.ExecutionResults;

namespace BookstoreApi.CommandHandlers.Results
{
    public class UpsertOrderExecutionResult : ExecutionResult
    {
        public UpsertOrderExecutionResult(string orderId, bool isSuccess)
        {
            OrderId = orderId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string OrderId { get; }
    }
}