using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CorporateBsGenerator.Services;
using Xamarin.Forms;

namespace CorporateBsGenerator.View
{
    public partial class MainPage
    {
        private readonly GeneratorService service = new GeneratorService();

        private Task timerTask;

        public MainPage()
        {
            InitializeComponent(); // Initialise Xamarin.Forms required in every page's code behind.

            BindingContext = this; // Bind to itself. All properties refered to in Bindings will come from here.
            Title = "Corporate BS Generator"; // App Title (As seen in App Switcher)
        }

        public Command FabExecuteCommand
        {
            get { return new Command(() => OnGenerateClicked(this, EventArgs.Empty)); }
        }

        public string Instructions => "Tap + to catapult your career into the stratosphere!";

        public ObservableCollection<string> Results { get; set; } = new ObservableCollection<string>();

        private void OnGenerateClicked(object sender, EventArgs e)
        {
            LabelInstructions.IsVisible = false;

            var statement = service.Generate();
            Results.Add(statement);
            ResetButton.IsVisible = true;
        }

        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            Results.Clear();
            ResetButton.IsVisible = false;
            if (Device.OS == TargetPlatform.Android) FabButton.Show();
        }
    }
}
