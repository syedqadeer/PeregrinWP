using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Peregrin.Common.Enum;
using Peregrin.Data;
using Peregrin.Data.Interface;
using RestSharp;
using Peregrin.Common.Extensions;
using System.Linq;
namespace Peregrin.Services.Providers
{
    public class WroclawVehicleProvider : IVehicleProvider
    {
        private readonly string _apiClient = "http://pasazer.mpk.wroc.pl/position.php";

        public async Task<IEnumerable<IVehicle>> GetVehicle(KeyValuePair<string, VehicleType> vehicleKeyValuePair)
        {
            var client = new RestClient(_apiClient);
            var request = new RestRequest("/", Method.POST);
            request.AddParameter(string.Format("busList[{0}][]", vehicleKeyValuePair.Value.ToString().ToLower()), vehicleKeyValuePair.Key);

            var result = await client.GetResponseAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(result.Content);
        }

        public async Task<IEnumerable<IVehicle>> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles)
        {
            var client = new RestClient(_apiClient);
            var request = new RestRequest("/", Method.POST);

            foreach (var item in dictionaryOfVehicles)
            {
                request.AddParameter(string.Format("busList[{0}][]", item.Value.ToString().ToLower()), item.Key);
            }
            var result = await client.GetResponseAsync(request);
            var deserializedString = JsonConvert.DeserializeObject<IEnumerable<Vehicle>>(result.Content);

            return deserializedString;
        }

        public IDictionary<string, VehicleType> GetAvailableVehicles(VehicleType vehicleType)
        {
            var dictionaryOfVehicles = new Dictionary<string, VehicleType>();

            dictionaryOfVehicles.Add("A", VehicleType.Bus);
            dictionaryOfVehicles.Add("D", VehicleType.Bus);
            dictionaryOfVehicles.Add("100", VehicleType.Bus);
            dictionaryOfVehicles.Add("125", VehicleType.Bus);
            dictionaryOfVehicles.Add("126", VehicleType.Bus);
            dictionaryOfVehicles.Add("33+", VehicleType.Tram);
            dictionaryOfVehicles.Add("32+", VehicleType.Tram);
            dictionaryOfVehicles.Add("12", VehicleType.Tram);
            dictionaryOfVehicles.Add("255", VehicleType.Bus);

            return dictionaryOfVehicles.Where(x => x.Value == vehicleType).ToDictionary(k => k.Key, v => v.Value);

        }
    }
}
