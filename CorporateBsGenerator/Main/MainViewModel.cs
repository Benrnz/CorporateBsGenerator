﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CorporateBsGenerator.Annotations;
using CorporateBsGenerator.Services;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly GeneratorService service;
        private bool doNotUseShowInstructions;
        private bool doNotUseShowResetButton;

        public MainViewModel()
        {
            // TODO change to DI
            ShowInstructions = true;
            ShowResetButton = false;
            this.service = new GeneratorService();
        }

        public ICommand GenerateCommand => new Command(GenerateCommandExecute);

        public ICommand ResetCommand => new Command(ResetCommandExecute);

        public string Instructions => "Touch + to catapult your career into the stratosphere!";

        public ObservableCollection<string> Results { get; set; } = new ObservableCollection<string>();

        public string Title => "Corporate BS Generator"; // App Title (As seen in App Switcher)

        public bool ShowInstructions
        {
            get { return this.doNotUseShowInstructions; }
            set
            {
                if (value == this.doNotUseShowInstructions) return;
                this.doNotUseShowInstructions = value;
                OnPropertyChanged();
            }
        }

        public bool ShowResetButton
        {
            get { return this.doNotUseShowResetButton; }
            set
            {
                if (value == this.doNotUseShowResetButton) return;
                this.doNotUseShowResetButton = value;
                OnPropertyChanged();
            }
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
            // TODO
            // if (Device.OS == TargetPlatform.Android) this.FabButton.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
