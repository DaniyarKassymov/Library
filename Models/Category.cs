namespace Library.Models;

public class Category
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}