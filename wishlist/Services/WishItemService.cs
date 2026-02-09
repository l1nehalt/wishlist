using Microsoft.EntityFrameworkCore;
using wishlist.Models;

namespace wishlist.Services;

public class WishItemService(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<WishItem?> Get(Guid id)
    {
        return await _dbContext.WishItems
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}