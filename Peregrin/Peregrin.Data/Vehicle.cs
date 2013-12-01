using Peregrin.Common.Enum;
using Peregrin.Data.Interface;

namespace Peregrin.Data
{
    public class Vehicle : IVehicle
    {
        public string Name { get; set; }
        public VehicleType Type { get; set; }
        public double X { get; set; }
        public double Y { get; set; }


    }
}
