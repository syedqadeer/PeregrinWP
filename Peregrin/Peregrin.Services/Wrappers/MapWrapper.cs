using System.Windows;
using System.Windows.Input;
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
                CreateNewPin(item);
            }
        }

        protected void CreateNewPin(IVehicle vehicle)
        {
            var pushpin = new Pushpin();
            var mapLayer = new MapLayer();
            var overlay = new MapOverlay();
            pushpin.DataContext = vehicle;
            pushpin.Content = vehicle.Name;
            pushpin.Tap += pushpin_tap;
            mapLayer.Add(overlay);
            overlay.GeoCoordinate = new GeoCoordinate(vehicle.X, vehicle.Y);
            overlay.Content = pushpin;
            _mapController.Layers.Add(mapLayer);
        }

        private void pushpin_tap(object sender, GestureEventArgs eventArgs)
        {
            var pushpin = sender as Pushpin;

            if (pushpin != null && pushpin.DataContext != null)
            {
                var vehicle = (IVehicle)pushpin.DataContext;
                _mapController.Center = new GeoCoordinate(vehicle.X, vehicle.Y);
                _mapController.ZoomLevel = 15;
            }

        }

        public void SetupMap()
        {
            _mapController.Center = new GeoCoordinate(51.111, 17.030);
            _mapController.ZoomLevel = 11;
        }
    }
}
