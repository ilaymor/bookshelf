namespace Ilaymor.Bookshelf.Services.Basket.API.Models;

public class CostumerBasket
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public IEnumerable<BasketItem> BasketItems { get; set; }

    public CostumerBasket(Guid userId, IEnumerable<BasketItem> basketItems)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        BasketItems = basketItems;
    }
}