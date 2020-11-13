using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bai29_10.Models;
using bai29_10.Models.ViewModels;

namespace bai29_10.Controllers
{
    public class HomeController : Controller
    {
        
        private IStoreRepository repository;
        public int pageSize = 2;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        //public IActionResult Index() => View(repository.Products);
        //public IActionResult Index()
        //{
        //  return View();
        //}

        //public ViewResult Index(int productPage = 1)
        //   => View(new ProductListViewModel
        //   {
        //       Products = repository.Products.OrderBy(p => p.ProductId)
        //       .Skip((productPage - 1) * pageSize)
        //       .Take(pageSize),
        //       PageInfo = new PageInfo
        //       {
        //           CurrentPage = productPage,
        //           ItemsPage = pageSize,
        //           TotalItems = repository.Products.Count()
        //       }
        //   });

        public ViewResult Index(string category, int productPage = 1)
            => View(new ProductListViewModel {
              Products=  repository.Products
                .Where(p=>category==null||p.Category==category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage=productPage,
                    ItemsPage=pageSize,
                    //TotalItems=repository.Products.Count()
                    TotalItems=category==null? repository.Products.Count() : repository.Products.Where(
                        e=>e.Category==category).Count()
                },
                CurrentCategory=category
            });

        private ViewResult View(IQueryable<Product> queryables, PageInfo pageInfo)
        {
            throw new NotImplementedException();
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
