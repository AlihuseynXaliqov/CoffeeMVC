using CofeeMvc.DAL;
using CofeeMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CofeeMvc.Areas.manage.Controllers;

[Area("manage")]
public class CategoryController : Controller
{
    private AppDbContext _appDbContext;

    public CategoryController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        List<Category> categories = _appDbContext.categories.Include(i => i.Products).ToList();
        return View(categories);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _appDbContext.categories.Add(category);
        _appDbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();
        _appDbContext.categories.Remove(_appDbContext.categories.Find(id));
        _appDbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Update(int? id)
    {
        if (id == null) return NotFound();
        var category = _appDbContext.categories.Find(id);
        return View(category);
    }
    [HttpPost]
    public IActionResult Update(Category category)
    {
        
        var oldCategory = _appDbContext.categories.FirstOrDefault(c=>c.Id == category.Id);
        if (oldCategory == null) return NotFound();
        oldCategory.Name = category.Name;
        _appDbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}