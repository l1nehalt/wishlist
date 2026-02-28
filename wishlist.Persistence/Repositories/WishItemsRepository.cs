using Mapster;
using Microsoft.EntityFrameworkCore;
using wishlist.Domain.Abstractions;
using wishlist.Domain.Models;
using wishlist.Infrastructure.Entities;

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
        var entities = await _dbContext.WishItems
            .AsNoTracking()
            .Where(w => w.UserId == userId)
            .ToListAsync();
        
        var wishItems = entities.Select(w => new WishItem
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
        var entity = await _dbContext.WishItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        var wishItem = new WishItem
        {
            Id = entity!.Id,
            Title = entity.Title,
            Description = entity.Description,
            Link = entity.Link,
            Price = entity.Price,
            CategoryId = entity.CategoryId
        };
        
        return wishItem;
    }

    public async Task Update(WishItem wishItem)
    {
        await _dbContext.WishItems
            .Where(w => w.Id == wishItem.Id)
            .ExecuteUpdateAsync(w => w
                .SetProperty(p => p.Title, p => wishItem.Title)
                .SetProperty(p => p.Description, p => wishItem.Description)
                .SetProperty(p => p.Link, p => wishItem.Link)
                .SetProperty(p => p.Price, p => wishItem.Price));
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task Create(WishItem wishItem)
    {
        var entity = new WishItemEntity
        {
            Id = wishItem.Id,
            Title = wishItem.Title,
            Description = wishItem.Description,
            Link = wishItem.Link,
            Price = wishItem.Price,
            CategoryId = wishItem.CategoryId,
            UserId = wishItem.UserId
        };
        
        await _dbContext.WishItems.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
}