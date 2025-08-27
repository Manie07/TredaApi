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

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prod = await _repo.GetById(id);
            return prod == null ? NotFound() : Ok(prod);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? nombre, [FromQuery] decimal? precioMin, [FromQuery] decimal? precioMax)
        {
            var productos = await _repo.Search(nombre, precioMin, precioMax);
            return Ok(productos);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Producto producto)
        {
            await _repo.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();
            await _repo.Update(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return NoContent();
        }
    }
}
