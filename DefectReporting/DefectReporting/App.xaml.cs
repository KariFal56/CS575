using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DefectReporting
{
    public partial class App : Application
    {
        static DataBaseAccess database;

        public App()
        {
            //InitializeComponent();
            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static DataBaseAccess Database
         {
            get
            {
                if (database == null)
                {
                    try
                    {
                    database = new DataBaseAccess(DependencyService.Get<IDatabasePath>().GetDatabasePath("DefectReportSQLite.db3"));

                    }
                    catch (System.Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

            }
                return database;
            }
        }

        public int ResumeAtDefectReportId { get; set; }

        protected override void OnStart()
        {
            //app start
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
