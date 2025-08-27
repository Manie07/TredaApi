using Microsoft.AspNetCore.Mvc;
using TredaApi.Entities;
using TredaApi.Interfaces;

namespace TredaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repo;
        public ProductosController(IProductoRepository repo) => _repo = repo;

        //Obtiene todos los productos
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.GetAll());

        //Obtiene un producto por su ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prod = await _repo.GetById(id);
            return prod == null ? NotFound() : Ok(prod);
        }

        //Busca productos por nombre y/o rango de precio
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? nombre, [FromQuery] decimal? precioMin, [FromQuery] decimal? precioMax)
        {
            var productos = await _repo.Search(nombre, precioMin, precioMax);
            return Ok(productos);
        }

        //Crea un nuevo producto
        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            await _repo.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        //Actualiza un producto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();
            await _repo.Update(producto);
            return NoContent();
        }

        //Elimina un producto por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}
