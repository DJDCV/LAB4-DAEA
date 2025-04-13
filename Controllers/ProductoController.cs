using LAB04_DelCarpioDeivid.Models;
using LAB04_DelCarpioDeivid.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LAB04_DelCarpioDeivid.Controllers;

[ApiController]
[Route("delcarpio/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var productos = _unitOfWork.Productos.GetAll();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var producto = _unitOfWork.Productos.GetById(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Producto producto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _unitOfWork.Productos.Add(producto);
        _unitOfWork.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = producto.ProductoId }, producto);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Producto producto)
    {
        if (id != producto.ProductoId) return BadRequest("ID mismatch");
        if (_unitOfWork.Productos.GetById(id) == null) return NotFound();
        _unitOfWork.Productos.Update(producto);
        _unitOfWork.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var producto = _unitOfWork.Productos.GetById(id);
        if (producto == null) return NotFound();
        _unitOfWork.Productos.Delete(id);
        _unitOfWork.SaveChanges();
        return NoContent();
    }
}