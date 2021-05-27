using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.ViewModel
{
    public class PropertyViewModel
    {
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string CityRegionId { get; set; }
        public string CityRegionName { get; set; }
        public string CityRegionCountryId { get; set; }
        public string CityRegionCountryName { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public int BedNumber { get; set; }
        public int RoomNumber { get; set; }
        public double Area { get; set; }
        public DateTime? SoldDate { get; set; }
        public DateTime UploadDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int MemberId { get; set; }
        public string MemberFullName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
