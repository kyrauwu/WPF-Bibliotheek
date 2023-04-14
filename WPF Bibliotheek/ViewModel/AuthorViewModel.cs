using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WPF_Bibliotheek.Classes;
using WPF_Bibliotheek.Model;

namespace WPF_Bibliotheek.ViewModel
{
    public class AuthorViewModel
    {
        public Author Author { get; set; }
        public Author SelectedAuthor { get; set; }
        public ObservableCollection<Author> AllAuthors { get; set; }
        public Item Item { get; set; }
        public ObservableCollection<Item> AllItems { get; set; }
        public ICommand AddClick { get; set; }
        public ICommand ClearClick { get; set; }
        public ICommand SaveClick { get; set; }

        private LibraryContext _db;

        public AuthorViewModel()
        {
            AddClick = new RelayCommand(AddAuthor);
            ClearClick = new RelayCommand(ClearAuthor);
            SaveClick = new RelayCommand(Save);

            _db = new LibraryContext();

            _db.Items.Include(item => item.Author).Load();
            _db.Authors.Include(author => author.Item).Load();

            AllItems = _db.Items.Local.ToObservableCollection();
            AllAuthors = _db.Authors.Local.ToObservableCollection();
        }

        private void AddAuthor()
        {
            AllAuthors.Add(new Author
            {
                Name = "New name"
            }); 
        }

        private void ClearAuthor()
        {
            AllAuthors.Remove(SelectedAuthor);
        }
        private void Save()
        {
            _db.SaveChanges();
        }
    }
}
