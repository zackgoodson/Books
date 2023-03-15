using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Infrastructure;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public PurchaseModel (IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            cart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);
            
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
