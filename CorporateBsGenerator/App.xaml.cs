using CorporateBsGenerator.Main;
using Xamarin.Forms;

namespace CorporateBsGenerator
{
    public partial class App : Application
    {
        public const string AppName = "Corporate BS";
        private const string LogTag = "CorporateBS.App";

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
            Logger.LogInfo(LogTag, "On Resume");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Logger.LogInfo(LogTag, "On Sleep");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Logger.LogInfo(LogTag, "On Start");
        }
    }
}