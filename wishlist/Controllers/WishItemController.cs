using Mapster;
using Microsoft.AspNetCore.Mvc;
using wishlist.Contracts;
using wishlist.Services;

namespace wishlist.Controllers;

[ApiController]
[Route("api/wish-items")]
public class WishItemController : ControllerBase
{
    private readonly WishItemService _wishItemService;
    
    public WishItemController(WishItemService wishItemService)
    {
        _wishItemService = wishItemService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWishItem(Guid id)
    {
        var result = await _wishItemService.Get(id);
        
        if (result == null) return NotFound();

        var response = result.Adapt<WishItemResponse>();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWishItem(WishItemRequest request)
    {
       var createdWishItem = await _wishItemService.Create(request);
       
       var response = createdWishItem.Adapt<WishItemResponse>();
        
        return CreatedAtAction(
            nameof(GetWishItem),
            new { id = response.Id },
            response
        );
    }

    [HttpPatch("{id}")]
    public Task<IActionResult> UpdateWishItem(WishItemRequest request)
    {
        /*var result = await _wishItemService.*/
    }
    
}