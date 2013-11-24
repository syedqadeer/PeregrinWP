using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peregrin.Data.Interface;
using Peregrin.Enums;

namespace Peregrin.Services.Providers
{
    public interface IVehicleProvider
    {
        IVehicle GetVehicle(string name, VehicleType vehicleType);
        IEnumerable<IVehicle> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles);
    }
}
