using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 3-10-21

namespace OnlineBookstore.Components
{
    public class NavigationMenuViewComponent : ViewComponent //inheritance
    {

        private IBooksRepository repository;

        public NavigationMenuViewComponent(IBooksRepository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"]; //take each category and filter by it

            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
