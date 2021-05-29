using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class City
    {
        public string CityId { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
