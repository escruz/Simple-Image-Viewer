using Microsoft.Win32;
using SimpleImageViewer.Commands;
using SimpleImageViewer.Model;
using System;
using System.IO;
using System.Windows.Input;
using SimpleImageViewer.Utilities;
using System.Diagnostics;
using SimpleImageViewer.View;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SimpleImageViewer.ViewModel {

    public class ImageViewerViewModel : ViewModelBase {
        
        public ImageGallery Gallery { get; set; }
        public SivSettings Settings { get; set; }

        BitmapImage m_CurrentImage;
        public BitmapImage CurrentImage {
            get {
                return m_CurrentImage;
            }
            set {
                m_CurrentImage = value;
                OnPropertyChanged("CurrentImage");
            }
        }

        string m_CurrentFile;
        public string CurrentFile {
            get {
                return m_CurrentFile;             
            }
            set {
                m_CurrentFile = value;
                CreateBitmapImage();
                OnPropertyChanged("CurrentFile");
            }
        }

        void CreateBitmapImage()
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(m_CurrentFile);
            image.EndInit();
            CurrentImage = image;
        }

        string m_CurrentDirectory;
        public string CurrentDirectory {
            get {
                return m_CurrentDirectory;
            }
            set {
                m_CurrentDirectory = value;
                OnPropertyChanged("CurrentDirectory");
            }
        }

        ICommand m_OpenFileCommand;
        public ICommand OpenFileCommand {
            get {
                if (m_OpenFileCommand == null) {
                    m_OpenFileCommand = new RelayCommand(
                        param => this.OpenFile()
                        );
                }
                return m_OpenFileCommand;
            }
        }

        ICommand m_OpenExplorerCommand;
        public ICommand OpenExplorerCommand {
            get {
                if (m_OpenExplorerCommand == null) {
                    m_OpenExplorerCommand = new RelayCommand(
                        param => this.OpenExplorer(),
                        canExecute => this.DirectoryExists()
                        );
                }
                return m_OpenExplorerCommand;
            }
        }

        ICommand m_BackFileCommand;
        public ICommand BackFileCommand {
            get {
                if (m_BackFileCommand == null) {
                    m_BackFileCommand = new RelayCommand(
                        param => this.BackFile(),
                        canExecute => this.DirectoryExists()
                        );
                }
                return m_BackFileCommand;
            }
        }

        ICommand m_NextFileCommand;
        public ICommand NextFileCommand {
            get {
                if (m_NextFileCommand == null) {
                    m_NextFileCommand = new RelayCommand(
                        param => this.NextFile(),
                        canExecute => this.DirectoryExists()
                        );
                }
                return m_NextFileCommand;
            }
        }

        ICommand m_SettingsCommand;
        public ICommand SettingsCommand {
            get {
                if (m_SettingsCommand == null) {
                    m_SettingsCommand = new RelayCommand(
                        param => this.OpenSettings()
                        );
                }
                return m_SettingsCommand;
            }
        }

        ICommand m_AboutCommand;
        public ICommand AboutCommand {
            get {
                if (m_AboutCommand == null) {
                    m_AboutCommand = new RelayCommand(
                        param => this.OpenAbout()
                        );
                }
                return m_AboutCommand;
            }
        }

        ICommand m_StretchCommand;
        public ICommand StretchCommand {
            get {
                if (m_StretchCommand == null)
                {
                    m_StretchCommand = new RelayCommand(
                        param => this.BackFile(),
                        canExecute => this.DirectoryExists()
                        );
                }
                return m_StretchCommand;
            }
        }

        /// <summary>
        /// Image Viewer Constructor
        /// </summary>
        public ImageViewerViewModel() {
            Gallery = new ImageGallery();
            Settings = new SivSettings();
        }

        public bool DirectoryExists() {
            if (!Directory.Exists(CurrentDirectory)) {
                return false;
            }
            return true;
        }

        public void OpenFile() {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = SivConstants.SupportedFileTypes;

            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true) {
                CurrentFile = dlg.FileName;
                CurrentDirectory = Path.GetDirectoryName(CurrentFile);
                Gallery.PopulateFiles( CurrentFile, CurrentDirectory );
            }
        }

        public void OpenFile( string file ) {
            if (File.Exists(file)) {
                CurrentFile = file;
                CurrentDirectory = Path.GetDirectoryName(CurrentFile);
                Gallery.PopulateFiles(CurrentFile, CurrentDirectory);
            }
        }

        public void OpenExplorer() {
            Process.Start(CurrentDirectory);
        }

        public void BackFile() {
            Gallery.BackFile();
            CurrentFile = Gallery.GetCurrentFile();
        }

        public void NextFile() {
            Gallery.NextFile();
            CurrentFile = Gallery.GetCurrentFile();
        }

        public void StretchImage()
        {

        }

        public void OpenSettings() {
            SettingsWindow dlg = new SettingsWindow();
            dlg.Owner = Application.Current.MainWindow;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true) {

            }
        }

        public void OpenAbout() {
            AboutWindow dlg = new AboutWindow();
            dlg.Owner = Application.Current.MainWindow;
            dlg.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {

            }
        }

    }

}
