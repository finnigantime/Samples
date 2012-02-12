using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MinimizedAppBarWithFadeInOutEffect
{
    public partial class MainPage : PhoneApplicationPage
    {
        static double AppBarSemitransparentOpacity = 0.45;

        public double AppBarOpacity
        {
            get { return (double)GetValue(AppBarOpacityProperty); }
            set { SetValue(AppBarOpacityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AppBarOpacity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AppBarOpacityProperty =
            DependencyProperty.Register("AppBarOpacity", typeof(double), typeof(MainPage), new PropertyMetadata(AppBarSemitransparentOpacity,
                new PropertyChangedCallback((o, a) => ((MainPage)o).ApplicationBar.Opacity = (double)a.NewValue )));

        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ApplicationBar_StateChanged(object sender, Microsoft.Phone.Shell.ApplicationBarStateChangedEventArgs e)
        {
            var appBar = sender as ApplicationBar;
            Storyboard storyboard = e.IsMenuVisible ? (Storyboard)Resources["AppBarFadeInStoryboard"] : (Storyboard)Resources["AppBarFadeOutStoryboard"];
            storyboard.Begin();
        }
    }
}