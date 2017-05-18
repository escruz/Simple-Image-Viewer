using SimpleImageViewer.ViewModel;
using System.Windows;

namespace SimpleImageViewer.View {
    
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window {

        SettingsViewModel m_SettingsViewModel;

        public SettingsWindow() {
            InitializeComponent();            
            m_SettingsViewModel = new SettingsViewModel();
            this.DataContext = m_SettingsViewModel;            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            DialogResult = false;
            this.Close();
        }
    }
}
