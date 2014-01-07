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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SettingsFlyout_AnimateOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Windows.UI.ApplicationSettings.SettingsPane.GetForCurrentView().CommandsRequested += MainPage_CommandsRequested;
        }


    void MainPage_CommandsRequested(Windows.UI.ApplicationSettings.SettingsPane sender, Windows.UI.ApplicationSettings.SettingsPaneCommandsRequestedEventArgs args)
    {
        Windows.UI.ApplicationSettings.SettingsCommand updateSetting = 
            new Windows.UI.ApplicationSettings.SettingsCommand("AppUpdateSettings", "App updates", (handler) =>
        {
            SettingsFlyout1 updatesFlyout = new SettingsFlyout1();
            updatesFlyout.ShowCustom();

        });

        args.Request.ApplicationCommands.Add(updateSetting);
    }

    }
}
