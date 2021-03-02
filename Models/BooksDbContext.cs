using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 3-1-21

namespace OnlineBookstore.Models
{
    public class BooksDbContext : DbContext //Setting up the database
    {
        public BooksDbContext (DbContextOptions<BooksDbContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
