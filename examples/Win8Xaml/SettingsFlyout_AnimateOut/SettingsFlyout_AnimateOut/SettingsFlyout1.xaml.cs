using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace SettingsFlyout_AnimateOut
{
    public sealed partial class SettingsFlyout1 : SettingsFlyout
    {
        Popup _p;
        Border _b;
        
        public SettingsFlyout1()
        {
            this.InitializeComponent();

            BackClick += SettingsFlyout1_BackClick;
            Unloaded += SettingsFlyout1_Unloaded;
            Tapped += SettingsFlyout1_Tapped;
        }

        void SettingsFlyout1_BackClick(object sender, BackClickEventArgs e)
        {
            _b.Child = null;
            SettingsPane.Show();
        }

        void SettingsFlyout1_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_p != null)
            {
                _p.IsOpen = false;
            }
        }

        void SettingsFlyout1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            e.Handled = true;
        }

        public void ShowCustom()
        {
            _p = new Popup();
            _b = new Border();

            _b.ChildTransitions = new TransitionCollection();

            // TODO: if you support right-to-left builds, make sure to test all combinations of RTL operating
            // system build (charms on left) and RTL flow direction for XAML app.  EdgeTransitionLocation.Left
            // may need to be used for RTL (and HorizontalAlignment.Left on the SettingsFlyout below).
            _b.ChildTransitions.Add(new EdgeUIThemeTransition() { Edge = EdgeTransitionLocation.Right });

            _b.Background = new SolidColorBrush(Colors.Transparent);
            _b.Width = Window.Current.Bounds.Width;
            _b.Height = Window.Current.Bounds.Height;
            _b.Tapped += b_Tapped;

            this.HorizontalAlignment = HorizontalAlignment.Right;
            _b.Child = this;

            _p.Child = _b;
            _p.IsOpen = true;
        }

        void b_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Border b = (Border)sender;
            b.Child = null;
        }
    }
}
