using System;
using AutoMapper;
using Peregrin.Data;
using Peregrin.Services.DeserializeModel;

namespace Peregrin.Services.Automapper
{
    public class WroclawVehicleConfig : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<WroclawVehicleJsonModel, Vehicle>()
                .ForMember(x => x.X, opt => opt.MapFrom(p => p.x))
                .ForMember(x => x.Y, opt => opt.MapFrom(p => p.y));

            base.Configure();
        }
    }
}
