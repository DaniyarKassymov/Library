using Library.Utils;

namespace Library.ViewModels.BookViewModels;

public class BookIndexVm
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Image { get; set; }
    public DateTime AddDate { get; set; }
    public BookState BookState { get; set; }
    public string? Email { get; set; }
}