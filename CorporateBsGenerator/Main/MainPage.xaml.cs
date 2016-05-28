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
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext == null)
            {
                if (this.viewModel != null) this.viewModel.Resetting -= OnResetting;
                return;
            }

            this.viewModel = (MainViewModel) BindingContext;
            this.viewModel.Resetting += OnResetting;
        }

        private void OnResetting(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android) this.FabButton.Show();
        }
    }
}