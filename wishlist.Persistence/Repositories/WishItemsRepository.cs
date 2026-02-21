using Mapster;
using Microsoft.EntityFrameworkCore;
using wishlist.Domain.Abstractions;
using wishlist.Domain.Models;

namespace wishlist.Infrastructure.Repositories;

public class WishItemsRepository : IWishItemsRepository
{
    private readonly WishListDbContext _dbContext;
    
    public WishItemsRepository(WishListDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<WishItem>> Get(Guid userId)
    {
        var wishItemEntities = await _dbContext.WishItems
            .AsNoTracking()
            .Where(w => w.UserId == userId)
            .ToListAsync();
        
        var wishItems = wishItemEntities.Select(w => new WishItem
        {
            Id = w.Id,
            Title = w.Title,
            Description = w.Description,
            Link = w.Link,
            Price = w.Price,
            CategoryId = w.CategoryId
        }).ToList();
        
        return wishItems;
    }

    public async Task<WishItem?> GetById(Guid id)
    {
        var wishItemEntity = await _dbContext.WishItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        
        return wishItemEntity.Adapt<WishItem>();
    }
    

    /*public async Task Add(WishItem)
    {
        var 
    }

    public async Task Update(WishItemEntity wishItemEntity)
    {
        return _dbContext.WishItems
            .ExecuteUpdate(w => 
            w.SetProperty(wishItemEntity.Title = ))
    }*/
}