using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHomework.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        public virtual Genre Genre { get; set; }
        public int GenreId { get; set; }

    }
}

