using Microsoft.EntityFrameworkCore;
using wishlist.Models;

namespace wishlist.Services;

public class WishItemService
{
    private readonly AppDbContext _dbContext;

    public WishItemService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<WishItem?> Get(Guid id)
    {
        return await _dbContext.WishItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<WishItem> Create(string title, string? description, 
        string? link, double price, Guid userId, Guid? categoryId)
    {
        var withItem = new WishItem
        {
            Title = title,
            Description = description,
            Link = link,
            Price = price,
            UserId = userId,
            CategoryId = categoryId
        };
        
        _dbContext.WishItems.Add(withItem);
        await _dbContext.SaveChangesAsync();
        
        return withItem;
    }
}