using LAB04_DelCarpioDeivid.Models;
using LAB04_DelCarpioDeivid.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LAB04_DelCarpioDeivid.Controllers;

[ApiController]
[Route("delcarpio/[controller]")]
public class DetallesOrdenController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DetallesOrdenController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var detalles = _unitOfWork.DetallesOrdenes.GetAll();
        return Ok(detalles);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var detalle = _unitOfWork.DetallesOrdenes.GetById(id);
        if (detalle == null) return NotFound();
        return Ok(detalle);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Detallesorden detalle)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _unitOfWork.DetallesOrdenes.Add(detalle);
        _unitOfWork.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = detalle.DetalleId }, detalle);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Detallesorden detalle)
    {
        if (id != detalle.DetalleId) return BadRequest("ID mismatch");
        if (_unitOfWork.DetallesOrdenes.GetById(id) == null) return NotFound();
        _unitOfWork.DetallesOrdenes.Update(detalle);
        _unitOfWork.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var detalle = _unitOfWork.DetallesOrdenes.GetById(id);
        if (detalle == null) return NotFound();
        _unitOfWork.DetallesOrdenes.Delete(id);
        _unitOfWork.SaveChanges();
        return NoContent();
    }
}