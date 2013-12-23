using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Peregrin.Data;
using Peregrin.Services.DeserializeModel;
using FluentAssertions;
using Peregrin.Common.Enum;


namespace Peregrin.Test
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestInitialize()]
        public void StartUp()
        {
            Bootstrapper.MapperInitialize();
        }

        [TestMethod]
        public void CheckAllMappings()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void check_json_wroclaw_model_to_data_vehicle_model()
        {
            //asset
            WroclawVehicleJsonModel jsonModel = new WroclawVehicleJsonModel()
            {
                name = "255",
                type = "bus",
                x = "51.2333552",
                y = "17.2587744"
            };

            //act
            var result = Mapper.Map<WroclawVehicleJsonModel, Vehicle>(jsonModel);

            //assert
            Mapper.AssertConfigurationIsValid();
            result.Name.Should().Be(jsonModel.name);
            result.Type.Should().Be(Enum.GetName(typeof(VehicleType),jsonModel.type));
            result.X.Should().Be(51.2333552);
            result.Y.Should().Be(17.2587744);
        }
    }
}
