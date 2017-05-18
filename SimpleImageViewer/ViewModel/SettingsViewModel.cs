using SimpleImageViewer.Commands;
using SimpleImageViewer.Model;
using System.Windows.Input;
using System.Windows.Media;

namespace SimpleImageViewer.ViewModel {

    public class SettingsViewModel : ViewModelBase {

        public SivSettings Settings { get; set; }

        public SettingsViewModel() {
            Settings = new SivSettings();
        }

    }

}
