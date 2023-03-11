namespace Ilaymor.Bookshelf.Services.Basket.API.Models;

public class BasketItem
{
    Guid CatalogItemId { get; set; }
    int Quanity { get; set; }

    public BasketItem(Guid catalogItemId, int quanity)
    {
        CatalogItemId = catalogItemId;
        Quanity = quanity;
    }
}