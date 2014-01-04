using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Peregrin.Common.Enum;
using Peregrin.Data.Interface;
using Peregrin.Services.Providers;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Peregrin.Test.Providers
{
   [TestClass]
   public  class WroclawProviderTest
    {
        private IVehicleProvider _provider;

        [TestInitialize]
        public void StartUp()
        {
            _provider = new WroclawVehicleProvider();
            
        }

        [TestMethod]
        public async Task GetVehicle()
        {
            //asset
            var name = "255";
            var type = VehicleType.Bus;
            
            //act
            var result = await _provider.GetVehicle(new KeyValuePair<string, VehicleType>(name, type));


            //assert
            

        }

        [TestMethod]
        public async Task GetVehicles()
        {
            //asset
            var dictionaryOfVehicles = new Dictionary<string, VehicleType>
            {
                {"125", VehicleType.Bus},
                {"146", VehicleType.Bus},
                {"14", VehicleType.Tram}
            };

            //act
            var result = await _provider.GetVehicles(dictionaryOfVehicles);


            //assert
            result.Should().HaveCount(3);
            result.Should().BeOfType<IEnumerable<IVehicle>>();
        }

        [TestMethod]
        public void GetAvailableVehicles()
        {           
            var result = _provider.GetAvailableVehicles(VehicleType.Bus);

            result.Should().BeOfType<List<string>>();
        }

    }
}
