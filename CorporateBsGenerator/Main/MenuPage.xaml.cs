using System.Collections.Generic;
using Xamarin.Forms;

namespace CorporateBsGenerator.Main
{
    /// <summary>
    /// The Drawer menu page
    /// </summary>
    public partial class MenuPage 
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.ListViewMenu.SelectedItem == null) return;
            await App.Shell.NavigateAsync(((HomeMenuItem)e.SelectedItem).MenuType);
        }
    }
}