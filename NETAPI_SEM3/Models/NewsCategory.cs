using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class NewsCategory
    {
        public NewsCategory()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
