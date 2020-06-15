using EventFlow.Aggregates.ExecutionResults;

namespace BookstoreApi.CommandHandlers.Results
{
    public class UpsertAuthorExecutionResult : ExecutionResult
    {
        public UpsertAuthorExecutionResult(string authorId, bool isSuccess)
        {
            AuthorId = authorId;
            IsSuccess = isSuccess;
        }

        public override bool IsSuccess { get; }
        public string AuthorId { get; }
    }
}