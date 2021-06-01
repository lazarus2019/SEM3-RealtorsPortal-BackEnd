using System;
using System.Collections.Generic;

#nullable disable

namespace NETAPI_SEM3.Models
{
    public partial class News
    {
        public News()
        {
            Images = new HashSet<Image>();
        }

        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

        public virtual NewsCategory Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
