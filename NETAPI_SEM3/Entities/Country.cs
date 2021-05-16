using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Entities
{
    public partial class Country
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        public string CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
