using System.ComponentModel.DataAnnotations;
using Library.Utils;
using Library.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewModels.BookViewModels;

public class BookAddVm
{
    [Required(ErrorMessage = "*Это поле обязательно")]
    [Remote(action:"BookCheckName", controller:"Validation", ErrorMessage = "*Книга с таким названием уже существует")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "*Это поле обязательно")]
    public string? Author { get; set; }
    [Required(ErrorMessage = "*Это поле обязательно")]
    public string? Image { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }
    public BookState BookState { get; set; }
    public DateTime AddDate { get; set; }
    [Required (ErrorMessage = "*Это поле обязательно")]
    public int CategoryId { get; set; }
    public List<CategoryIndexVm>? CategoryIndexVms { get; set; }

    public int? UserId { get; set; }
}