﻿using Microsoft.Phone.Controls;
using Nokia.Phone.HereLaunchers;
using System.Device.Location;
using Microsoft.Phone.Maps;
using System.Windows.Threading;
using System;
using System.Windows;
using System.Linq;
using Microsoft.Phone.Shell;
using System.Collections.Generic;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Maps.Controls;
using Peregrin.Common.Enum;
using Peregrin.Services.Providers;
using Peregrin.Services.Wrappers;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Peregrin.View.Portrait
{
    public partial class MapView : PhoneApplicationPage
    {
        private IDictionary<string, VehicleType> _myVehicles;
        private readonly IMapWrapper _mapWrapper;
        private readonly IVehicleProvider _vehicleProvider;

        public MapView()
        {
            InitializeComponent();
            _vehicleProvider = new WroclawVehicleProvider();
            _mapWrapper = new MapWrapper(CityMap);
            GetLocations();
            
        }

        private void Map_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            MapsSettings.ApplicationContext.ApplicationId = "f5f04dbf-5ac1-46d5-8070-514c9153971d";
            MapsSettings.ApplicationContext.AuthenticationToken = "rPOvHDgmcJ_v1spsyP66iw";
        }

        private void GetLocations()
        {
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            _mapWrapper.DeleteOldPins();
            _mapWrapper.AddNewPins(_myVehicles);
        } 

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            if (PhoneApplicationService.Current.State.ContainsKey("myVehicles"))
            {
                _myVehicles = (IDictionary<string, VehicleType>)PhoneApplicationService.Current.State["myVehicles"];
            }

            base.OnNavigatedTo(e);
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            if ((e.Orientation & PageOrientation.Landscape) == PageOrientation.Landscape)
            {
                NavigationService.Navigate(new Uri("/View/Portrait/Landscape/MapView.xaml", UriKind.Relative));
            }
            
            base.OnOrientationChanged(e);
        }

        private void AddVehicleToMap_Tap(object sender, GestureEventArgs e)
        {
            if (!String.IsNullOrEmpty(VehicleNameTextBox.Text))
            {
                var vehicle = VehicleNameTextBox.Text;

                if (_vehicleProvider.GetAvailableVehicles().ContainsKey(vehicle) && !_myVehicles.ContainsKey(vehicle))
                {
                    VehicleType vehilceType;
                    _vehicleProvider.GetAvailableVehicles().TryGetValue(vehicle, out vehilceType);
                    _myVehicles.Add(new KeyValuePair<string, VehicleType>(vehicle, vehilceType));
                }
                
            }
            else
            {
                MessageBox.Show("Please type a valid value");
            }
        }
    }
}