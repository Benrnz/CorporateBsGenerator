using System;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent(); // Initialise Xamarin.Forms required in every page's code behind.
            App.Logger.LogInfo(MainViewModel.FeatureName, "MainPage created");
        }

        private void OnResetting(object sender, EventArgs e)
        {
            // TODO better solution needed here. Messaging probably.
            var vm = BindingContext as MainViewModel;
            if (vm == null) return;

            if (Device.OS == TargetPlatform.Android) this.FabButton.Show();
        }
    }
}