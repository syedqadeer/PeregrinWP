using System.Collections.Generic;
using System.Threading.Tasks;
using Peregrin.Common.Enum;
using Peregrin.Data.Interface;

namespace Peregrin.Services.Providers
{
    public interface IVehicleProvider
    {
        Task<IVehicle> GetVehicle(string name, VehicleType vehicleType);
        Task<IEnumerable<IVehicle>> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles);
    }
}
