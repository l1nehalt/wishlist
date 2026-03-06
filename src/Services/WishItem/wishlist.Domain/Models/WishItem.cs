namespace wishlist.Domain.Models;

public class WishItem
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public double Price { get; set; }
    
    public string? Link { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid? CategoryId { get; set; }

    /*private WishItem(Guid id, string? description, double price, string? link, Guid userId, Guid? categoryId)
    {
        Id = id;
        Description = description;
        Price = price;
        Link = link;
        UserId = userId;
        CategoryId = categoryId;
    } 

    public static (WishItem? wishItem, string? Error) Create(
        Guid id,
        string title,
        string? description,
        double price,
        string link,
        Guid userId,
        Guid? categoryId)
    {
        if (string.IsNullOrEmpty(title)) return (null, "Title can not be empty");
        
        var wishItem = new WishItem(id, description, price, link, userId, categoryId);
        
        return (wishItem, null);
    }*/
}