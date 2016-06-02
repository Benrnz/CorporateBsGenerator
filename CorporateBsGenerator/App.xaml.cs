using CorporateBsGenerator.Main;
using Xamarin.Forms;

namespace CorporateBsGenerator
{
    public partial class App : Application
    {
        public const string AppName = "Corporate BS";

        public App()
        {
            InitializeComponent();
            // The root page of your application
            MainPage = new ShellPage();
        }

        public static bool IsWindows10 { get; set; }

        public static IDeviceLogger Logger { get; set; }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}