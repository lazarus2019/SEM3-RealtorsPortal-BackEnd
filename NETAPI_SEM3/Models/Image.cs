using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class Image
    {
        public int ImageId { get; set; }
        public int? PropertyId { get; set; }
        public int? NewsId { get; set; }
        public string Name { get; set; }

        public virtual News News { get; set; }
        public virtual Property Property { get; set; }
    }
}
