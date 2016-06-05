using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CorporateBsGenerator.About;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public class ShellViewModel : BaseViewModel
    {
        private readonly Dictionary<MenuType, NavigationPage> pages;

        public ShellViewModel()
        {
            this.pages = new Dictionary<MenuType, NavigationPage>();
            Title = App.AppName;
            Icon = "slideout.png"; // An inbuilt icon
        }

        public event EventHandler Navigating;

        public MenuType DefaultMenuType => MenuType.Generator;

        public Page DetailPage { get; private set; }

        public bool IsUwpDesktop { get; set; }

        public async Task NavigateAsync(MenuType id)
        {
            if (!this.pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.About:
                        var aboutPage = await Task.Run(() => CreateMainPage());
                        this.pages.Add(id, aboutPage);
                        break;
                    case MenuType.Generator:
                        var mainPage = await Task.Run(() => new MyNavigationPage(new MainPage { BindingContext = new MainViewModel() }));
                        this.pages.Add(id, mainPage);
                        break;
                }
            }

            DetailPage = this.pages[id];
            await Task.Run(() => Navigating?.Invoke(this, EventArgs.Empty));
        }

        /// <summary>
        ///     Navigates to default page for the App.  MUST ONLY BE USED ONCE AT APP START-UP.
        ///     I don't want this used after App Start up because it is synchronous.  All navigation after App Startup should be
        ///     asynchronous.
        /// </summary>
        public void NavigateToDefaultPage()
        {
            var mainPage = CreateMainPage();
            this.pages.Add(DefaultMenuType, mainPage);
            DetailPage = mainPage;
            Navigating?.Invoke(this, EventArgs.Empty);
        }

        private NavigationPage CreateMainPage()
        {
            return new MyNavigationPage(new AboutPage { BindingContext = new AboutViewModel() });
        }
    }
}