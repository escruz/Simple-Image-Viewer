using SimpleImageViewer.ViewModel;
using System.Windows;

namespace SimpleImageViewer.View {

    public partial class ImageViewerWindow : Window {

        ImageViewerViewModel m_ImageViewerViewModel;
        public ImageViewerViewModel ImageViewer {
            get { return m_ImageViewerViewModel; }
        }

        public ImageViewerWindow() {
            InitializeComponent();
            this.Top = Properties.Settings.Default.Top;
            this.Left = Properties.Settings.Default.Left;
            this.Height = Properties.Settings.Default.Height;
            this.Width = Properties.Settings.Default.Width;
            if (Properties.Settings.Default.Maximized) {
                WindowState = WindowState.Maximized;
            }
            m_ImageViewerViewModel = new ImageViewerViewModel();
            this.DataContext = m_ImageViewerViewModel;
        }

        public ImageViewerWindow( string file ) {
            InitializeComponent();
            m_ImageViewerViewModel = new ImageViewerViewModel();
            this.DataContext = m_ImageViewerViewModel;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (WindowState == WindowState.Maximized) {
                Properties.Settings.Default.Top = RestoreBounds.Top;
                Properties.Settings.Default.Left = RestoreBounds.Left;
                Properties.Settings.Default.Height = RestoreBounds.Height;
                Properties.Settings.Default.Width = RestoreBounds.Width;
                Properties.Settings.Default.Maximized = true;
            } else {
                Properties.Settings.Default.Top = this.Top;
                Properties.Settings.Default.Left = this.Left;
                Properties.Settings.Default.Height = this.Height;
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Maximized = false;
            }

            Properties.Settings.Default.Save();
        }
    }
}
