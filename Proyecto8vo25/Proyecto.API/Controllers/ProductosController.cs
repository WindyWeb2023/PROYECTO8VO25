using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.API.Data;

namespace Proyecto.API.Controllers
{
    [ApiController]
    [Route("/api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await
                _dataContext.Productos.ToListAsync());
        }
    }
}
