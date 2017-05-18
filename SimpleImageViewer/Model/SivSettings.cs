using System.Windows.Input;
using System.Windows.Media;

namespace SimpleImageViewer.Model {

    public class SivSettings {

        public static string KEY_NEXT = "KEY_NEXT";
        public static string KEY_BACK = "KEY_BACK";

        public static string KEY_OPENIMAGE = "KEY_OPENIMAGE";
        public static string KEY_EXPLOREFOLDER = "KEY_EXPLOREFOLDER";
        public static string KEY_SETTINGS = "KEY_SETTINGS";
        public static string KEY_ABOUT = "KEY_ABOUT";

        public Key KeyOpenImage { get; set; }
        public Key KeyExploreFolder { get; set; }

        public Key KeyNext { get; set; }
        public Key KeyBack { get; set; }

        public Key KeyNextAlt { get; set; }
        public Key KeyBackAlt { get; set; }

        public Key KeySettings { get; set; }
        public Key KeyAbout { get; set; }

        public bool StretchImage { get; set; }

        public SivSettings() {
            ApplyDefaultSettings();
        }

        public void ApplyDefaultSettings() {
            KeyNext = Key.Right;
            KeyBack = Key.Left;
            KeyNextAlt = Key.L;
            KeyBackAlt = Key.J;
            KeyOpenImage = Key.O;
            KeyExploreFolder = Key.E;
            KeySettings = Key.Escape;
            KeyAbout = Key.F1;
            StretchImage = true;
        }

    }

}
