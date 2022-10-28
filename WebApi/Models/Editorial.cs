using WebApi.Models.Base;

namespace WebApi.Models;
 public class Editorial:Model
 {
    public string? Name {get; set;}

    public string? Ciudad {get; set;}

    public string? ISBN {get; set;}

    public virtual List<Book>? Books{get; set;} = default!;

 }