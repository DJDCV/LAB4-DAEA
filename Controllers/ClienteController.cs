using LAB04_DelCarpioDeivid.Models;
using LAB04_DelCarpioDeivid.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LAB04_DelCarpioDeivid.Controllers;

[ApiController]
[Route("delcarpio/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ClienteController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var clientes = _unitOfWork.Clientes.GetAll();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = _unitOfWork.Clientes.GetById(id);
        if (cliente == null) return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _unitOfWork.Clientes.Add(cliente);
        _unitOfWork.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Cliente cliente)
    {
        if (id != cliente.ClienteId) return BadRequest("ID mismatch");
        if (_unitOfWork.Clientes.GetById(id) == null) return NotFound();
        _unitOfWork.Clientes.Update(cliente);
        _unitOfWork.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var cliente = _unitOfWork.Clientes.GetById(id);
        if (cliente == null) return NotFound();
        _unitOfWork.Clientes.Delete(id);
        _unitOfWork.SaveChanges();
        return NoContent();
    }
}