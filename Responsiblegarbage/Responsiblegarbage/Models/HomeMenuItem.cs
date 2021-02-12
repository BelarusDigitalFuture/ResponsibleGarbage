using System;
using System.Collections.Generic;
using System.Text;

namespace Responsiblegarbage.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        SearchProduct
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
