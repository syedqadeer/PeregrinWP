using Microsoft.Phone.Controls;
using Nokia.Phone.HereLaunchers;
using System.Device.Location;

namespace Peregrin.View.Portrait
{
    public partial class MapView : PhoneApplicationPage
    {
        public MapView()
        {
            InitializeComponent();
            InitializeHereMap();
        }


        private void InitializeHereMap()
        {
            ExploremapsShowMapTask mapTask = new ExploremapsShowMapTask();
            mapTask.Location = new GeoCoordinate(51.0636, 17.0120);
            mapTask.Zoom = 10;
            mapTask.Show();

        }
    }
}