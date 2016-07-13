using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiHomework.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiHomework.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private LibraryContext _context;
        public BooksController(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _context.Books.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            return book; 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Book newBook)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book updatedBook)
        {
            var books = _context.Books.ToList();
            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    book.Name = updatedBook.Name;
                    book.Year = updatedBook.Year;
                    book.Genre = updatedBook.Genre;
                    book.GenreId = updatedBook.GenreId;
                    book.Author = updatedBook.Author;
                    book.AuthorId = updatedBook.AuthorId;                 
                    break;

                }
            }
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
