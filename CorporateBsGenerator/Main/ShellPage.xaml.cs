using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public partial class ShellPage : MasterDetailPage
    {
        public ShellPage()
        {
            Master = new MenuPage(this);
            App.Shell.NavigateAsync(MenuType.Generator).Wait();

            // ReSharper disable once VirtualMemberCallInContructor
            InvalidateMeasure();
        }
    }
}
