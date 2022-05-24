using EasyLogger;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace WpfMnpDemoApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Log Logger { get; set; }
        public MainWindow() {
            Logger = Log.Get<MainWindow>();
            Logger.Info(">>>>> Program Starts >>>>>");

            InitializeComponent();

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;

            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages) {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.NativeName; // DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }
        }
        private void LanguageChanged(Object sender, EventArgs e) {
            CultureInfo currLang = App.Language;
            //var nativeLangNameUtf8 = Encoding.UTF8.GetString(Encoding.Default.GetBytes(currLang.NativeName));
            //Logger.Info("Application language was changed to " + nativeLangNameUtf8);
            Logger.Info("Changed to " + currLang.NativeName);

            // Checks the current selected language
            foreach (MenuItem i in menuLanguage.Items) {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e) {
            MenuItem mi = sender as MenuItem;
            if (mi != null) {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null) {
                    App.Language = lang;
                }
            }

        }
    }
}
