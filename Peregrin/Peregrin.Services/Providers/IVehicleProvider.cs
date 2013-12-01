using System.Collections.Generic;
using Peregrin.Common.Enum;
using Peregrin.Data.Interface;

namespace Peregrin.Services.Providers
{
    public interface IVehicleProvider
    {
        IVehicle GetVehicle(string name, VehicleType vehicleType);
        IEnumerable<IVehicle> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles);
    }
}
