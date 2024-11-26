using CofeeMvc.DAL;
using CofeeMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CofeeMvc.Controllers;

public class HomeController:Controller
{
    AppDbContext db;
    public HomeController(AppDbContext appDb)
    {
        db= appDb;
    }


    public IActionResult Index()
    {
        List<Category> categories=db.categories.Include(x=>x.Products).ToList();
        List<Product> products=db.products.ToList();
        
        HomeVM homeVm = new HomeVM()
        {
            Categories = categories,
            Products = products
            
        };
        return View(homeVm);
    }

}