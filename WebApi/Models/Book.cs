using WebApi.Models.Base;

namespace WebApi.Models;

public class Book: Model
{
    public string? Name {get; set; }

    public int? AuthorId {get; set;}
    
    public int? EditorialID {get; set;}
    public DateTime ReleaseDate {get; set;}

    public virtual Author? Author { get; set;} = default!;
    public virtual Editorial? Editorial {get; set;} = default!;
}