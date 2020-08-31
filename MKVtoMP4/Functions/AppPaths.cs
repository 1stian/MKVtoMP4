using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKVtoMP4.Functions
{
    class AppPaths
    {
        public static class FolderName
        {
            public static string Ffmpeg = "ffmpeg";
        }

        public static void CreateDirectories()
        {
            Directory.CreateDirectory(Get(FolderName.Ffmpeg));
        }

        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <param name="path3"></param>
        /// <returns></returns>
        public static string Get(string path1 = "", string path2 = "", string path3 = "")
        {
            return Path.Combine(MainWindow.MTP_PATH, path1, path2, path3);
        }
    }
}
