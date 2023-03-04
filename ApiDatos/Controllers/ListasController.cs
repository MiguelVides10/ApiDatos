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

        [HttpGet]
        [Route("GetById{id}")]
        public IActionResult Get(int id)
        {
            Listas? lista = (from e in _context.Listas where e.Idlista == id
                             select e).FirstOrDefault();

            if(lista == null)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpGet]
        [Route("Find/{super}")]
        public IActionResult FindBySupermercado(string super) {
            List<Listas> lista = (from e in _context.Listas
                             where e.Supermercado.Contains(super)
                             select e).ToList();
            if(lista== null)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult Add([FromBody] Listas lista) {
            try
            {
                _context.Add(lista);
                _context.SaveChanges();
                return Ok(lista);
            }catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
