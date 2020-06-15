using EventFlow.Aggregates.ExecutionResults;

namespace BookstoreApi.CommandHandlers.Results
{
    public class UpsertBookExecutionResult : ExecutionResult
    {
        public UpsertBookExecutionResult(string bookId, bool isSuccess)
        {
            BookId = bookId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string BookId { get; }
    }
}