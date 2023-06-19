using AutoMapper;
using MobileWorld.Application.ViewModel;
using MobileWorld.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileWorld.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderViewModel, OrderMap>();
                //.ForMember(dest => dest.AddressId, opt => opt.MapFrom(map => map.Address.Id));
        }
    }
}
