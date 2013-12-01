using AutoMapper;
using Peregrin.Services.Automapper;

namespace Peregrin
{
    public static class Bootstrapper
    {
        public static void MapperInitialize()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<WroclawVehicleConfig>());
        }
    }
}
