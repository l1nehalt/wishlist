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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetWishItem(Guid id)
    {
        var result = await _wishItemService.Get(id);
        
        if (result == null) return NotFound();

        var response = result.Adapt<WishItemResponse>();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWishItem([FromBody]CreateWishItemRequest request)
    {
       var createdWishItem = await _wishItemService.Create(
            request.Title,
            request.Description, 
            request.Link, 
            request.Price, 
            request.UserId,
            request.CategoryId
        );
       
        var response = createdWishItem.Adapt<WishItemResponse>();
        
        return CreatedAtAction(
            nameof(GetWishItem),
            new { id = response.Id },
            response
        );
        
    }
}