using Library.Database;
using Library.Mappers;
using Library.Utils;
using Library.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers;

public class UserController : Controller
{
    private readonly LibraryDbContext _db;

    public UserController(LibraryDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var users = _db.Users
            .Include(b =>b.Books)
            .ToList();

        var userIndexVms = users.Select(UserMapper.ToIndexVm).ToList();

        return View(userIndexVms);
    }
    
    public IActionResult Add()
    {
        UserAddVm userAddVm = new UserAddVm();

        return View(userAddVm);
    }
    
    [HttpPost]
    public IActionResult Add(UserAddVm userAddVm)
    {
        if (userAddVm != null)
        {
            _db.Users.Add(UserMapper.ToUserAddVm(userAddVm));
            _db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        return RedirectToAction("Add");
    }

    [HttpPost]
    public IActionResult TakeBook(string email, int id)
    {
        var user = _db.Users.Include(userBooks => userBooks.Books).FirstOrDefault(user => user.Email == email);
        
        var book = _db.Books.Find(id);

        if (user != null)
        {
            book.State = BookState.Given;
            book.UserId = user.Id;
            book.User = user;
            user.Books.Add(book);
            _db.Books.Update(book);
            _db.Users.Update(user);
            _db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }

        return NotFound("Такого пользователя нет");
    }

    [HttpGet]
    public IActionResult PersonalAccount()
    {
        return View(new UserIndexVm());
    }
    
    [HttpGet]
    public IActionResult PersonalSite(UserIndexVm userIndexVm)
    {   
        return View(userIndexVm);
    }

    [HttpPost]
    public IActionResult PersonalSite(string email)
    {
        var firstOrDefaultUser = _db.Users
            .Include(user => user.Books)
            .FirstOrDefault(user => user.Email == email);

        var userIndexVm = UserMapper.ToIndexVm(firstOrDefaultUser);

        return View("PersonalSite", userIndexVm);
    }
}