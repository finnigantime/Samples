using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Shell;

namespace MinimizedAppBarWithFadeInOutEffect
{
    public class AppBarWrapper : DependencyObject
    {
        public double Opacity
        {
            get { return (double)GetValue(OpacityProperty); }
            set { SetValue(OpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Opacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register("Opacity", typeof(double), typeof(AppBarWrapper),
                new PropertyMetadata(App.Current.Resources["AppBarSemitransparentOpacity"],
                    new PropertyChangedCallback((o, a) => ((ApplicationBar)App.Current.Resources["MyAppBar"]).Opacity = (double)a.NewValue )));
    }
}
