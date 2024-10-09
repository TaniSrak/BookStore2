using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStore2
{
    public class DataInitializer
    {
        public static void Initialize(BookStoreContext context) //инициализация
        {
            context.Database.Migrate(); // миграции (если они есть)

           //тестовый данные
            if (!context.Books.Any())
            {
                context.Books.Add(new Book
                {
                    Title = "Новая книга",
                    Author = "Автор книги",
                    Genre = "Жанр",
                    Year = 2024,
                    Price = 100
                });
                context.SaveChanges();
            }
        }
    }
}
