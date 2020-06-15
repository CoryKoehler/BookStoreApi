namespace BookstoreApi.Controllers
{
    public class UpsertBookRequest
    {
        public int LegacyId { get; set; }
        public int Price { get; set; }
        public int Edition { get; set; }
        public int LegacyAuthorId { get; set; }
        public int LegacyPublisherId { get; set; }
    }
}
