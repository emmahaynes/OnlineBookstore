using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 3-1-21

namespace OnlineBookstore.Models
{
    public interface IBooksRepository //interface meant to be inherited
    {
        IQueryable<Book> Books { get; }
    }
}
