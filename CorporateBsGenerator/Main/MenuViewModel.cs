using System.Collections.Generic;

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

            SelectedMenuItem = MenuItems[1];
        }

        public List<HomeMenuItem> MenuItems { get; private set; }

        public HomeMenuItem SelectedMenuItem
        {
            get { return this.doNotUseSelectedMenuItem; }
            set { SetProperty(ref this.doNotUseSelectedMenuItem, value, onChanged: OnMenuItemChanged); }
        }

        private async void OnMenuItemChanged()
        {
            if (SelectedMenuItem == null) return;
            await App.Shell.NavigateAsync(((HomeMenuItem)SelectedMenuItem).MenuType);
        }
    }
}
