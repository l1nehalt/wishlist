namespace wishlist.Domain.Dtos;

public record WishItemDto(
    Guid Id,
    string Title, 
    string? Description, 
    string? Link, 
    double Price, 
    Guid UserId, 
    Guid? CategoryId
);