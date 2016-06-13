using CorporateBsGenerator.Main;
using Xamarin.Forms;

namespace CorporateBsGenerator
{
    public partial class App : Application
    {
        public const string AppName = "Corporate BS";
        private const string LogTag = "App";

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// The Constructor happens first of all the events in this class.
        /// </summary>
        public App()
        {
            InitializeComponent();
            // The root page of your application
            Shell = new ShellViewModel(new MenuViewModel());
            var mainPage = new ShellPage { BindingContext = Shell };
            Shell.NavigateToDefaultPage();
            MainPage = mainPage;
        }

        public static ShellViewModel Shell { get; private set; }

        public static bool IsWindows10 { get; set; }

        public static IDeviceLogger Logger { get; set; }

        public static string Version { get; set; }

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
            Logger.LogInfo(LogTag, "On Resume");
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application enters the sleeping state.
        /// Occurs when App has lost the focus.  Including using the App Switcher, and pressing home button.
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Logger.LogInfo(LogTag, "On Sleep");
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application starts.
        /// This runs directly after the constructor.
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
            Logger.LogInfo(LogTag, "On Start");
        }
    }
}