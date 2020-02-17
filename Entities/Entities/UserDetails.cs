using System;
using System.Collections.Generic;

namespace Entities.Entities
{
    public partial class UserDetails
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string HomeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string MailingAddressLine1 { get; set; }
        public string MailingAddressLine2 { get; set; }
        public string Province { get; set; }
        public string Municipality { get; set; }
        public string Barangay { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public virtual Users IdNavigation { get; set; }
    }
}
