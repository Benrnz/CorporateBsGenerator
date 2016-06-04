using System.Collections.Generic;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    /// <summary>
    /// The Drawer menu page
    /// </summary>
    public partial class MenuPage : ContentPage
    {
        private readonly ShellPage shell;

        public MenuPage(ShellPage shellPage)
        {
            List<HomeMenuItem> menuItems;
            this.shell = shellPage;
            InitializeComponent();
            BindingContext = new BaseViewModel
            {
                Title = "Menu",
                Icon = "slideout.png"
            };

            this.ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Title = "About", MenuType = MenuType.About, Icon = "about.png" },
                new HomeMenuItem { Title = "Generator", MenuType = MenuType.Generator, Icon = "tdl.png" } // TODO Need an icon here
            };

            this.ListViewMenu.SelectedItem = menuItems[0];

            this.ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (this.ListViewMenu.SelectedItem == null) return;
                await App.Shell.NavigateAsync(((HomeMenuItem) e.SelectedItem).MenuType);
            };
        }
    }
}