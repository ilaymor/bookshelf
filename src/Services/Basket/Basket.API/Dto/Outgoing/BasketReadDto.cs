using Ilaymor.Bookshelf.Services.Basket.API.Models;

namespace Ilaymor.Bookshelf.Services.Basket.API.Dto;

public record BasketReadDto(Guid Id, Guid UserId, IEnumerable<BasketItem> BasketItems);

