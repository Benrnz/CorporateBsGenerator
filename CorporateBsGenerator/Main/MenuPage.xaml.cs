using System.Collections.Generic;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    /// <summary>
    /// The Drawer menu page
    /// </summary>
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            List<HomeMenuItem> menuItems;
            InitializeComponent();

            this.ListViewMenu.ItemsSource = menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Title = "About", MenuType = MenuType.About, Icon = "about.png" },
                new HomeMenuItem { Title = "Generator", MenuType = MenuType.Generator, Icon = "tdl.png" } // TODO Need an icon here
            };

            this.ListViewMenu.SelectedItem = menuItems[1];

            this.ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (this.ListViewMenu.SelectedItem == null) return;
                await App.Shell.NavigateAsync(((HomeMenuItem) e.SelectedItem).MenuType);
            };
        }
    }
}