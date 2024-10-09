using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BookStore2;

namespace BookStore2
{
    public partial class Login : Window
    {
        private UserManager userManager;

        public Login()
        {
            InitializeComponent();
            var db = new BookStoreContext();
            userManager = new UserManager(db); 
        }

   
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;

           
            var user = userManager.Autheticate(username, password);
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

    }
}
