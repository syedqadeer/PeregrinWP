using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Newtonsoft.Json;
using Peregrin.Data;
using Peregrin.Data.Interface;
using Peregrin.Enums;
using Peregrin.Extensions;
using RestSharp;


namespace Peregrin.Test
{
    [TestClass]
    public class WroclawVehiclesPositionTest
    {
        private readonly string _apiAddress = "http://pasazer.mpk.wroc.pl/position.php";
        private RestClient _restClient;

        [TestInitialize]
        public void SetUp()
        {
            _restClient = new RestClient(_apiAddress);
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
            restRequest.AddParameter("busList[bus][]", 247);

            var result = await _restClient.GetResponseAsync(restRequest);

            var vehicle = JsonConvert.DeserializeObject<IVehicle>(result.Content);

            vehicle.Name.Should().Be("247");
            vehicle.Type.Should().Be(VehicleType.Bus);
            vehicle.X.Should().BeInRange(50.0, 60.0);
            vehicle.Y.Should().BeInRange(10.0, 30.0);
        }



    }
}
