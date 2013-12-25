using System;
using AutoMapper;
using Peregrin.Data;
using Peregrin.Services.DeserializeModel;
using Peregrin.Common.Extensions;
namespace Peregrin.Services.Automapper
{
    public class WroclawVehicleConfig : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<WroclawVehicleJsonModel, Vehicle>().IgnoreAllNonExisting();   

        }
    }
}
