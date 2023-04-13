using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Bibliotheek.Model;

namespace WPF_Bibliotheek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Author JKR = new Author
            {
                Initials = "J. K.",
                LastName = "Rolling"
            };

            Author Bryan = new Author
            {
                Initials = "B.",
                LastName = "Bao"
            };

            Item HarryPooterBookOne = new Item
            {
                Type = ItemType.Boek,
                Name = "Harry Potter & The Philosopher's Stone",
            };

            Item HarryPooterMovieTwo = new Item
            {
                Type = ItemType.DVD,
                Name = "Harry Potter & The Chamber Of Secrets",
            };

            HarryPooterBookOne.Author.Add(JKR);
            HarryPooterMovieTwo.Author.Add(JKR);
            HarryPooterMovieTwo.Author.Add(Bryan);

            List<Item> allItems = new List<Item>
            {
                HarryPooterMovieTwo,
                HarryPooterBookOne,
            };
        }
    }
}
