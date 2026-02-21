using wishlist.Domain.Models;

namespace wishlist.Domain.Abstractions;

public interface IWishItemsRepository
{
    Task<WishItem?> GetById(Guid id);
    
    Task<List<WishItem>> Get(Guid userId);
}