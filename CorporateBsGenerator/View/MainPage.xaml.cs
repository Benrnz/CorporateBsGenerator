using System;
using System.Collections.ObjectModel;
using CorporateBsGenerator.Services;
using Xamarin.Forms;

namespace CorporateBsGenerator.View
{
    public partial class MainPage : ContentPage
    {
        private readonly GeneratorService _service = new GeneratorService();

		public MainPage()
        {
            InitializeComponent();  // Initialise Xamarin.Forms required in every page's code behind.

            BindingContext = this;  // Bind to itself. All properties refered to in Bindings will come from here.
            Title = "Corporate BS Generator"; 
        }

        public Command FabExecuteCommand
        {
            get
            {
                return new Command(() => OnGenerateClicked(this, EventArgs.Empty));
            }
        }

        public string MainText => "Corporate BS Generator";

        public string Instructions => "Touch + to catapult your career into the stratosphere!";

        public ObservableCollection<string> Results { get; set; } = new ObservableCollection<string>();

        private void OnGenerateClicked(object sender, EventArgs e)
        {
            var statement = _service.Generate();
            var firstLetter = statement.ToCharArray(0, 1);
            var theRest = statement.ToCharArray(1, statement.Length - 1);
			firstLetter[0] = char.ToUpper(firstLetter[0]);
            Results.Add(new string(firstLetter) + new string(theRest) + ".");
        }
    }
}
