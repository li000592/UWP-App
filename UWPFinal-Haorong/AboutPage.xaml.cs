using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPFinal_Haorong
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();

            versionLabel.Text += GetAppVersion();
        }

        private async void webLinkButton_Click(object sender, RoutedEventArgs e)
        {
            Uri weblink = new Uri("https://github.com/li000592");
            await Windows.System.Launcher.LaunchUriAsync(weblink);
        }

        private async void emailLinkButton_Click(object sender, RoutedEventArgs e)
        {
            Uri emaillink = new Uri("mailto:li000592@algonquinlive.com");
            await Windows.System.Launcher.LaunchUriAsync(emaillink);
        }
        public string GetAppVersion()
        {
            var package = Windows.ApplicationModel.Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;
            return $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        #region Navigation To and From with Back Button

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var currentView = Windows.UI.Core.SystemNavigationManager.GetForCurrentView();

            currentView.AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Visible;

            currentView.BackRequested += backButton_Tapped;

            base.OnNavigatedTo(e);
        }

        private void backButton_Tapped(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true; // tells the OS we handled the back button event (must add so we can also support devices with physical/hardware back buttons)
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            var currentView = Windows.UI.Core.SystemNavigationManager.GetForCurrentView();

            currentView.AppViewBackButtonVisibility = Windows.UI.Core.AppViewBackButtonVisibility.Collapsed;

            currentView.BackRequested -= backButton_Tapped;

            base.OnNavigatedFrom(e);
        }

        #endregion
    }
}
