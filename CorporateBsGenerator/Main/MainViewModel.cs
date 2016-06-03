using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CorporateBsGenerator.Services;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    /// <summary>
    /// A view model for the main generator page.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        public const string FeatureName = "Generator";

        private readonly GeneratorService service;
        private bool doNotUseShowInstructions;
        private bool doNotUseShowResetButton;

        public MainViewModel()
        {
            // TODO change to DI
            ShowInstructions = true;
            ShowResetButton = false;
            this.service = new GeneratorService();
            Title = App.AppName;
        }

        /// <summary>
        /// Resetting is raised when the user taps the Reset button.
        /// </summary>
        public event EventHandler Resetting;

        /// <summary>
        /// A command to generate a new slogan.
        /// </summary>
        public ICommand GenerateCommand => new Command(GenerateCommandExecute);

        public string Instructions => "Touch + to catapult your career into the stratosphere!";

        /// <summary>
        /// A command to empty the list and start over.
        /// </summary>
        public ICommand ResetCommand => new Command(ResetCommandExecute);

        /// <summary>
        /// All generated slogans since last reset.
        /// </summary>
        public ObservableCollection<string> Results { get; set; } = new ObservableCollection<string>();

        /// <summary>
        /// Gets or sets a boolean to indicate if the Instructions should be shown or not.
        /// </summary>
        public bool ShowInstructions
        {
            get { return this.doNotUseShowInstructions; }
            set { SetProperty(ref this.doNotUseShowInstructions, value); }
        }

        /// <summary>
        /// Gets or sets a boolean to indicate if the Reset Button should be shown or not.
        /// </summary>
        public bool ShowResetButton
        {
            get { return this.doNotUseShowResetButton; }
            set { SetProperty(ref this.doNotUseShowResetButton, value); }
        }

        private void GenerateCommandExecute()
        {
            ShowInstructions = false;

            var statement = this.service.Generate();
            Results.Add(statement);
            ShowResetButton = true;
        }

        private void ResetCommandExecute()
        {
            Results.Clear();
            ShowResetButton = false;
            Resetting?.Invoke(this, EventArgs.Empty);
        }
    }
}