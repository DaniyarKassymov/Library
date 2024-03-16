using System.ComponentModel.DataAnnotations;

namespace Library.Utils;

public enum BookState
{
    [Display(Name = "В наличие")] InStock,
    [Display(Name = "Сдана")] Given
} 