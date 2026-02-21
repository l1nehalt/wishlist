using wishlist.Application.Interfaces;
using wishlist.Domain.Abstractions;
using wishlist.Domain.Models;
using wishlist.Infrastructure.Repositories;

namespace wishlist.Application.Services;

public class WishItemsService : IWishItemsService
{
    private readonly IWishItemsRepository _wishItemsRepository;

    public WishItemsService(IWishItemsRepository wishItemsRepository)
    {
        _wishItemsRepository = wishItemsRepository;
    }
    
    public async Task<List<WishItem>> Get(Guid userId)
    {
        return await _wishItemsRepository.Get(userId);
    }
    
    public async Task<WishItem?> GetById(Guid id)
    {
        return await _wishItemsRepository.GetById(id);
    }

    /*public async Task<WishItem> Create(WishItemDto wishItemDto)
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
    }*/
}