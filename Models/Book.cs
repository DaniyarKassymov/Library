using Library.Utils;

namespace Library.Models;

public class Book
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string Image { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }
    public DateTime AddDate { get; set; }

    public BookState State { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int? UserId { get; set; }
    public User? User { get; set; }
}