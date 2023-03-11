using Ilaymor.Bookshelf.Services.Basket.API.Models;

namespace Ilaymor.Bookshelf.Services.Basket.API.Dto;

public record BasketUpdateDto(Guid BasketId, IEnumerable<BasketItem> BasketItems);