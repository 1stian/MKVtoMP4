using MahApps.Metro.Controls;
using Microsoft.Win32;
using MKVtoMP4.Functions;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System;
using WPFFolderBrowser;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using System.Linq;
using System.Collections;

namespace MKVtoMP4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
        public static readonly string MTP_PATH = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
#pragma warning restore CA1707 // Identifiers should not contain underscores

        public MainWindow()
        {           
            InitializeComponent();
            // Create directories
            AppPaths.CreateDirectories();
            // Save ffmpeg files
            SaveFfmpeg();
        }

        private void SaveFfmpeg()
        {
            string ffmpeg = Path.Combine(AppPaths.GetFFmpeg(), "ffmpeg.exe");
            if (!File.Exists(ffmpeg) || new FileInfo(ffmpeg).Length != 79353358)
            {
                File.WriteAllBytes(ffmpeg, Properties.Resources.ffmpeg);
            }

            string ffprobe = Path.Combine(AppPaths.GetFFmpeg(), "ffprobe.exe");
            if (!File.Exists(ffprobe) || new FileInfo(ffprobe).Length != 79249422)
            {
                File.WriteAllBytes(ffprobe, Properties.Resources.ffprobe);
            }
        }

        private void OpenGithub(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/1stian/MKVtoMP4");
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
        private void BrowseSource(object sender, RoutedEventArgs e)
        {
            var dirDialog = new WPFFolderBrowserDialog();
            if (dirDialog.ShowDialog() == true)
            {
                sourceDirectory.Text = dirDialog.FileName;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>")]
        private void BrowseDesti(object sender, RoutedEventArgs e)
        {
            var dirDialog = new WPFFolderBrowserDialog();
            if (dirDialog.ShowDialog() == true)
            {
                destDirectory.Text = dirDialog.FileName;
            }
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            if (itemProgress.IsIndeterminate)
            {
                if (MessageBox.Show("MKVtoMP4 is currently doing work.. You sure you want to exit?", "Wait!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private static async Task RunConverter(string input)
        {
            //Queue filesToConvert = new Queue(GetFilesToConvert());
            //await Console.Out.WriteLineAsync($"Find {filesToConvert.Count()} files to convert.");
        }

        private static IEnumerable GetFilesToConvert(string directoryPath)
        {
            //Return all files excluding mp4 because I want convert it to mp4
            return new DirectoryInfo(directoryPath).GetFiles().Where(x => x.Extension != ".mp4");
        }

        private void sourceDirectory_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
