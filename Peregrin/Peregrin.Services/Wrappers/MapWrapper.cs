using Microsoft.Phone.Maps.Controls;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Toolkit;
using Peregrin.Services.Providers;
using Peregrin.Common.Enum;
using Peregrin.Data.Interface;

namespace Peregrin.Services.Wrappers
{
    public class MapWrapper : IMapWrapper
    {
        private readonly Map _mapController;
        private readonly IVehicleProvider _wroclawProvider;

        public MapWrapper(Map mapController)
        {
            _mapController = mapController;
            _wroclawProvider = new WroclawVehicleProvider();
        }

        public void DeleteOldPins()
        {
            _mapController.Layers.Clear();
        }

        public async void AddNewPins(IDictionary<string, VehicleType> selectedVehicles)
        {
            var listOfVehicles = await _wroclawProvider.GetVehicles(selectedVehicles);

            foreach (var item in listOfVehicles)
            {
                CreateNewPin(new GeoCoordinate(item.X, item.Y));
            }
        }

        protected void CreateNewPin(GeoCoordinate geoCoordinate)
        {
            var pushpin = new Pushpin();
            var mapLayer = new MapLayer();
            var overlay = new MapOverlay();
            mapLayer.Add(overlay);
            overlay.GeoCoordinate = geoCoordinate;
            overlay.Content = pushpin;
            _mapController.Layers.Add(mapLayer);
        }

        public void SetupMap()
        {
            _mapController.Center = new GeoCoordinate(51.111, 17.030);
            _mapController.ZoomLevel = 11;
        }
    }
}
