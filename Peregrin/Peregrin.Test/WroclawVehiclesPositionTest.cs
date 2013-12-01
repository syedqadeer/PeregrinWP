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
            restRequest.AddParameter("busList[bus][]", 245);

            var result = await _restClient.GetResponseAsync(restRequest);

            var deserializedString = JsonConvert.DeserializeObject<IEnumerable<WroclawVehicleJsonModel>>(result.Content);

            var vehicle = Mapper.Map<IEnumerable<WroclawVehicleJsonModel>, IEnumerable<Vehicle>>(deserializedString);

            var assert = vehicle.FirstOrDefault(x=>x.Name=="245");
            assert.Name.Should().Be("245");
            assert.Type.Should().Be(VehicleType.Bus);
            assert.X.Should().BeInRange(50.0, 60.0);
            assert.Y.Should().BeInRange(10.0, 30.0);
        }



    }
}
