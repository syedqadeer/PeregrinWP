using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Peregrin.Data.Interface;
using Peregrin.Enums;

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
