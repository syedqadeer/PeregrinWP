using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Peregrin.Services.Model;
using Peregrin.Data;


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
            var selectedItem = sender as ListBox;

            if (selectedItem.SelectedItem != null)
            {
                var city = (City)selectedItem.SelectedItem;
                NavigationService.Navigate(new Uri("/View/Panorama/VehiclesView.xaml?city=" + city.Name, UriKind.Relative));
            }
        }


    }
}