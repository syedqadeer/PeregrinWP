using Peregrin.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peregrin.Data.Interface
{
    public interface IVehicle
    {
        string Name { get; set; }
        VehicleType Type { get; set; }
        double X { get; set; }
        double Y { get; set;}

    }
}
