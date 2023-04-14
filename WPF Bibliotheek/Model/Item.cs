using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Bibliotheek.Model
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _name;
        private ItemType _type;

        public int Id { get; set; }
        public ItemType Type { get => _type; set { _type = value; Notify("Type"); } }
        public string Name { get => _name; set { _name = value; Notify("Name"); } }
        public virtual ObservableCollection<Author> Author { get; set; }

        public Item()
        {
            Author = new ObservableCollection<Author>();
        }
        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
