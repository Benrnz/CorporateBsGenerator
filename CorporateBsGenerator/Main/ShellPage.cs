using System.Collections.Generic;
using System.Threading.Tasks;
using CorporateBsGenerator.About;
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
                Icon = "slideout.png" // An inbuilt icon
            };

            NavigateAsync(MenuType.Generator).Wait();

            // ReSharper disable once VirtualMemberCallInContructor
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
                        this.pages.Add(id, new MyNavigationPage(new AboutPage { BindingContext = new AboutViewModel() }));
                        break;
                    case MenuType.Generator:
                        this.pages.Add(id, new MyNavigationPage(new MainPage { BindingContext = new MainViewModel() }));
                        break;
                }
            }

            Page newPage = this.pages[id];
            if (newPage == null)
                return;

            Detail = newPage;

            if (IsUwpDesktop)
                return;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}