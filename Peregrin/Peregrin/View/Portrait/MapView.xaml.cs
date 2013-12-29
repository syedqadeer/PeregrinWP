using Microsoft.Phone.Controls;
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
namespace Peregrin.View.Portrait
{
    public partial class MapView : PhoneApplicationPage
    {
        private List<string> myVehicles;

        public MapView()
        {
            InitializeComponent();
            GetLocations();            
        }

        private void Map_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            MapsSettings.ApplicationContext.ApplicationId = "f5f04dbf-5ac1-46d5-8070-514c9153971d";
            MapsSettings.ApplicationContext.AuthenticationToken = "rPOvHDgmcJ_v1spsyP66iw";
        }

        private void GetLocations()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            if (PhoneApplicationService.Current.State.ContainsKey("myVehicles"))
            {
                myVehicles = (List<string>)PhoneApplicationService.Current.State["myVehicles"];
            }

            base.OnNavigatedTo(e);
        }

        private void timer_tick(object sender, EventArgs e)
        {
            
        }      

    }
}