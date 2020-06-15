using BookstoreApi.AggregateIds;
using BookstoreApi.Events;
using EventFlow.Aggregates;

namespace BookstoreApi.Aggregates
{
    public class AuthorAggregate : AggregateRoot<AuthorAggregate, AuthorId>
    {
        private readonly AuthorState _state = new AuthorState();

        public AuthorAggregate(AuthorId id) : base(id)
        {
            Register(_state);
        }

        public int LegacyId => _state.LegacyId;
        public string AuthorName => _state.AuthorName;
        public string Country => _state.Country;

        public virtual void UpsertAuthor(int legacyId, string authorName, string country)
        {
            Emit(new AuthorUpserted(legacyId, authorName, country), new Metadata());
        }

    }
}
