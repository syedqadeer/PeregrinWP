using System;
using System.Collections.Generic;
using Peregrin.Common.Enum;
using Peregrin.Data.Interface;

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
