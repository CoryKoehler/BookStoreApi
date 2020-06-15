using EventFlow.Core;

namespace BookstoreApi.AggregateIds
{
    public class AuthorId : Identity<AuthorId>
    {
        public AuthorId(string value) : base(value) { }
    }
}
