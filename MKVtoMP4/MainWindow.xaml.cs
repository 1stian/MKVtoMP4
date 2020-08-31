using MahApps.Metro.Controls;
using Microsoft.Win32;
using MKVtoMP4.Functions;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace MKVtoMP4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static readonly string MTP_PATH = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

        public MainWindow()
        {           
            InitializeComponent();
            AppPaths.CreateDirectories();
        }

        private void OpenGithub(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/1stian/MKVtoMP4");
        }

        private void BrowseSource(object sender, RoutedEventArgs e)
        {
            
        }

        private void BrowseDesti(object sender, RoutedEventArgs e)
        {

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
        }
    }
}
