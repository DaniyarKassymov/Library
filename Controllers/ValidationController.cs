using Library.Database;

namespace Library.Controllers;

public class ValidationController
{
    private readonly LibraryDbContext _db;

    public ValidationController(LibraryDbContext db)
    {
        _db = db;
    }

    public bool BookCheckName(string name)
    {
        return !_db.Books.Any(book => book.Name == name);
    }

    public bool CategoryCheckName(string name)
    {
        return !_db.Categories.Any(category => category.Name == name);
    }
    
    public bool UserCheckName(string name)
    {
        return !_db.Users.Any(category => category.Name == name);
    }
    
    public bool UserCheckSurname(string surname)
    {
        return !_db.Users.Any(category => category.Surname == surname);
    }
    
    public bool UserCheckEmail(string email)
    {
        return !_db.Users.Any(category => category.Email == email);
    }
    
    public bool UserCheckPhone(string phoneNumber)
    {
        return !_db.Users.Any(category => category.PhoneNumber == phoneNumber);
    }
}