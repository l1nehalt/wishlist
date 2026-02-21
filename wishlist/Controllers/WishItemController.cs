using Mapster;
using Microsoft.AspNetCore.Mvc;
using wishlist.Contracts;
using wishlist.Contracts.Requests;
using wishlist.Contracts.Responses;
using wishlist.Domain.Dtos;
using wishlist.Persistence.Models;
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
      
        return result != null
            ? Ok(result.Adapt<WishItemResponse>())
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateWishItem([FromBody]WishItemRequest request)
    {
        var createdWishItem = await _wishItemService.Create(request.Adapt<WishItemDto>());
       
        return CreatedAtAction(
            nameof(GetWishItem),
            new  { id = createdWishItem.Id },
            createdWishItem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateWishItem(Guid id, [FromBody]WishItemRequest request)
    {
        if (id != request.Id) 
            return BadRequest("ID didn't match");
        
        var result = await _wishItemService.Update(request.Adapt<WishItemDto>());

        return result != null
            ? Ok(result.Adapt<WishItemResponse>())
            : NotFound();
    }
}