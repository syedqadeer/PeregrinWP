using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Peregrin.Resources;
using System.Windows.Controls;
using Peregrin.Services.Providers;
using Peregrin.Common.Enum;
using System.Collections.Generic;
using Microsoft.Phone.Reactive;

namespace Peregrin.View.Panorama
{
    public partial class VehiclesView : PhoneApplicationPage
    {
        private readonly WroclawVehicleProvider _provider;
        private readonly IObservable<KeyValuePair<string, VehicleType>> _buses;
        private readonly IObservable<KeyValuePair<string, VehicleType>> _trams;
        private IDictionary<string, VehicleType> _myVehicles;

        public VehiclesView()
        {            
            InitializeComponent();
            _provider = new WroclawVehicleProvider();
            _myVehicles = new Dictionary<string, VehicleType>();

            _buses = _provider.GetAvailableVehicles(VehicleType.Bus).ToObservable();
            _trams = _provider.GetAvailableVehicles(VehicleType.Tram).ToObservable();
            BusListBox.ItemsSource = _buses.ToEnumerable();
            TramListBox.ItemsSource = _trams.ToEnumerable();
        }

        private void PinVehicle_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;

            if (menuItem != null)
            {
                var vehiclePin = (KeyValuePair<string, VehicleType>) menuItem.DataContext;


                var shellTile =
                    ShellTile.ActiveTiles.FirstOrDefault(
                        x => x.NavigationUri.ToString().Contains("MapView.xaml?vehicle=" + vehiclePin.Key));

                var liveTile = new StandardTileData
                {
                    Title = vehiclePin.Key
                };

                if (shellTile != null)
                {
                    MessageBox.Show(AppResources.TileIsAlreadyExist);
                }
                else
                {
                    ShellTile.Create(
                        new Uri("/View/Portrait/MapView.xaml?vehicle=" + vehiclePin.Key, UriKind.Relative), liveTile);
                }
            }
        }

        private void BusTextBoxFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var filterContext = sender as TextBox;

            if (filterContext.Text != null)
            {
                var name = filterContext.Text;
                BusListBox.ItemsSource = _buses.Where(x => x.Key.Contains(name)).ToEnumerable();
            }
        }

        private void TramTextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filterContext = sender as TextBox;

            if (filterContext.Text != null)
            {
                var name = filterContext.Text;
                TramListBox.ItemsSource = _trams.Where(x => x.Key.Contains(name)).ToEnumerable();

            }
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;

            if (item.Content != null)
            {
                var vehicle = (KeyValuePair<string, VehicleType>)item.DataContext;

                if (!_myVehicles.Keys.Contains(vehicle.Key))
                {
                    _myVehicles.Add(vehicle);
                    var temp = _myVehicles.ToObservable();
                    MyVehiclesListBox.ItemsSource = temp.ToEnumerable();
                }
            }
        }

        private void DeleteFromList_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;

            if (item.Content != null)
            {
                var vehicle = (KeyValuePair<string, VehicleType>)item.DataContext;

                _myVehicles.Remove(vehicle.Key);
                var temp = _myVehicles.ToObservable();
                MyVehiclesListBox.ItemsSource = temp.ToEnumerable();
            }
        }

        private void NavigateToMap_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneApplicationService.Current.State.ContainsKey("myVehicles"))
            {
                PhoneApplicationService.Current.State["myVehicles"] = new Dictionary<string, VehicleType>();
                PhoneApplicationService.Current.State["myVehicles"] = _myVehicles;
            }
            NavigationService.Navigate(new Uri("/View/Portrait/MapView.xaml?", UriKind.Relative));            
        }
    }
}