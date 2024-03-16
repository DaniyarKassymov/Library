using Library.Database;
using Library.Mappers;
using Library.ViewModels.BookViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers;

public class BookController : Controller
{
    private readonly LibraryDbContext _db;

    public BookController(LibraryDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var books = _db.Books
            .Include(book => book.Category)
            .Include(book => book.User)
            .ToList();
        
        var indexVms = books.Select(BookMapper.ToViewModel).ToList();

        indexVms = indexVms.OrderBy(book => book.AddDate).ToList();

        return View(indexVms);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var addVm = new BookAddVm()
        {
            AddDate = DateTime.Now,
            CategoryIndexVms = _db.Categories.Select(CategoryMapping.ToIndexVm).ToList()
        };

        return View(addVm);
    }

    [HttpPost]
    public IActionResult Add(BookAddVm bookAddVm)
    {
        if (bookAddVm != null)
        {
            _db.Books.Add(BookMapper.FromAddVmToBook(bookAddVm));
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        return RedirectToAction("Add");
    }

    public IActionResult Details(int id)
    {
        var book = _db.Books
            .Include(book => book.Category)
            .FirstOrDefault(b => b.Id == id);

        if (book != null)
        {
            var bookDetailsVm = BookMapper.ToBookDetailsVm(book);

            return View(bookDetailsVm);
        }

        return NotFound();
    }

    [HttpGet]
    public IActionResult TakeBook(int id)
    {
        var book = _db.Books.Find(id);

        var bookIndexVm = BookMapper.ToViewModel(book);

        return View(bookIndexVm);
    }
}