using System.Collections.Generic;

namespace BookstoreApi.Controllers
{
    public class UpsertAuthorRequest
    {
        public int LegacyId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        //public List<LegacyBookDto> Books { get; set; }

        //public class LegacyBookDto
        //{
        //    public int LegacyId { get; set; }
        //    public int Price { get; set; }
        //    public int Edition { get; set; }
        //    public int LegacyAuthorId { get; set; }
        //    public int LegacyPublisherId { get; set; }
        //}
    }
}
