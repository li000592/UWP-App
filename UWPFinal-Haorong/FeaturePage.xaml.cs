using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
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
    public sealed partial class FeaturePage : Page
    {
        public FeaturePage()
        {
            this.InitializeComponent();

            // Set supported inking device types.
            inkCanvas.InkPresenter.InputDeviceTypes =
                Windows.UI.Core.CoreInputDeviceTypes.Mouse |
                Windows.UI.Core.CoreInputDeviceTypes.Pen;

            // Set initial ink stroke attributes.
            InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
            drawingAttributes.Color = Windows.UI.Colors.Black;
            drawingAttributes.IgnorePressure = false;
            drawingAttributes.FitToCurve = true;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        }
        private void OnPenColorChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inkCanvas != null)
            {
                InkDrawingAttributes drawingAttributes =
                    inkCanvas.InkPresenter.CopyDefaultDrawingAttributes();

                string value = ((ComboBoxItem)PenColor.SelectedItem).Content.ToString();

                switch (value)
                {
                    case "Black":
                        drawingAttributes.Color = Windows.UI.Colors.Black;
                        break;
                    case "Red":
                        drawingAttributes.Color = Windows.UI.Colors.Red;
                        break;
                    default:
                        drawingAttributes.Color = Windows.UI.Colors.Black;
                        break;
                };

                inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
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
