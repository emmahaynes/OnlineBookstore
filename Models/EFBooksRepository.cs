using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BooksDbContext _context;

        //constructor
        public EFBooksRepository (BooksDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
