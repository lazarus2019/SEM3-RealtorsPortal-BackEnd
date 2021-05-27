using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Entities
{
    public class NewCategory
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
       
    }
}
