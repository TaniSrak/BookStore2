using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Linq;
using System.Windows;
using BookStore2;


namespace BookStore2
{
    public partial class MainWindow : Window
    {
        private BookStoreContext db;
        private UserManager userManager;
        public MainWindow()
        {
            InitializeComponent();
            db = new BookStoreContext();
            userManager = new UserManager(db);

            //userManager.AddUser("user1", "pass123");
        }

        //загрузка всех книг
        private void LoadBooks()
        {
            lstBooks.ItemsSource = db.Books.ToList();
        }

        //добавлнеие книг
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newBook = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = txtGenre.Text,
                Year = int.Parse(txtYear.Text),
                Price = int.Parse(txtPrice.Text)
            };
            db.Books.Add(newBook);  
            db.SaveChanges();
            LoadBooks(); 
        }

        //редактирования книги
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lstBooks.SelectedItem is Book selectedBook)
            {
                selectedBook.Title = txtTitle.Text;
                selectedBook.Author = txtAuthor.Text;
                selectedBook.Genre = txtGenre.Text;
                selectedBook.Year = int.Parse(txtYear.Text);
                selectedBook.Price = decimal.Parse(txtPrice.Text);
                db.SaveChanges();
                LoadBooks();
            }
        }

        //удаление книги
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lstBooks.SelectedItem is Book selectedBook)
            {
                db.Books.Remove(selectedBook);
                db.SaveChanges();
                LoadBooks();
            }
        }

        //продажа книги
        private void btnSell_Click(object sender, RoutedEventArgs e)
        {
            if(lstBooks.SelectedItem is Book selectedBook)
            {
                LoadBooks();
            }
        }

        //поиск книги
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txtSearch.Text.ToLower();
            var filteredBooks = db.Books.Where(b =>
                b.Title.ToLower().Contains(searchText)
                || b.Author.ToLower().Contains(searchText)
                || b.Genre.ToLower().Contains(searchText)).ToList();
                lstBooks.ItemsSource = filteredBooks;
        }


    }
}