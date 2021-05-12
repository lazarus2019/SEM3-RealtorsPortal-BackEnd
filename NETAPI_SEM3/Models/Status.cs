using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Status
    {
        public Status()
        {
            Properties = new HashSet<Property>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
