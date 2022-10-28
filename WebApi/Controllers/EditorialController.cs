using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;
using WebApi.Data;
using WebApi.Models;

namespace WebAppi.Controllers;

[ApiController, Route ("api/[controller]")]

public class EditorialController : ApiControllerBase<Editorial>
{
    public EditorialController(DataContext context, ILogger<Editorial> logger) : base (context, logger){
        
    }
}