using NETAPI_SEM3.Models;
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
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CityCountryId { get; set; }
        public string CityCountryName { get; set; }
        public int CityCountryRegionId { get; set; }
        public string CityCountryRegionName { get; set; }
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
        public string Email { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<Image> Images { get; set; }
    }
}
