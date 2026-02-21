using System.ComponentModel.DataAnnotations;

namespace wishlist.Persistence.Models;

public class Category
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    public List<WishItem> WishItems { get; set; } = [];
}