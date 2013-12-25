using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Peregrin.Resources;
using System.Windows.Controls;

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

        private void BusTextBoxFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var filterContext = sender as TextBox;

            if (filterContext.Text != null)
            {

            }
        }
    }
}