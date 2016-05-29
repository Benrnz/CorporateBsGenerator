﻿namespace CorporateBsGenerator.Main
{
    public class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.About;
        }

        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}