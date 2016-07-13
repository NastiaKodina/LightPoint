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
    public class GenresController : Controller
    {
        private LibraryContext _context;
        public GenresController(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            return _context.Genres.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Genre Get(int id)
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == id);
            return genre;          
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Genre newGenre)
        {
            _context.Genres.Add(newGenre);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Genre updatedGenre)
        {
            var genres = _context.Genres.ToList();
            foreach (var genre in genres)
            {
                if (genre.Id ==id)
                {
                    genre.Name = updatedGenre.Name;
                    genre.Description = updatedGenre.Description;
                    genre.Books = updatedGenre.Books;
                    break;
                }
            }
            _context.SaveChanges();
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == id);
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
