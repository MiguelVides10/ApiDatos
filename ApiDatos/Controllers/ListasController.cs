using ApiDatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListasController : ControllerBase
    {
        private readonly ListasDeSuperContext _context;

        public ListasController(ListasDeSuperContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Listas> listas = (from e in _context.Listas 
                                   select e).ToList();
            if(listas.Count == 0)
            {
                return NotFound();
            }

            return Ok(listas);
        }
    }
}
