using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        public string RegionId { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
