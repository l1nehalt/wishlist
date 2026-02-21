using Mapster;
using Microsoft.EntityFrameworkCore;
using wishlist.Contracts.Requests;
using wishlist.Domain.Dtos;
using wishlist.Persistence;
using wishlist.Persistence.Models;

namespace wishlist.Services;

public class WishItemService
{
    private readonly WishListDbContext _dbContext;

    public WishItemService(WishListDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<WishItem?> Get(Guid id)
    {
        return await _dbContext.WishItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<WishItem> Create(WishItemDto wishItemDto)
    {
        var withItem = wishItemDto.Adapt<WishItem>();
        
        var result = _dbContext.WishItems.Add(withItem).Entity;
        await _dbContext.SaveChangesAsync();
        
        return result;
    }

    public async Task<WishItem?> Update(WishItemDto wishItemDto)
    {
        var targetWishItem = await _dbContext.WishItems.FindAsync(wishItemDto.Id);
        
        if (targetWishItem == null) return null;
        
        await _dbContext.SaveChangesAsync();
        
        return wishItemDto.Adapt(targetWishItem);
    }
}