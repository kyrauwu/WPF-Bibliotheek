﻿using Microsoft.EntityFrameworkCore;
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
    public class MainWindowViewModel
    {
        public Author Author { get; set; }
        public Author SelectedAuthor { get; set; }
        public ObservableCollection<Author> AllAuthors { get; set; }
        public Item Item { get; set; }
        public Item SelectedItem { get; set; }
        public ObservableCollection<Item> AllItems { get; set; }
        public ICommand AddAuthorClick { get; set; }
        public ICommand ClearItemClick { get; set; }
        public ICommand LinkItemClick { get; set; }
        public ICommand SaveItemClick { get; set; }

        private LibraryContext _db;

        public MainWindowViewModel()
        {
            AddAuthorClick = new RelayCommand(AddAuthor);
            ClearItemClick = new RelayCommand(ClearItem);
            /*LinkItemClick = new RelayCommand(LinkItem);*/
            SaveItemClick = new RelayCommand(SaveItem);

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

        private void ClearItem()
        {
            AllAuthors.Remove(SelectedAuthor);
        }

        /*private void LinkItem()
        {
            SelectedAuthor.Item.Add(SelectedItem);
        }
*/
        private void SaveItem()
        {
            _db.SaveChanges();
        }
    }
}
