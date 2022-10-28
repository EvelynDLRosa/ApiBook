using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models.Base;

namespace WebApi.Controllers.Base;

public abstract class ApiControllerBase<T> : ControllerBase where T: Model
{
    private readonly DataContext context;
    private readonly ILogger<T> _logger;

    protected DbSet<T> entities
    {
        get 
        {
            return context.Set<T>();
        }
    }
    public ApiControllerBase(DataContext context, ILogger<T> logger)
    {
        this.context = context;
         _logger = logger;
        // this.logger = logger;
       
    }

    [HttpGet] // GET: api/{entity}

    public async Task<ActionResult<IEnumerable<T>>> Get()
    {
        var list = await entities.ToListAsync();
        return Ok(list);
    }

    [HttpGet("{id}")] // GET: api/{entity}/{id}

    public async Task<ActionResult<T>> GetById(int id)
    {
        var entity = await entities.FindAsync(id);
        if (entity is null) 
        {
            return NotFound($"No se encontró una entidad con el id: {id} ");
        }
        return Ok(entity);
    }

    [HttpPost] //POST: api/{entity}
    public async Task<ActionResult<T>> CreateT(T entity)
    {
        entity.CreatedOn = DateTime.Now;
        entity.UpdatedOn = DateTime.Now;

        // if (entity is null)
        // {
        //     return BadRequest("La entidad no debe ser nula"); 
        // }
        await entities.AddAsync(entity);
        await context.SaveChangesAsync();
        // return Ok(entity);
        return CreatedAtAction(
            nameof(CreateT),
            new{ id = entity.Id },
            entity
        );
    }

    [HttpPut("{id}")] // PUT: api/{entity}/{id}
    public async Task<ActionResult<T>> UpdateT(int id, T entity)
    {
        if (entity == null)
        // {
            throw new ArgumentNullException("entity");   
            // return BadRequest("La entidad no debe ser nula"); 
        // }
        if (id != entity.Id)
        // {
            return new BadRequestObjectResult("Los id no coinciden");
            // return BadRequest("Los ids no coinciden"); 
        // }
        entity.UpdatedOn = DateTime.Now;
        entities.Update(entity);
        await context.SaveChangesAsync();
        return Ok(entity);
    }

    [HttpDelete("{id}")] //DELETE: api/{entity}/{id}
    public async Task<ActionResult<T>> Delete(int id)
    {
        var entity = await entities.FindAsync(id);
        if (entity == null) 
        {
            return new NotFoundObjectResult($"No se encontró una entidad con el id: {id} ");
        }
        entities.Remove(entity);
        await context.SaveChangesAsync();
        return Ok(entity);
    }
}