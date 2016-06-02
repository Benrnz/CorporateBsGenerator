using System;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public partial class MainPage
    {
        private MainViewModel viewModel;

        public MainPage()
        {
            InitializeComponent(); // Initialise Xamarin.Forms required in every page's code behind.
            App.Logger.LogInfo(MainViewModel.FeatureName, "MainPage created");
            BindingContextChanged += OnBindingContextChanged;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            if (BindingContext == null)
            {
                if (this.viewModel != null)
                {
                    this.viewModel.Resetting -= OnResetting;
                    this.viewModel = null;
                }
            }
            else
            {
                this.viewModel = (MainViewModel)BindingContext;
                this.viewModel.Resetting += OnResetting;
            }
        }

        private void OnResetting(object sender, EventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            if (vm == null) return;

            if (Device.OS == TargetPlatform.Android) this.FabButton.Show();
        }
    }
}