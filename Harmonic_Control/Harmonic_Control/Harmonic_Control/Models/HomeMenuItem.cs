using System;
using System.Collections.Generic;
using System.Text;

namespace Harmonic_Control.Models
{
    public enum MenuItemType
    {
        MainPage,
        Checkconnect,
        About,
        Exit
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
