using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.API.Data;
using Proyecto.Shared.Entidad;

namespace Proyecto.API.Controllers
{
    [ApiController]
    [Route("/api/usuarios")]
    public class UsariosController : ControllerBase
    {
        //le decimos que sea solo lectura los atributos de  Datacontext
        private readonly DataContext _dataContext;
        public UsariosController(DataContext dataContext)
        {
            _dataContext = dataContext;
            
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await 
                _dataContext.Usuarios.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync (Usuario usuario)
        {
            _dataContext.Add(usuario);
            await _dataContext.SaveChangesAsync();
            return Ok(usuario);

        }

        [HttpGet("{id:int}")]
        
        public async Task<ActionResult> GetID(int id)
        {
            var user = await _dataContext.Usuarios.
                FirstOrDefaultAsync(u => u.Id == id);
            if(user is null)
            {
                return NotFound();
            }

            return Ok(user); 
        }

        [HttpPut]
        public async Task<ActionResult> Actualizar(Usuario usuario)
        {
            _dataContext.Update(usuario);
            await _dataContext.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete (int id)
        {
            var filaAfectada = await _dataContext.Usuarios
                .Where(u=>u.Id== id)
                .ExecuteDeleteAsync();
            if (filaAfectada == 0)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
