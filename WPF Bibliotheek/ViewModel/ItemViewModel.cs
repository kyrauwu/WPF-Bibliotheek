using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_Bibliotheek.Classes;
using WPF_Bibliotheek.Model;

namespace WPF_Bibliotheek.ViewModel
{
    public class ItemViewModel
    {
        public Author Author { get; set; }
        public Author SelectedAuthor { get; set; }
        public ObservableCollection<Author> AllAuthors { get; set; }
        public Item Item { get; set; }
        public Item SelectedItem { get; set; }
        public ObservableCollection<Item> AllItems { get; set; }
        public string SearchItem { get; set; }
        public ICommand AddClick { get; set; }
        public ICommand ClearClick { get; set; }
        public ICommand LinkClick { get; set; }
        public ICommand UnlinkClick { get; set; }
        public ICommand SaveClick { get; set; }

        private LibraryContext _db;

        public ItemViewModel()
        {
            AddClick = new RelayCommand(AddItem);
            ClearClick = new RelayCommand(ClearItem);
            LinkClick = new RelayCommand(LinkItem);
            UnlinkClick = new RelayCommand(UnlinkItem);
            SaveClick = new RelayCommand(Save);

            _db = new LibraryContext();

            _db.Items.Include(item => item.Author).Load();
            _db.Authors.Include(author => author.Item).Load();

            AllItems = _db.Items.Local.ToObservableCollection();
            AllAuthors = _db.Authors.Local.ToObservableCollection();
        }

        private void AddItem()
        {
            AllItems.Add(new Item
            {
                Type = ItemType.Boek,
                Name = "New name",

            });
        }

        private void ClearItem()
        {
            AllItems.Remove(SelectedItem);
        }

        private void LinkItem()
        {

            if (!SelectedItem.Author.Contains(SelectedAuthor))
            {
                SelectedItem.Author.Add(SelectedAuthor);
            }
        }

        private void UnlinkItem()
        {

            if (SelectedItem.Author.Contains(SelectedAuthor))
            {
                SelectedItem.Author.Remove(SelectedAuthor);
            }
        }

        private void Save()
        {
            _db.SaveChanges();
        }
    }
}