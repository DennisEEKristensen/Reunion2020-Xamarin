using System;
using System.Collections.Generic;
using System.Text;

namespace Reunion2020.Models
{
    public enum MenuItemType
    {
        Events,
        Contact,
        Reminders //(?)
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
