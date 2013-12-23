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
            _provider = new WroclawVehicleProvider();;
        }

        [TestMethod]
        public async Task GetVehicle()
        {
            //asset
            var name = "125";
            var type = VehicleType.Bus;

            //act
            var result = await _provider.GetVehicle(name, type);


            //assert
            result.Name.Should().Be(name);
            result.Type.Should().Be(type);
            result.X.Should().BeInRange(52.00, 55.00);
            result.Y.Should().BeInRange(10.00, 20.00);

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

    }
}
