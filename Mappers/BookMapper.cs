using Library.Models;
using Library.ViewModels.BookViewModels;

namespace Library.Mappers;

public static class BookMapper
{
    public static BookIndexVm ToViewModel(Book book)
    {
        return new BookIndexVm()
        {
            Name = book.Name,
            Author = book.Author,
            Image = book.Image,
            AddDate = book.AddDate,
            Id = book.Id,
            BookState = book.State
        };
    }

    public static Book FromAddVmToBook(BookAddVm bookAddVm)
    {
        return new Book()
        {
            Author = bookAddVm.Author,
            Image = bookAddVm.Image,
            Name = bookAddVm.Name,
            AddDate = bookAddVm.AddDate,
            Description = bookAddVm.Description,
            ReleaseDate = bookAddVm.ReleaseDate,
            CategoryId = bookAddVm.CategoryId,
            State = bookAddVm.BookState,
            UserId = bookAddVm.UserId
        };
    }

    public static BookDetailsVm ToBookDetailsVm(Book book)
    {
        return new BookDetailsVm()
        {
            Author = book.Author,
            Image = book.Image,
            Name = book.Name,
            AddDate = book.AddDate,
            Description = book.Description,
            ReleaseDate = book.ReleaseDate,
            Category = book.Category.Name,
            Id = book.Id,
            BookState = book.State
        };
    }
}