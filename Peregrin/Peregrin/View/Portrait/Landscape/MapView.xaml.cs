using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps;
using Microsoft.Phone.Shell;
using Peregrin.Common.Enum;
using Peregrin.Services.Wrappers;

namespace Peregrin.View.Portrait.Landscape
{
    public partial class MapView : PhoneApplicationPage
    {
        private IDictionary<string, VehicleType> _myVehicles;
        private readonly IMapWrapper _mapWrapper;

        public MapView()
        {
            InitializeComponent();
            _mapWrapper = new MapWrapper(LandscapeMap);
            GetLocations();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (PhoneApplicationService.Current.State.ContainsKey("myVehicles"))
            {
                _myVehicles = (IDictionary<string,VehicleType>)PhoneApplicationService.Current.State["myVehicles"];
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            var lastPage = NavigationService.BackStack.FirstOrDefault();

            if (lastPage != null && lastPage.Source.ToString().Contains("MapView.xaml"))
            {
                NavigationService.Navigate(new Uri("/View/Portrait/MainView.xaml", UriKind.Relative));
            }

            base.OnBackKeyPress(e);
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            if ((e.Orientation & PageOrientation.Portrait) == PageOrientation.Portrait)
            {
                NavigationService.Navigate(new Uri("/View/Portrait/MapView.xaml", UriKind.Relative));
            }

            base.OnOrientationChanged(e);
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

        private void LandscapeMap_OnLoaded(object sender, RoutedEventArgs e)
        {
            MapsSettings.ApplicationContext.ApplicationId = "f5f04dbf-5ac1-46d5-8070-514c9153971d";
            MapsSettings.ApplicationContext.AuthenticationToken = "rPOvHDgmcJ_v1spsyP66iw";

        }

    }
}