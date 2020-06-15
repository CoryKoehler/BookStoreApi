using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class PublisherAggregate : AggregateRoot<PublisherAggregate, PublisherId>
    {
        private readonly PublisherState _state = new PublisherState();

        public PublisherAggregate(PublisherId id) : base(id)
        {
            Register(_state);
        }

        public int LegacyId => _state.LegacyId;
        public string PublisherName => _state.PublisherName;
        public string Country => _state.Country;

        public virtual void UpsertPublisher(int legacyId, string authorName, string country)
        {
            Emit(new PublisherUpserted(legacyId, authorName, country), new Metadata());
        }

    }
}
