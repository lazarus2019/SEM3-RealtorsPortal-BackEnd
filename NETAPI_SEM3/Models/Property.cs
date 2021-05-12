using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Property
    {
        public Property()
        {
            Invoices = new HashSet<Invoice>();
            Mailboxes = new HashSet<Mailbox>();
            PropertyImages = new HashSet<PropertyImage>();
        }

        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string CityId { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public int? BedNumber { get; set; }
        public int? RoomNumber { get; set; }
        public double? Area { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime UploadDate { get; set; }
        public int? StatusId { get; set; }
        public int CategoryId { get; set; }
        public int? MemberId { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual City City { get; set; }
        public virtual Member Member { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Mailbox> Mailboxes { get; set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
    }
}
