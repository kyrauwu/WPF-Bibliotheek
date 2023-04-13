using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Bibliotheek.Model
{
    public class Item
    {
        public ItemType Type { get; set; }
        public string Name { get; set; }
        public List<Author> Author { get; set; }

        public Item()
        {
            Author = new List<Author>();
        }
    }

    public enum ItemType
    {
        Boek,
        Tijdschrift,
        CD,
        DVD,
        Bluray,
        Spel,
    }
}
