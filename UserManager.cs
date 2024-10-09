using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore2
{
    public class UserManager
    {
        private BookStoreContext _context;

        public UserManager(BookStoreContext context)
        {
            _context = context;
        }

        //добавление нового пользователя
        public void AddUser(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                Console.WriteLine("Пользователь с таким именем уже существует.");
            }
            else
            {
                var user = new User
                {
                    Username = username,
                    Password = password
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                Console.WriteLine("Пользователь успешно добавлен.");
            }
        }

        //проверка авторизации
        public User Autheticate(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
