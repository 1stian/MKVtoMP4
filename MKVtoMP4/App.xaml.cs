using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace MKVtoMP4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var requiredDllName = $"{(new AssemblyName(args.Name).Name)}.dll";
            var resourse = currentAssembly.GetManifestResourceNames().Where(s => s.EndsWith(requiredDllName)).FirstOrDefault();

            if (resourse != null)
            {
                using (var stream = currentAssembly.GetManifestResourceStream(resourse))
                {
                    if (stream == null)
                    {
                        return null;
                    }

                    var block = new byte[stream.Length];
                    stream.Read(block, 0, block.Length);
                    return Assembly.Load(block);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
