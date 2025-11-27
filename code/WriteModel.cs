
/// <summary>
/// Example of a simple aggregate root representing a shopping cart in an e-commerce system.
/// This is our write model in CQRS
/// </summary>
public class ShoppingCart
{
    private List<CartItem> _items;
    private List<Coupon> _coupons;
    private User _owner;

    public void AddItem(CartItem item)
    {
        // check age regulation for certain products
        if (_owner.IsUnderageForProduct(item))
        {
            throw new InvalidOperationException("User is not of legal age to add this item.");
        }

        var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            _items.Add(item);
        }
    }

    public decimal GetTotalPrice()
    {
        decimal totalPrice = _items.Sum(item => item.Price * item.Quantity);

        foreach (var coupon in _coupons)
        {
            totalPrice -= coupon.GetDiscount(totalPrice);
        }

        return totalPrice;
    }
}