using Peregrin.Common.Enum;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peregrin.Services.Wrappers
{
    public interface IMapWrapper
    {
        void DeleteOldPins();
        void AddNewPins(IDictionary<string, VehicleType> selectedVehicles);
        void CreateNewPin(GeoCoordinate geoCoordinate);
        void SetupMap();
    }
}
