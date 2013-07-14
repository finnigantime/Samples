using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App8
{
    public sealed partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            this.InitializeComponent();


            List<string> foo = new List<string>();
            for (int i = 0; i < 100; ++i)
            {
                foo.Add("item" + i);
            }
            gridBodyListView.ItemsSource = foo;
        }
    }
}
