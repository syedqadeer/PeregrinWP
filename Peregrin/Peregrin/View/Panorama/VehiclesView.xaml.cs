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
        private readonly IObservable<string> _buses;
        private readonly IObservable<string> _trams;

        public VehiclesView()
        { 
            InitializeComponent();
            _provider = new WroclawVehicleProvider();
            _buses = _provider.GetAvailableVehicles(VehicleType.Bus).ToObservable();
            _trams = _provider.GetAvailableVehicles(VehicleType.Tram).ToObservable();
            BusListBox.ItemsSource = _buses.ToEnumerable();
            TramListBox.ItemsSource = _trams.ToEnumerable();
        }

        private void PinVehicle_Click(object sender, RoutedEventArgs e)
        {
            
            var shellTile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("?id="));

            var liveTile = new StandardTileData
            {
                Title = "126"               
            };

            if (shellTile != null)
            {
                MessageBox.Show(AppResources.TileIsAlreadyExist);
            }
            else
            {
                ShellTile.Create(new Uri("/View/Portrait/MapView.xaml", UriKind.Relative), liveTile);
            }
        }

        private void BusTextBoxFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var filterContext = sender as TextBox;

            if (filterContext.Text != null)
            {
                var name = filterContext.Text;
                BusListBox.ItemsSource = _buses.Where(x=>x.Contains(name)).ToEnumerable();
            }
        }

        private void TramTextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
             var filterContext = sender as TextBox;

             if (filterContext.Text != null)
             {
                 var name = filterContext.Text;
                 TramListBox.ItemsSource = _trams.Where(x => x.Contains(name)).ToEnumerable();

             }
        }
    }
}