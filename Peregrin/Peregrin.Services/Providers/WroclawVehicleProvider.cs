using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peregrin.Data.Interface;
using Peregrin.Enums;

namespace Peregrin.Services.Providers
{
    public class WroclawVehicleProvider : IVehicleProvider
    {
        private readonly string _apiClient = "http://pasazer.mpk.wroc.pl/position.php";

        public IVehicle GetVehicle(string name, VehicleType vehicleType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IVehicle> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles)
        {
            throw new NotImplementedException();
        }
    }
}
