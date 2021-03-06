using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMnpDemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static List<CultureInfo> m_Languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages {
            get {
                return m_Languages;
            }
        }

        public App() {
            InitializeComponent();
            App.LanguageChanged += App_LanguageChanged;

            m_Languages.Clear();
            m_Languages.Add(new CultureInfo("en-US")); // Neutral culture
            m_Languages.Add(new CultureInfo("ko-KR"));
            m_Languages.Add(new CultureInfo("ru-RU"));

            Language = WpfMnpDemoApp.Properties.Settings.Default.DefaultLanguage;
        }

        public static event EventHandler LanguageChanged;

        public static CultureInfo Language {
            get {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set {
                if (value == null) throw new ArgumentNullException("value");
                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

                //1. Change the application language
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                //2. Creates ResourceDictionary for a new culture
                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name) {
                    default:
                        dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    
                    case "en-US":
                        dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                }

                //3. Finds and deletes the old ResourceDictionary, and adds the new ResourceDictionary
                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
                                              select d).First();
                if (oldDict != null) {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                } else {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                //4. Call event to notify all windows.
                LanguageChanged(Application.Current, new EventArgs());
            }
        }

        private void App_LanguageChanged(Object sender, EventArgs e) {
            WpfMnpDemoApp.Properties.Settings.Default.DefaultLanguage = Language;
            WpfMnpDemoApp.Properties.Settings.Default.Save();
        }
    }
}
