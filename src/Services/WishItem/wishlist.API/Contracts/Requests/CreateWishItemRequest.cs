namespace wishlist.Contracts.Requests;

public record CreateWishItemRequest(
    string Title, 
    string? Description, 
    string? Link, 
    double Price, 
    Guid UserId, 
    Guid? CategoryId
);