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

        public ShellViewModel(MenuViewModel menuViewModel)
        {
            IsLoading = true;
            this.pages = new Dictionary<MenuType, NavigationPage>();
            Title = App.AppName;
            Icon = "slideout.png"; // An inbuilt icon
            MenuViewModel = menuViewModel;
        }

        public event EventHandler Navigating;

        public MenuType DefaultMenuType => MenuType.Generator;

        public Page DetailPage { get; private set; }

        public bool IsLoading { get; private set; }

        public bool IsUwpDesktop { get; set; }

        public MenuViewModel MenuViewModel { get; }

        public async Task NavigateAsync(MenuType id)
        {
            if (IsLoading) return;
            if (!this.pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.About:
                        var viewModel = await Task.Run(() => new AboutViewModel());
                        var mainPage = new MyNavigationPage(new AboutPage { BindingContext = viewModel });
                        this.pages.Add(id, mainPage);
                        break;
                    case MenuType.Generator:
                        // Should already be in dictionary by now because it is required to call NavigateToDefaultPage during start up.
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
            MenuViewModel.SetSelectedItem(DefaultMenuType);
            Navigating?.Invoke(this, EventArgs.Empty);
            IsLoading = false;
        }

        private NavigationPage CreateMainPage()
        {
            return new MyNavigationPage(new MainPage { BindingContext = new MainViewModel() });
        }
    }
}