using Library.Database;
using Library.Mappers;
using Library.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

public class CategoryController : Controller
{
    private readonly LibraryDbContext _db;

    public CategoryController(LibraryDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Add()
    {
        var categoryAddVm = new CategoryAddVm();

        return View(categoryAddVm);
    }
    
    [HttpPost]
    public IActionResult Add(CategoryAddVm categoryAddVm)
    {
        if (categoryAddVm != null)
        {
            _db.Categories.Add(CategoryMapping.FromAddVmToCategory(categoryAddVm));
            _db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        return RedirectToAction("Add");
    }
}