using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public class ShellPage : MasterDetailPage
    {
        public ShellPage()
        {
            Master = new MenuPage();
            App.Shell.NavigateAsync(MenuType.Generator).Wait();
            Detail = App.Shell.DetailPage;
            App.Shell.Navigating += OnNavigating;

            // ReSharper disable once VirtualMemberCallInContructor
            InvalidateMeasure();
        }

        private void OnNavigating(object sender, System.EventArgs e)
        {
            Detail = App.Shell.DetailPage;
            IsPresented = false;
        }
    }
}