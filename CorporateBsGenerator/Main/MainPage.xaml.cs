using System;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent(); // Initialise Xamarin.Forms required in every page's code behind.

            var vm = new MainViewModel(); // Bind to the view model. All properties refered to in Bindings will look on that class for the property name.
            vm.Resetting += OnResetting;
            BindingContext = vm;
        }

        private void OnResetting(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android) this.FabButton.Show();
        }
    }
}