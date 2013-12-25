﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Peregrin.Common.Enum;
using Peregrin.Data;
using Peregrin.Data.Interface;
using Peregrin.Services.DeserializeModel;
using RestSharp;
using Peregrin.Common.Extensions;
using System.Linq;
namespace Peregrin.Services.Providers
{
    public class WroclawVehicleProvider : IVehicleProvider
    {
        private readonly string _apiClient = "http://pasazer.mpk.wroc.pl/position.php";

        public async Task<IVehicle> GetVehicle(string name, VehicleType vehicleType)
        {
            var client = new RestClient(_apiClient);
            var request = new RestRequest("/", Method.POST);
            request.AddParameter(string.Format("busList[{0}][]",vehicleType.ToString().ToLower()), name);

            var result = await client.GetResponseAsync(request);
            var deserializedString = JsonConvert.DeserializeObject<IEnumerable<WroclawVehicleJsonModel>>(result.Content);            
            var mappedObject = Mapper.Map<IEnumerable<WroclawVehicleJsonModel>, IEnumerable<Vehicle>>(deserializedString);
            

            return mappedObject.FirstOrDefault();
        }

        public async Task<IEnumerable<IVehicle>> GetVehicles(IDictionary<string, VehicleType> dictionaryOfVehicles)
        {
            var client = new RestClient(_apiClient);
            var request = new RestRequest("/", Method.POST);

            foreach (var item in dictionaryOfVehicles)
            {
                request.AddParameter(string.Format("busList[{0}][]", item.Value), item.Key);
            }

            var result = await client.GetResponseAsync(request);
            var deserializedString = JsonConvert.DeserializeObject<IEnumerable<WroclawVehicleJsonModel>>(result.Content);
            var mappedObject = Mapper.Map<IEnumerable<WroclawVehicleJsonModel>, IEnumerable<Vehicle>>(deserializedString);


            return mappedObject;
        }
    }
}
