using System.Text.RegularExpressions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using wishlist.Application.Interfaces;
using wishlist.Application.Services;
using wishlist.Contracts;
using wishlist.Contracts.Requests;
using wishlist.Contracts.Responses;
using wishlist.Domain.Models;


namespace wishlist.Controllers;

[ApiController]
[Route("wish-items")]
public class WishItemsController : ControllerBase
{
    private readonly IWishItemsService _wishItemsService;
    
    public WishItemsController(IWishItemsService wishItemsService)
    {
        _wishItemsService = wishItemsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetByUserId([FromQuery]Guid userId)
    {
        var wishItems = await _wishItemsService.Get(userId);

        var result = wishItems
            .Select(w => new WishItemResponse(w.Id, w.Title, w.Description, w.Price, w.Link))
            .ToList();
        
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _wishItemsService.GetById(id);
      
        return result != null
            ? Ok(result.Adapt<WishItemResponse>())
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string title, 
        string? description, 
        string? link, 
        double price, 
        Guid userId, 
        Guid? categoryId)
    {
        var targetWishItem = new WishItem
        {
            Title = title,
            Description = description,
            Price = price,
            Link = link,
            CategoryId = categoryId,
            UserId = userId
        };
        
        await _wishItemsService.Create(targetWishItem);

        return CreatedAtAction(
            nameof(GetById),
            new { id = targetWishItem.Id },
            targetWishItem
        );
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateWishItem(Guid id, [FromBody]WishItemRequest request)
    {
        if (id != request.Id) return BadRequest("ID didn't match");

        var targetWishItem = new WishItem
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            Link = request.Link,
            CategoryId = request.CategoryId,
            UserId = request.UserId
        };

        await _wishItemsService.Update(targetWishItem);
        
        return Ok(new WishItemResponse(
            targetWishItem.Id, 
            targetWishItem.Title, 
            targetWishItem.Description, 
            targetWishItem.Price, 
            targetWishItem.Link
        ));
    }
}