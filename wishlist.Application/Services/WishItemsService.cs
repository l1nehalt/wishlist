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

    public async Task Create(WishItem wishItem)
    {
        await _wishItemsRepository.Create(wishItem);
    }

    public async Task Update(WishItem wishItem)
    {
        await _wishItemsRepository.Update(wishItem);
    }
}