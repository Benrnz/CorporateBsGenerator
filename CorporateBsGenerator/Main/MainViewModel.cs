using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CorporateBsGenerator.Services;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
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

        public event EventHandler Resetting;

        public ICommand GenerateCommand => new Command(GenerateCommandExecute);

        public string Instructions => "Touch + to catapult your career into the stratosphere!";

        public ICommand ResetCommand => new Command(ResetCommandExecute);

        public ObservableCollection<string> Results { get; set; } = new ObservableCollection<string>();

        public bool ShowInstructions
        {
            get { return this.doNotUseShowInstructions; }
            set { SetProperty(ref this.doNotUseShowInstructions, value); }
        }

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