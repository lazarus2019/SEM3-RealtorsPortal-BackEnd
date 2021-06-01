using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Category
    {
        public Category()
        {
            Properties = new HashSet<Property>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? IsShow { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
