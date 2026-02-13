namespace wishlist.Contracts;

public record WishItemRequest(
    string Title, 
    string? Description, 
    string? Link, 
    double Price, 
    Guid UserId, 
    Guid? CategoryId
);