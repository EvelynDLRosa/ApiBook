using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController, Route ("api/[controller]")]
public class BookController : ApiControllerBase<Book>
{
    public BookController(DataContext context, ILogger<Book> logger) : base(context, logger)
    {
            
    }
}