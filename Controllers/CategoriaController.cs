using LAB04_DelCarpioDeivid.Models;
using LAB04_DelCarpioDeivid.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LAB04_DelCarpioDeivid.Controllers
{
    [ApiController]
    [Route("delcarpio/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categorias = _unitOfWork.Categorias.GetAll();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoria = _unitOfWork.Categorias.GetById(id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _unitOfWork.Categorias.Add(categoria);
            _unitOfWork.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = categoria.CategoriaId }, categoria);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
                return BadRequest("ID mismatch");

            if (_unitOfWork.Categorias.GetById(id) == null)
                return NotFound();

            _unitOfWork.Categorias.Update(categoria);
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = _unitOfWork.Categorias.GetById(id);
            if (categoria == null)
                return NotFound();

            _unitOfWork.Categorias.Delete(id);
            _unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}
