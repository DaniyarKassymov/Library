using Library.Models;
using Library.ViewModels.CategoryViewModels;

namespace Library.Mappers;

public static class CategoryMapping
{
    public static CategoryIndexVm ToIndexVm(Category category)
    {
        return new CategoryIndexVm()
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
    
    public static Category FromAddVmToCategory(CategoryAddVm categoryAddVm)
    {
        return new Category()
        {
            Name = categoryAddVm.Name,
            Description = categoryAddVm.Description,
        };
    }
}