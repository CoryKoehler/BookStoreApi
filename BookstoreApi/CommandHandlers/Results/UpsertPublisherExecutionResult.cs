using EventFlow.Aggregates.ExecutionResults;

namespace BookstoreApi.CommandHandlers.Results
{
    public class UpsertPublisherExecutionResult : ExecutionResult
    {
        public UpsertPublisherExecutionResult(string publisherId, bool isSuccess)
        {
            PublisherId = publisherId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string PublisherId { get; }
    }
}