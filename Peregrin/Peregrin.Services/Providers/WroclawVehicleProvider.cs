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
            var dictionaryOfVehicles = new Dictionary<string, VehicleType>()
            {
                {"A", VehicleType.Bus},{"C", VehicleType.Bus},{"D", VehicleType.Bus},
                {"K", VehicleType.Bus},{"N", VehicleType.Bus},{"100", VehicleType.Bus},
                {"103", VehicleType.Bus},{"105", VehicleType.Bus},{"107", VehicleType.Bus},
                {"109", VehicleType.Bus},{"110", VehicleType.Bus},{"113", VehicleType.Bus},
                {"114", VehicleType.Bus},{"115", VehicleType.Bus},{"116", VehicleType.Bus},
                {"118", VehicleType.Bus},{"119", VehicleType.Bus},{"120", VehicleType.Bus},
                {"122", VehicleType.Bus},{"125", VehicleType.Bus},{"126", VehicleType.Bus},
                {"127", VehicleType.Bus},{"128", VehicleType.Bus},{"129", VehicleType.Bus},
                {"130", VehicleType.Bus},{"131", VehicleType.Bus},{"132", VehicleType.Bus},
                {"133", VehicleType.Bus},{"134", VehicleType.Bus},{"136", VehicleType.Bus},
                {"140", VehicleType.Bus},{"141", VehicleType.Bus},{"142", VehicleType.Bus},
                {"144", VehicleType.Bus},{"145", VehicleType.Bus},{"146", VehicleType.Bus},
                {"147", VehicleType.Bus},{"149", VehicleType.Bus},{"240", VehicleType.Bus},
                {"241", VehicleType.Bus},{"243", VehicleType.Bus},{"245", VehicleType.Bus},
                {"246", VehicleType.Bus},{"247", VehicleType.Bus},{"249", VehicleType.Bus},
                {"250", VehicleType.Bus},{"251", VehicleType.Bus},{"253", VehicleType.Bus},
                {"255", VehicleType.Bus},{"257", VehicleType.Bus},{"259", VehicleType.Bus},
                {"403", VehicleType.Bus},{"406", VehicleType.Bus}, {"409", VehicleType.Bus},
                {"435", VehicleType.Bus}, {"2", VehicleType.Tram}, {"3", VehicleType.Tram},
                {"5", VehicleType.Tram},{"6", VehicleType.Tram},{"7", VehicleType.Tram},
                {"8", VehicleType.Tram},{"9", VehicleType.Tram},{"0L", VehicleType.Tram},
                {"0P", VehicleType.Tram}, {"10", VehicleType.Tram}, {"11", VehicleType.Tram},
                {"14", VehicleType.Tram}, {"15", VehicleType.Tram}, {"17", VehicleType.Tram},
                {"20", VehicleType.Tram},{"23", VehicleType.Tram},{"24", VehicleType.Tram},
                {"71", VehicleType.Tram}, {"31+", VehicleType.Tram}, {"32+", VehicleType.Tram},
                {"33+", VehicleType.Tram}
            };

            
            return dictionaryOfVehicles.Where(x => x.Value == vehicleType).ToDictionary(k => k.Key, v => v.Value);

        }
    }
}
