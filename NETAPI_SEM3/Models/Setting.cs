using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Setting
    {
        public int SettingId { get; set; }
        public int? NumTopProperty { get; set; }
        public int? NumPopularLocation { get; set; }
        public int? NumNews { get; set; }
        public int? NumPopularAgent { get; set; }
        public int? NumProperty { get; set; }
        public int NumMaxImageProperty { get; set; }
        public int NumMaxImageNews { get; set; }
        public int? NumSatisfiedCustomer { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Services { get; set; }
        public string AboutUsTitle { get; set; }
        public string ThumbnailWebsite { get; set; }
        public string ThumbnailAboutUs { get; set; }
        public string ThumbnailHome { get; set; }
        public string Reviews { get; set; }
    }
}
