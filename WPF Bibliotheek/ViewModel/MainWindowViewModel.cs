using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_Bibliotheek.Classes;
using WPF_Bibliotheek.Model;

namespace WPF_Bibliotheek.ViewModel
{
    public class MainWindowViewModel
    {
        public ICommand GoToItemsClick { get; set; }
        public ICommand GoToAuthorsClick { get; set; }

        public MainWindowViewModel()
        {
            GoToItemsClick = new RelayCommand(ItemIndex);
            GoToAuthorsClick = new RelayCommand(AuthorIndex);
        }
        private void ItemIndex()
        {
            ItemView view = new ItemView();
            view.Show();
        }

        private void AuthorIndex()
        {
            AuthorView view = new AuthorView();
            view.Show();
        }
    }
}
