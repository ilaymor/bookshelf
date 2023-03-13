using Ilaymor.Bookshelf.Services.Basket.API.Models;

namespace Ilaymor.Bookshelf.Services.Basket.API.Dto;

public record BasketUpdateDto(Guid Id, IEnumerable<BasketItem> BasketItems);