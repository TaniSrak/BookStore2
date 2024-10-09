using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore2
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bookstore.db");
        }


        // заполнение бд тестовыми данными
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Гарри Поттер", Author = "Дж. К. Роулинг", Genre = "Фэнтези", Year = 1997, Price = 300 },
                new Book { Id = 2, Title = "Властелин колец", Author = "Дж. Р. Р. Толкин", Genre = "Фэнтези", Year = 1954, Price = 500 }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "password123" } // простой тестовый пользователь
            );
        }

        
    }
}
