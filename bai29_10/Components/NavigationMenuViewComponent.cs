using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bai29_10.Models;

namespace bai29_10.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        ////public string Invoke() {
        //    return "hello";
        //} 
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }

    }
}
