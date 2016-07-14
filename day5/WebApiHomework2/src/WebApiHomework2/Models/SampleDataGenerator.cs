using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHomework2.Models;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiHomework2.Models
{
    public static class SampleDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _context = serviceProvider.GetService<ApplicationContext>();

            if (!_context.Authors.Any())
            {
                var author1 = new Author
                {
                    FirstName = "Александр",
                    LastName = "Дюма",
                    BirthPlace = "Вилле-Котре (Франция)",
                };

                var author2 = new Author
                {
                    FirstName = "Эрих Мария",
                    LastName = "Ремарк",
                    BirthPlace = "Оснабрюк (Королевство Пруссия)",
                };

                var genre1 = new Genre
                {
                    Name = "Приключенческий роман",
                    Description = "Жанр романа, сформировавшийся в середине XIX века на волне романтизма и неоромантизма с характерным для них стремлением бежать от мещанской повседневности в мир экзотики и героизма. В более широком смысле можно говорить о существовании особого авантюрного жанра, или приключенческой литературы, которую отличают резкое деление персонажей на героев и злодеев, «стремительность развития действия, переменчивость и острота сюжетных ситуаций, преувеличенность переживаний, мотивы похищения и преследования, тайны и загадки». Задача приключенческой литературы — не столько поучать, анализировать или описывать реальность, сколько развлекать читателя.",

                };

                var genre2 = new Genre
                {
                    Name = "Роман",
                    Description = "Литературный жанр, чаще прозаический, зародившийся в средние века у романских народов как рассказ на народном языке и ныне превратившийся в самый распространенный вид эпической литературы, изображающий жизнь человека с её волнующими страстями (на первом плане любовь), борьбой, социальными противоречиями и стремлениями к идеалу. Будучи развернутым повествованием о жизни и развитии личности главного героя (героев) в кризисный, нестандартный период его жизни, отличается от повести объёмом, сложностью содержания и более широким захватом описываемых явлений.",
                };


                var book1 = new Book
                {
                    Name = "Три товарища",
                    Year = 1953
                };

                var book2 = new Book
                {
                    Name = "Три мушкетера",
                    Year = 1850
                };

                var book3 = new Book
                {
                    Name = "Триумфальная арка",
                    Year = 1957
                };



                author1.Books.Add(book1);
                author1.Books.Add(book3);
                author2.Books.Add(book2);
                genre1.Books.Add(book2);
                genre2.Books.Add(book1);
                genre2.Books.Add(book3);
                _context.Authors.Add(author1);
                _context.Authors.Add(author2);

                _context.Genres.Add(genre1);
                _context.Genres.Add(genre2);

                _context.SaveChanges();
            }


        }
    }
}

