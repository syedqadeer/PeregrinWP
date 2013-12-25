using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Peregrin.Services.Model;
namespace Peregrin.View.Portrait
{
    public partial class MainView : PhoneApplicationPage
    {
        public MainView()
        {
            InitializeComponent();
            CityListbox.DataContext = SupportedCities.GetSupportedCities();
        }

        private void ListBox_SelectCityOnChange(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/Panorama/VehiclesView.xaml", UriKind.Relative));
        }
    }
}