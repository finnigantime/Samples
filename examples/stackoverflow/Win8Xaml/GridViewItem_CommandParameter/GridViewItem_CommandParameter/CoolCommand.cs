using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace GridViewItem_CommandParameter
{
    class CoolCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Popup p = new Popup();
            p.IsLightDismissEnabled = true;
            p.HorizontalOffset = 200;
            p.VerticalOffset = 300;

            Border b = new Border();
            b.Padding = new Thickness(50);
            b.BorderBrush = new SolidColorBrush(Colors.Black);
            b.BorderThickness = new Thickness(2);
            b.Background = new SolidColorBrush(Colors.White);

            TextBlock tb = new TextBlock();
            tb.Text = "CommandParameter: " + parameter;
            tb.Foreground = new SolidColorBrush(Colors.Black);

            b.Child = tb;
            p.Child = b;
            p.IsOpen = true;
        }
    }
}
