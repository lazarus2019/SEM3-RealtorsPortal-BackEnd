using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class City
    {
        public City()
        {
            Properties = new HashSet<Property>();
        }

        public string CityId { get; set; }
        public string Name { get; set; }
        public string RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
