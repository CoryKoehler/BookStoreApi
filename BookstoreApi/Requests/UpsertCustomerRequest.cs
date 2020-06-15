using System.Collections.Generic;

namespace BookstoreApi.Controllers
{
    public class UpsertCustomerRequest
    {
        public int LegacyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
    }
}
