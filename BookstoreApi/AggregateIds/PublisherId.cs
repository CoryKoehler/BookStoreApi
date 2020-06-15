using EventFlow.Core;

namespace BookstoreApi.AggregateIds
{
    public class PublisherId : Identity<PublisherId>
    {
        public PublisherId(string value) : base(value) { }
    }
}
