using LAB04_DelCarpioDeivid.Models;
using LAB04_DelCarpioDeivid.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LAB04_DelCarpioDeivid.Controllers;

[ApiController]
[Route("delcarpio/[controller]")]
public class OrdenController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var ordenes = _unitOfWork.Ordenes.GetAll();
        return Ok(ordenes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var orden = _unitOfWork.Ordenes.GetById(id);
        if (orden == null) return NotFound();
        return Ok(orden);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Ordene orden)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _unitOfWork.Ordenes.Add(orden);
        _unitOfWork.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = orden.OrdenId }, orden);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Ordene orden)
    {
        if (id != orden.OrdenId) return BadRequest("ID mismatch");
        if (_unitOfWork.Ordenes.GetById(id) == null) return NotFound();
        _unitOfWork.Ordenes.Update(orden);
        _unitOfWork.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var orden = _unitOfWork.Ordenes.GetById(id);
        if (orden == null) return NotFound();
        _unitOfWork.Ordenes.Delete(id);
        _unitOfWork.SaveChanges();
        return NoContent();
    }
}