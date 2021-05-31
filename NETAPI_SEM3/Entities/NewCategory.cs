using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Entities
{
    public class NewCategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool? IsShow { get; set; }
    }
}
