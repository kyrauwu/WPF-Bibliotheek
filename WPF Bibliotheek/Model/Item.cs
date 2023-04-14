using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WPF_Bibliotheek.Model
{
    public class Item : INotifyPropertyChanged, IEnumerable
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

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
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
