using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStore2
{
    public class Book //хранение книг в бд
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public bool IsPartOfSeries { get; set; }
    }
}
