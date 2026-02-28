using wishlist.Domain.Models;

namespace wishlist.Application.Interfaces;

public interface IWishItemsService
{
    Task<WishItem?> GetById(Guid id);
    
    Task<List<WishItem>> Get(Guid userId);
    
    Task Create(WishItem wishItem);
    
    Task Update(WishItem wishItem);
}