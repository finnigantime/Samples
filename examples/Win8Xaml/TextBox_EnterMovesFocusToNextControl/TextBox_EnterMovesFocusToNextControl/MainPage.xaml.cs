using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TextBox_EnterMovesFocusToNextControl
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

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TextBox tbSender = (TextBox)sender;

            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                // Get the next TextBox and focus it.

                DependencyObject nextSibling = GetNextSiblingInVisualTree(tbSender);
                if (nextSibling is Control)
                {
                    // Transfer "keyboard" focus to the target element.
                    ((Control)nextSibling).Focus(FocusState.Keyboard);
                }
            }
        }

        private static DependencyObject GetNextSiblingInVisualTree(DependencyObject origin)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(origin);

            if (parent != null)
            {
                int childIndex = -1;

                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); ++i)
                {
                    if (origin == VisualTreeHelper.GetChild(parent, i))
                    {
                        childIndex = i;
                        break;
                    }
                }

                Debug.Assert(childIndex != -1);

                int nextIndex = childIndex + 1;
                if (nextIndex < VisualTreeHelper.GetChildrenCount(parent))
                {
                    return VisualTreeHelper.GetChild(parent, nextIndex);
                }
            }

            return null;
        }
    }
}
