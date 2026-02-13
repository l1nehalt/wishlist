using Mapster;
using Microsoft.EntityFrameworkCore;
using wishlist.Contracts;
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

    public async Task<WishItem> Create(WishItemRequest request)
    {
        var withItem = request.Adapt<WishItem>();
        
        var result = _dbContext.WishItems.Add(withItem).Entity;
        await _dbContext.SaveChangesAsync();
        
        return result;
    }

    public async Task<WishItem> Update(WishItemRequest request)
    {
        var 
    }
}