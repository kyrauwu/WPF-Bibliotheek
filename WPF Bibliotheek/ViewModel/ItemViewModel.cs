using Castle.Core.Internal;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
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
        public ICommand SaveClick { get; set; }
        public ICommand SearchClick { get; set; }
        public ICommand FilterOnIdClick { get; set; }
        public ICommand FilterOnAlphabetClick { get; set; }

        private LibraryContext _db;

        public ItemViewModel()
        {
            AddClick = new RelayCommand(AddItem);
            ClearClick = new RelayCommand(ClearItem);
            LinkClick = new RelayCommand(LinkItem);
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
            SelectedAuthor.Item.Add(SelectedItem);
        }

        private void Save()
        {
            _db.SaveChanges();
        }
    }
}