using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;
using WebApi.Data;
using WebApi.Models;

namespace WebAppi.Controllers;

[ApiController, Route ("api/[controller]")]

public class AuthorController : ApiControllerBase<Author>
{
    public AuthorController(DataContext context, ILogger<Author> logger) : base (context, logger){
        
    }
}