using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineBookstore.Models;
using OnlineBookstore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Emma Haynes 3-3-21

namespace OnlineBookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; //database setup

        private IBooksRepository _repository;
        public int PageSize = 5; //number of items displayed on each page

        public HomeController(ILogger<HomeController> logger, IBooksRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1) //pagination setup
        {
            return View(new BookListViewModel
            {
                Books = _repository.Books
                    .Where(p => category == null || p.Category == category) //allows for a null category
                    .OrderBy(p => p.BookId)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.Category == category).Count() //checking for category matching
                },
                CurrentCategory = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
