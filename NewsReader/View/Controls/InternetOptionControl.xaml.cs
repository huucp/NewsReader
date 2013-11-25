using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace NewsReader.View.Controls
{
    public partial class InternetOptionControl : UserControl
    {
        public InternetOptionControl()
        {
            InitializeComponent();
        }

        private void CellularButton_OnClick(object sender, RoutedEventArgs e)
        {
            var connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.Cellular;
            connectionSettingsTask.Show();
        }

        private void WifiButton_OnClick(object sender, RoutedEventArgs e)
        {
            var connectionSettingsTask = new ConnectionSettingsTask();
            connectionSettingsTask.ConnectionSettingsType = ConnectionSettingsType.WiFi;
            connectionSettingsTask.Show();
        }
    }
}
