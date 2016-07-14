using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiHomework2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiHomework2.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly UserManager<User> _userManager;
        private ApplicationContext _context;
        public BooksController(ApplicationContext libraryContext,UserManager<User> userManager)
        {
            _context = libraryContext;
            _userManager = userManager;
        }
        // GET: api/values
        [HttpGet]
       // [Authorize]
        public IEnumerable<Book> Get()
        {
            var userId = _userManager.GetUserId(Request.HttpContext.User);
            return _context.Books.ToList().Where(x => x.UserId == userId);
        }

        // POST api/values
        [HttpPost]
        [Authorize]
        public void Post([FromBody]Book newBook)
        { 

             var userId = _userManager.GetUserId(Request.HttpContext.User);
             newBook.UserId = userId;
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody]Book updatedBook)
        {
            var userId = _userManager.GetUserId(Request.HttpContext.User);
            var books = _context.Books.ToList();
            foreach (var book in books)
            {
                if (book.Id == id && book.UserId==userId)
                {
                    book.Name = updatedBook.Name;
                    book.Year = updatedBook.Year;
                    book.Genre = updatedBook.Genre;
                    book.GenreId = updatedBook.GenreId;
                    book.Author = updatedBook.Author;
                    book.AuthorId = updatedBook.AuthorId;
                    book.User = updatedBook.User;
                    book.UserId = updatedBook.UserId;
                    break;

                }
            }
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            var userId = _userManager.GetUserId(Request.HttpContext.User);
            var book = _context.Books.SingleOrDefault(x => x.Id == id && x.UserId==userId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}