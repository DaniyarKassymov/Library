using System.ComponentModel.DataAnnotations;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewModels.UserViewModels;

public class UserAddVm
{
    [Required(ErrorMessage = "*Это поле обязательно")]
    [Remote(action:"UserCheckName", controller:"Validation", ErrorMessage = "*Пользователь с таким именем уже существует")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "*Это поле обязательно")]
    [Remote(action:"UserCheckSurname", controller:"Validation", ErrorMessage = "*Пользователь с такой фамилией уже существует")]
    public string? Surname { get; set; }
    [Required(ErrorMessage = "*Это поле обязательно")]
    [Remote(action:"UserCheckEmail", controller:"Validation", ErrorMessage = "*Пользователь с таким email уже существует")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "*Это поле обязательно")]
    [Remote(action:"UserCheckPhone", controller:"Validation", ErrorMessage = "*Пользователь с таким номером телефона уже существует")]
    public string? PhoneNumber { get; set; }

    public List<Book>? Books { get; set; }
}