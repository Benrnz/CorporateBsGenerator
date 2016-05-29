using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public class ShellPage : MasterDetailPage
    {
        private readonly Dictionary<MenuType, NavigationPage> pages;

        public ShellPage()
        {
            this.pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);
            BindingContext = new BaseViewModel
            {
                Title = App.AppName,
                Icon = "slideout.png"
            };

            NavigateAsync(MenuType.Generator).Wait();

            InvalidateMeasure();
        }

        public static bool IsUwpDesktop { get; set; }

        public async Task NavigateAsync(MenuType id)
        {
            if (!this.pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.About:
                        // TODO need an about page
                        this.pages.Add(id, new MyNavigationPage(new ContentPage
                        {
                            BindingContext = new BaseViewModel { Title = "About" },
                            Title = "About",
                        } ));
                        break;
                    case MenuType.Generator:
                        this.pages.Add(id, new MyNavigationPage(new MainPage { BindingContext = new MainViewModel() }));
                        break;
                }
            }

            Page newPage = this.pages[id];
            if (newPage == null)
                return;

            //pop to root for Windows Phone
            if (Detail != null && Device.OS == TargetPlatform.WinPhone)
            {
                await Detail.Navigation.PopToRootAsync();
            }

            Detail = newPage;

            if (IsUwpDesktop)
                return;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}