using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class CustomerContact
    {
        public int ContactId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int? CategoryId { get; set; }
        public string CustomerContent { get; set; }

        public virtual Category Category { get; set; }
    }
}
