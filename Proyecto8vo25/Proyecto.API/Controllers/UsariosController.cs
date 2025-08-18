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


    }
}
