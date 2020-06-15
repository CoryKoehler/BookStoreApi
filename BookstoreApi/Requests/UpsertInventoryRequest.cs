using System.Collections.Generic;

namespace BookstoreApi.Controllers
{
    public class UpsertInventoryRequest
    {
        public int LegacyId { get; set; }
        public int LegacyBookId { get; set; }
        public int StockLevelUsed { get; set; }
        public int StockLevelNew { get; set; }
    }
}
