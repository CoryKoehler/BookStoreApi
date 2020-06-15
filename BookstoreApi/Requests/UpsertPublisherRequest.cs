using System.Collections.Generic;

namespace BookstoreApi.Controllers
{
    public class UpsertPublisherRequest
    {
        public int LegacyId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
