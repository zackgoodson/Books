using Books.Models;
using Books.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }


        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            // Sets number of books listed on each page
            int pageSize = 10;

            var x = new BooksViewModel
            {
                // Uses Linq to query the database
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                // Sets page info for the pagination
                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                    (bookCategory == null
                        ? repo.Books.Count()
                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);
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
