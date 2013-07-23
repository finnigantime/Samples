using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App6
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            rect.Fill = new SolidColorBrush(Colors.Aqua);
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            rect.Fill = new SolidColorBrush(Colors.Beige);
        }

        private void UserControl_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            ((UserControl)sender).Focus(FocusState.Pointer);
            e.Handled = true;
        }
    }
}
