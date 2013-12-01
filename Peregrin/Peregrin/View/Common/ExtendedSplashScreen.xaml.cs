using System;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Threading.Tasks;

namespace Peregrin.View.Common
{
    public partial class ExtendedSplashScreen : PhoneApplicationPage
    {
        public ExtendedSplashScreen()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NavigateToMenu();

            base.OnNavigatedTo(e);
        }

        private async void NavigateToMenu()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            NavigationService.Navigate(new Uri("/View/Portrait/MainView.xaml", UriKind.Relative));
        }
    }
}