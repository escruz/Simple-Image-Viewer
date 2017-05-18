using SimpleImageViewer.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleImageViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private void Application_Startup(object sender, StartupEventArgs e) {
            ImageViewerWindow wnd = new ImageViewerWindow();
            if (e.Args.Length == 1)
                wnd.ImageViewer.OpenFile(e.Args[0]);
            wnd.Show();
        }

    }
}
