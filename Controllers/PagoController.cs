using LAB04_DelCarpioDeivid.Models;
using LAB04_DelCarpioDeivid.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LAB04_DelCarpioDeivid.Controllers;

[ApiController]
[Route("delcarpio/[controller]")]
public class PagoController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PagoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pagos = _unitOfWork.Pagos.GetAll();
        return Ok(pagos);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var pago = _unitOfWork.Pagos.GetById(id);
        if (pago == null) return NotFound();
        return Ok(pago);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Pago pago)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _unitOfWork.Pagos.Add(pago);
        _unitOfWork.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = pago.PagoId }, pago);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Pago pago)
    {
        if (id != pago.PagoId) return BadRequest("ID mismatch");
        if (_unitOfWork.Pagos.GetById(id) == null) return NotFound();
        _unitOfWork.Pagos.Update(pago);
        _unitOfWork.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pago = _unitOfWork.Pagos.GetById(id);
        if (pago == null) return NotFound();
        _unitOfWork.Pagos.Delete(id);
        _unitOfWork.SaveChanges();
        return NoContent();
    }
}