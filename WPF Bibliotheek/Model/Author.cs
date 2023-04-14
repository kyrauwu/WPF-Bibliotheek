using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Bibliotheek.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ObservableCollection<Item> Item { get; set; }

        public Author()
        {
            Item = new ObservableCollection<Item>();
        }
    }
}
