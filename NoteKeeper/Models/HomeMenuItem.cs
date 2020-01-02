using System;
using System.Collections.Generic;
using System.Text;

namespace NoteKeeper.Models
{
    public enum MenuItemType
    {
        Meals,
        Calendar,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
