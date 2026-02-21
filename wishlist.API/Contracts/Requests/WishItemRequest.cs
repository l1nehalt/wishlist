namespace wishlist.Contracts.Requests;

public record WishItemRequest(
    Guid Id,
    string Title, 
    string? Description, 
    string? Link, 
    double Price, 
    Guid UserId, 
    Guid? CategoryId
);