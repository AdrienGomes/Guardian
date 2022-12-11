using GuardianProject.SQL_Account;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: ExportFont("MeetCute.otf")]
namespace GuardianProject
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Account.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            VersionTracking.Track();

            if (VersionTracking.IsFirstLaunchForCurrentVersion)
                MainPage = new NavigationPage(new Pages.LanguagePageFolder.LanguagePage());
            else
                MainPage = new NavigationPage(new Pages.WelcomePageFolder.WelcomPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
