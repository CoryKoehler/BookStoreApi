using EventFlow.Aggregates.ExecutionResults;

namespace BookstoreApi.CommandHandlers.Results
{
    public class UpsertCustomerExecutionResult : ExecutionResult
    {
        public UpsertCustomerExecutionResult(string customerId, bool isSuccess)
        {
            CustomerId = customerId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string CustomerId { get; }
    }
}