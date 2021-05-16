using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Entities
{
    public partial class PropertyImage
    {
        public int ImageId { get; set; }
        public int? PropertyId { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        public virtual Property Property { get; set; }
    }
}
