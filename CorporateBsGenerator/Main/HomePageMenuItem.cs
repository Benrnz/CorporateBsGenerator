namespace CorporateBsGenerator.Main
{
    /// <summary>
    /// A model for a menu item in the home page drawer.
    /// </summary>
    public class HomeMenuItem
    {
        /// <summary>
        /// Gets or sets a string path to an icon to show in the drawer menu.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The menu item type.  This is used to map this menu item to a Page that will be shown when selected.
        /// </summary>
        public MenuType MenuType { get; set; }

        /// <summary>
        /// The caption and title for the menu item.
        /// </summary>
        public string Title { get; set; }
    }
}