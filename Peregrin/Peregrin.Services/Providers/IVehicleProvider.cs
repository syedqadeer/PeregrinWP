using System.Collections.Generic;
using System.Threading.Tasks;
using Peregrin.Common.Enum;
using Peregrin.Data.Interface;

namespace Peregrin.Services.Providers
{
    public interface IVehicleProvider
    {
        Task<IEnumerable<IVehicle>> GetVehicle(KeyValuePair<string, VehicleType> vehicleKeyValuePair);
        Task<IEnumerable<IVehicle>> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles);
        IDictionary<string, VehicleType> GetAvailableVehicles(VehicleType vehicleType);
    }
}
