using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public interface IBooksRepository //interface meant to be inherited
    {
        IQueryable<Book> Books { get; }
    }
}
