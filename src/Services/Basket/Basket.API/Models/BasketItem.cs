namespace Ilaymor.Bookshelf.Services.Basket.API.Models;

public class BasketItem
{
    public Guid CatalogItemId { get; set; }
    public int Quanity { get; set; }

    public BasketItem(Guid catalogItemId, int quanity)
    {
        CatalogItemId = catalogItemId;
        Quanity = quanity;
    }
}