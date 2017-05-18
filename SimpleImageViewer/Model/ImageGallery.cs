using SimpleImageViewer.Utilities;
using System.IO;
using System.Linq;

namespace SimpleImageViewer.Model {

    public class ImageGallery {

        public string CurrentFileName { get; set; }
        public string CurrentDirectory { get; set; }
        public int CurrentFileIndex { get; set; }

        public string[] Files { get; set; }

        public string GetCurrentFile() {
            return Files[CurrentFileIndex];
        }

        void AssignFilesInDirectory() {
            var dirfiles = Directory.GetFiles(CurrentDirectory).Where(s => SivConstants.SuppportedExtensions.Contains(Path.GetExtension(s).ToLower()));
            Files = dirfiles.ToArray();
        }

        public void PopulateFiles( string filename, string directory ) {
            CurrentFileName = filename;
            CurrentDirectory = directory;
            AssignFilesInDirectory();
            for (int i = 0; i<Files.Length; i++) {
                if (Files[i].Equals(CurrentFileName, System.StringComparison.OrdinalIgnoreCase)) {
                    CurrentFileIndex = i;
                    return;
                }
            }
        }

        public void RepopulateFiles() {
            AssignFilesInDirectory();
            if (CurrentFileIndex >= Files.Length - 1) {
                CurrentFileIndex = 0;
            } else if (CurrentFileIndex < 0) {
                CurrentFileIndex = Files.Length - 1;
            }
        }

        public void BackFile() {
            if (CurrentFileIndex<=0) {
                CurrentFileIndex = Files.Length - 1;
            } else {
                CurrentFileIndex--;
            }
            if (!File.Exists(Files[CurrentFileIndex])) {
                RepopulateFiles();
            }
        }

        public void NextFile() {
            if (CurrentFileIndex >= Files.Length - 1) {
                CurrentFileIndex = 0;
            } else {
                CurrentFileIndex++;
            }
            
            if (!File.Exists(Files[CurrentFileIndex])) {
                RepopulateFiles();
            }
        }

    }

}
