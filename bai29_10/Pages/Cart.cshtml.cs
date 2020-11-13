using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bai29_10.Models;
using bai29_10.Models.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace bai29_10.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo)
        {
            repository = repo;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}