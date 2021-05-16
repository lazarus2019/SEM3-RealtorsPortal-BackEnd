using AutoMapper;
using NETAPI_SEM3.Entities;
using NETAPI_SEM3.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETAPI_SEM3.Data
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PropertyViewModel, Property>().ReverseMap();
            CreateMap<MemberViewModel, Member>().ReverseMap();
            CreateMap<AdspackageViewModel, AdPackage>().ReverseMap();
        }
    }
}
