using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Bibliotheek.Model
{
    public class Author : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _id;

        public int Id { get => _id; set { _id = value; Notify("Type"); } }
        public string Name { get; set; }
        public virtual ObservableCollection<Item> Item { get; set; }

        public Author()
        {
            Item = new ObservableCollection<Item>();
        }
        private void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
