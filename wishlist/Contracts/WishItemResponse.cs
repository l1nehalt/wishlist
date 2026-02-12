namespace wishlist.Contracts;

public record WishItemResponse(
    Guid Id,
    string Title,
    string? Description,
    double Price,
    string? Link
);