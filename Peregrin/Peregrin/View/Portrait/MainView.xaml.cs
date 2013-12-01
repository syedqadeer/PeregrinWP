using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Peregrin.View.Portrait
{
    public partial class MainView : PhoneApplicationPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectCityOnChange(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Panorama/VehiclesView.xaml", UriKind.Relative));
        }
    }
}