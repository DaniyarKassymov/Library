using Library.Utils;

namespace Library.ViewModels.BookViewModels;

public class BookDetailsVm
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string Image { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }
    public DateTime AddDate { get; set; }
    public BookState BookState { get; set; }
    public string? Category { get; set; }
}