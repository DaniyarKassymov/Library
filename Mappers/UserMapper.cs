using Library.Models;
using Library.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Mappers;

public static class UserMapper
{
    public static User ToUserAddVm(UserAddVm userAddVm)
    {
        return new User()
        {
            Books = userAddVm.Books,
            Name = userAddVm.Name,
            Email = userAddVm.Email,
            Surname = userAddVm.Surname,
            PhoneNumber = userAddVm.PhoneNumber
        };
    }

    public static UserIndexVm ToIndexVm(User user)
    {
        return new UserIndexVm()
        {
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Surname = user.Surname,
            Books = user.Books,
            Name = user.Name,
            Id = user.Id
        };
    }
}