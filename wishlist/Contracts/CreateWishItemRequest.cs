namespace wishlist.Contracts;

public record CreateWishItemRequest(
    string Title, 
    string? Description, 
    string? Link, 
    double Price, 
    Guid UserId, 
    Guid? CategoryId
);