using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Peregrin.Common.Enum;
using Peregrin.Services.Providers;
using RestSharp;
using Peregrin.Common.Extensions;

namespace Peregrin.Test
{
    [TestClass]
    public class WroclawApiTest
    {
        private readonly string _apiAddress = "http://pasazer.mpk.wroc.pl/position.php";
        private RestClient _restClient;
        private IVehicleProvider _vehicleProvider; 


        [TestInitialize]
        public void SetUp()
        {
            _restClient = new RestClient(_apiAddress);

            _vehicleProvider = new WroclawVehicleProvider();
            
           
        }
        
        [TestMethod]
        public async Task SetUpConnectionWithApi()
        {
            //arrange
            var restRequest = new RestRequest("/", Method.GET);

            var response = HttpStatusCode.NotFound;

            //act
            var result = await _restClient.GetResponseAsync(restRequest);
            if (result.ResponseStatus == ResponseStatus.Completed)
            {
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    response = HttpStatusCode.OK;
                }
            }
            
            
            //assert
            response.Should().Be(HttpStatusCode.OK);
            
        }

        [TestMethod]
        public async Task GetLocationOfSpecificVehicle()
        {
            //arrange
            var restRequest = new RestRequest("/", Method.POST);
            restRequest.AddParameter("busList[bus][]", 122);

            //act
            var result = await _vehicleProvider.GetVehicle(new KeyValuePair<string, VehicleType>("122", VehicleType.Bus));
            
            //assert
            
           
        }



    }
}
