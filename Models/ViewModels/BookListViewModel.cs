using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 3-2-21

namespace OnlineBookstore.Models.ViewModels
{
    public class BookListViewModel //To create the list of books with pagination
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
