using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public class ShellPage : MasterDetailPage
    {
        public ShellPage()
        {
            Master = new MenuPage();
            App.Shell.Navigating += OnNavigating;
            // ReSharper disable once VirtualMemberCallInContructor
            InvalidateMeasure();
            
        }

        private void OnNavigating(object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Detail = App.Shell.DetailPage;
                IsPresented = false;
            });
        }
    }
}