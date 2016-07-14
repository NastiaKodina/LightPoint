using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiHomework2.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiHomework2.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private ApplicationContext _context;
        public AuthorsController(ApplicationContext libraryContext)
        {
            _context = libraryContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _context.Authors.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == id);
            _context.Authors.ToList().Where(d => d.Id == id);
            return author;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Author newAuthor)
        {
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Author updatedAuthor)
        {

            var authors = _context.Authors.ToList();
            foreach (var author in authors)
            {
                if (author.Id == id)
                {
                    author.BirthPlace = updatedAuthor.BirthPlace;
                    author.FirstName = updatedAuthor.FirstName;
                    author.LastName = updatedAuthor.LastName;
                    author.Books = updatedAuthor.Books;
                    break;

                }
            }
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}

