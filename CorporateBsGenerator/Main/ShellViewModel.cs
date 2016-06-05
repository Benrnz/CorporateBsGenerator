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

        public bool IsUwpDesktop { get; set; }

        public Page DetailPage { get; private set; }

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

            DetailPage = this.pages[id];
            Navigating?.Invoke(this, EventArgs.Empty);
        }
    }
}
