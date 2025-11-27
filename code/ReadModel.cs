/// <summary>
/// Read model representing a shopping cart summary in an e-commerce system.
/// This is our read model in CQRS
/// </summary>

public record ShoppingCartReadModel
{
    public int NumberOfItems { get; init; }
    public decimal TotalPrice { get; init; }
}