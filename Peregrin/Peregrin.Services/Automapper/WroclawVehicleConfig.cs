using AutoMapper;
using Peregrin.Data;
using Peregrin.Services.DeserializeModel;

namespace Peregrin.Services.Automapper
{
    public class WroclawVehicleConfig : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<WroclawVehicleJsonModel, Vehicle>();

            base.Configure();
        }
    }
}
