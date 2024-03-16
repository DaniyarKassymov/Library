using Library.Models;

namespace Library.ViewModels.UserViewModels;

public class UserIndexVm
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public List<Book> Books { get; set; }
}