using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookstore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

//Emma Haynes 3-10-21
//To have a cart for each individual session

namespace OnlineBookstore.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Book bo, int quantity) //Add item to cart
        {
            base.AddItem(bo, quantity);
            Session.SetJson("Cart", this);
        }
        public override void RemoveLine(Book bo) //Remove item from cart
        {
            base.RemoveLine(bo);
            Session.SetJson("Cart", this);
        }
        public override void Clear() //clear cart
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
