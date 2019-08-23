using System;
using System.Collections.Generic;
using System.Text;

namespace MasterCodeMobile.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        ListeCategorie,
        Profil,
        ListeForum
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
