using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.ViewModel
{
    public class AdspackageViewModel
    {
        public int PackageId { get; set; }
        public string NameAdPackage { get; set; }
        public int Period { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool StatusBuy { get; set; }
        public int PostNumber { get; set; }
        public bool isDelete { get; set; }
    }
}
