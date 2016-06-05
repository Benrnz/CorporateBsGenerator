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
            if (App.Shell.IsLoading)
            {
                Detail = App.Shell.DetailPage;
                IsPresented = false;
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Detail = App.Shell.DetailPage;
                    IsPresented = false;
                });
            }
        }
    }
}