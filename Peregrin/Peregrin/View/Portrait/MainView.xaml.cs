using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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