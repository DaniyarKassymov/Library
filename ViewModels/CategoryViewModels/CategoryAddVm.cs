using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewModels.CategoryViewModels;

public class CategoryAddVm
{
    [Required (ErrorMessage = "*Поле является обязательным")]
    [Remote(action:"CategoryCheckName", controller:"Validation", ErrorMessage = "*Категория с таким названием уже существует")]
    public string? Name { get; set; }
    [Required (ErrorMessage = "*Поле является обязательным")]
    public string? Description { get; set; }
}