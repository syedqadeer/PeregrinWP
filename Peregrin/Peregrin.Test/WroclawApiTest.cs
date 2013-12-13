using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using Peregrin.Common.Enum;
using Peregrin.Data;
using Peregrin.Extensions;
using Peregrin.Services.DeserializeModel;
using Peregrin.Services.Providers;
using RestSharp;


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
            
            Bootstrapper.MapperInitialize();
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
            var result = await _vehicleProvider.GetVehicle("", VehicleType.Bus);
            
            //assert
            
            result.Name.Should().Be("122");
            result.Type.Should().Be(VehicleType.Bus);
            result.X.Should().BeInRange(50.0, 60.0);
            result.Y.Should().BeInRange(10.0, 30.0);
        }



    }
}
