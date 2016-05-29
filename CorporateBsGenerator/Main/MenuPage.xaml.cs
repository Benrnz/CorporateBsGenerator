using System.Collections.Generic;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    public partial class MenuPage : ContentPage
    {
        private readonly List<HomeMenuItem> menuItems;
        private readonly ShellPage shell;

        public MenuPage(ShellPage shellPage)
        {
            this.shell = shellPage;
            InitializeComponent();
            BindingContext = new BaseViewModel
            {
                Title = "Menu",
                Subtitle = "Subtitle",
                Icon = "slideout.png"
            };

            this.ListViewMenu.ItemsSource = this.menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Title = "About", MenuType = MenuType.About, Icon = "about.png" },
                new HomeMenuItem { Title = "Generator", MenuType = MenuType.Generator, Icon = "tdl.png" }
            };

            this.ListViewMenu.SelectedItem = this.menuItems[0];

            this.ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (this.ListViewMenu.SelectedItem == null)
                    return;

                await this.shell.NavigateAsync(((HomeMenuItem) e.SelectedItem).MenuType);
            };
        }
    }
}