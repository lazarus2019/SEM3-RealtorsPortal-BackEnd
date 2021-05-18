using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class NewsImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
