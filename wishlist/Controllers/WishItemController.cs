using Mapster;
using Microsoft.AspNetCore.Mvc;
using wishlist.Application.Interfaces;
using wishlist.Application.Services;
using wishlist.Contracts;
using wishlist.Contracts.Requests;
using wishlist.Contracts.Responses;


namespace wishlist.Controllers;

[ApiController]
[Route("api/wish-items")]
public class WishItemController : ControllerBase
{
    private readonly IWishItemsService _wishItemsService;
    
    public WishItemController(IWishItemsService wishItemsService)
    {
        _wishItemsService = wishItemsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWishItemsByUserId(Guid userId)
    {
        var wishItems = await _wishItemsService.Get(userId);

        var result = wishItems
            .Select(w => new WishItemResponse(w.Id, w.Title, w.Description, w.Price, w.Link))
            .ToList();
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetWishItemById(Guid id)
    {
        var result = await _wishItemsService.GetById(id);
      
        return result != null
            ? Ok(result.Adapt<WishItemResponse>())
            : NotFound();
    }

    /*[HttpPost]
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
    }*/
}