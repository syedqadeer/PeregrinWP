using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Peregrin.Resources;

namespace Peregrin.View.Panorama
{
    public partial class VehiclesView : PhoneApplicationPage
    {
        public VehiclesView()
        {
            InitializeComponent();
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
    }
}