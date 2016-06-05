using System.Collections.Generic;
using System.Linq;

namespace CorporateBsGenerator.Main
{
    public class MenuViewModel : BaseViewModel
    {
        private HomeMenuItem doNotUseSelectedMenuItem;

        public MenuViewModel()
        {
            MenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { Title = "About", MenuType = MenuType.About, Icon = "about.png" },
                new HomeMenuItem { Title = "Generator", MenuType = MenuType.Generator, Icon = "bubble.png" }
            };
        }

        public List<HomeMenuItem> MenuItems { get; }

        public HomeMenuItem SelectedMenuItem
        {
            get { return this.doNotUseSelectedMenuItem; }
            set { SetProperty(ref this.doNotUseSelectedMenuItem, value, onChanged: OnMenuItemChanged); }
        }

        public string Version
        {
            get { return App.Version; }
        }

        public void SetSelectedItem(MenuType menuType)
        {
            var item = MenuItems.Single(m => m.MenuType == menuType);
            SelectedMenuItem = item;
        }

        private async void OnMenuItemChanged()
        {
            if (SelectedMenuItem == null) return;
            await App.Shell.NavigateAsync(SelectedMenuItem.MenuType);
        }
    }
}