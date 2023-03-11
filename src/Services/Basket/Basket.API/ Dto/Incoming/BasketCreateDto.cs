using Ilaymor.Bookshelf.Services.Basket.API.Models;

namespace Ilaymor.Bookshelf.Services.Basket.API.Dto;

public record BasketCreateDto(Guid UserId, IEnumerable<BasketItem> BasketItems);
