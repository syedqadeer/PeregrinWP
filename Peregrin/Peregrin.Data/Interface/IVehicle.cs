using Peregrin.Common.Enum;

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
