using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Peregrin.Services.Automapper
{
    public class CommonConfigs : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<string, decimal>();
            Mapper.CreateMap<string, Enum>();
            base.Configure();
        }
    }
}
