using WebApi.Models.Base;

namespace WebApi.Models;

public class Author: Model
{
    public string? Name {get; set;}

    public string? LastName {get; set;}

    public virtual IList<Book>? Books { get; set; } = default!;
    
    
}
