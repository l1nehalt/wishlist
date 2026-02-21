namespace wishlist.Contracts.Responses;

public record WishItemResponse(
    Guid Id,
    string Title,
    string? Description,
    double Price,
    string? Link
);