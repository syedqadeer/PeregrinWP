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

namespace Peregrin.Services.Wrappers
{
    public class MapWrapper : IMapWrapper
    {
        private Map _mapController;
        private IVehicleProvider _wroclawProvider;

        public MapWrapper(Map mapController)
        {
            _mapController = mapController;
            _wroclawProvider = new WroclawVehicleProvider();
            SetupMap();
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

        public void CreateNewPin(GeoCoordinate geoCoordinate)
        {
            Pushpin pushpin = new Pushpin();
            MapLayer mapLayer = new MapLayer();
            MapOverlay overlay = new MapOverlay();
            mapLayer.Add(overlay);
            overlay.GeoCoordinate = geoCoordinate;
            overlay.Content = pushpin;
        }

        public void SetupMap()
        {
            _mapController.Center = new GeoCoordinate(51.111, 17.030);
            _mapController.ZoomLevel = 8;
        }
    }
}
