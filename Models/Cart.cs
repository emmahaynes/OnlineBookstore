using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 3-10-21
//Model to update information in the cart

namespace OnlineBookstore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book bo, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == bo.BookId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bo,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book bo) =>
            Lines.RemoveAll(x => x.Book.BookId == bo.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum()
        {
            //price is hardcoded here
            return (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);
        }

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
