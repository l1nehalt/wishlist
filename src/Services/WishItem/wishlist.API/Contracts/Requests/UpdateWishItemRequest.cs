namespace wishlist.Contracts.Requests;

public record UpdateWishItemRequest(
    Guid Id,
    string Title, 
    string? Description, 
    string? Link, 
    double Price, 
    Guid UserId, 
    Guid? CategoryId
);