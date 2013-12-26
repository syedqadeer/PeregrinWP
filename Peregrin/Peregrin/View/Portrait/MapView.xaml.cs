using Microsoft.Phone.Controls;
using Nokia.Phone.HereLaunchers;
using System.Device.Location;
using Microsoft.Phone.Maps;

namespace Peregrin.View.Portrait
{
    public partial class MapView : PhoneApplicationPage
    {
        public MapView()
        {
            InitializeComponent();            
        }

        private void Map_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            MapsSettings.ApplicationContext.ApplicationId = "f5f04dbf-5ac1-46d5-8070-514c9153971d";
            MapsSettings.ApplicationContext.AuthenticationToken = "rPOvHDgmcJ_v1spsyP66iw";
        }
    }
}