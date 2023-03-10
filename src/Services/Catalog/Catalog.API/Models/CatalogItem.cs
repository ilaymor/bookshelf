namespace Ilaymor.Bookshelf.Services.Catalog.API.Model;

public class CatalogItem
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string AuthorName { get; set; }

    public CatalogItem(string title, string authorName)
    {
        Id = Guid.NewGuid();
        Title = title;
        AuthorName = authorName;
    }
}