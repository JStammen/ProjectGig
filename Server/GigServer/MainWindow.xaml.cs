using OpenSource.UPnP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GigServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DMSServerDevice device;
        public static MainWindow instance;

        public MainWindow()
        {
            instance = this;

            Console.WriteLine("---------------------UPnP Device---------------------");
            device = new DMSServerDevice();
            device.Start();
            Console.WriteLine("Starting up... " + device.GetFriendlyName() + " : " + device.GetModelName() + " ...Done!");

            Thread indexer = new Thread(new ThreadStart(device.CH.IndexDirs));
            indexer.Start();

            InitializeComponent();
            TestLabel.Content = device.GetFriendlyName();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Stopping server...");
            device.Stop();
            Environment.Exit(0);
        }
    }
}
