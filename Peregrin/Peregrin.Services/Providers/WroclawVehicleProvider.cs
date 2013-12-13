using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Peregrin.Common.Enum;
using Peregrin.Data;
using Peregrin.Data.Interface;
using Peregrin.Services.DeserializeModel;

namespace Peregrin.Services.Providers
{
    public class WroclawVehicleProvider : IVehicleProvider
    {
        private readonly string _apiClient = "http://pasazer.mpk.wroc.pl/position.php";

        public async Task<IVehicle> GetVehicle(string name, VehicleType vehicleType)
        {
            var client = RestClient(_apiClient);
            var request = RestRequest();

            var result = await client.GetResponseAsync();
            var deserializedString = JsonConvert.DeserializeObject<WroclawVehicleJsonModel>(result.Content);
            var mappedObject = Mapper.Map<WroclawVehicleJsonModel, Vehicle>(deserializedString);
        
            return mappedObject;
        }

        public async Task<IEnumerable<IVehicle>> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles)
        {
            throw new NotImplementedException();
        }
    }
}
