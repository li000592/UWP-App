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
    public sealed partial class VideoPage : Page
    {
        public VideoPage()
        {
            this.InitializeComponent();
        }


        private async void videoButton_Click(object sender, RoutedEventArgs e)
        {
            var fileOpenPicker = new Windows.Storage.Pickers.FileOpenPicker
            {
                ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail,
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary,
                FileTypeFilter = { ".mp4", ".mpg", ".wmv", ".avi" }
            };

            Windows.Storage.StorageFile file = await fileOpenPicker.PickSingleFileAsync();

            if (file != null) // file is null if user cancels
            {
                theMediaElement.AreTransportControlsEnabled = true;
                Windows.Storage.Streams.IRandomAccessStream fileSteam = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);

                theMediaElement.SetSource(fileSteam, file.ContentType);

            }
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
