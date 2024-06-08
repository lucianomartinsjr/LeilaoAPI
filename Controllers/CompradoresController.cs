using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

[Route("api/[controller]")]
[ApiController]
public class CompradoresController : ControllerBase
{
    private readonly DataService _dataService;

    public CompradoresController(DataService dataService)
    {
        _dataService = dataService;
    }


    [HttpPost]
    public IActionResult Create(CompradorInputModel model)
    {
        var comprador = new Comprador
        {
            Id = _dataService.Compradores.Count + 1,
            Nome = model.Nome,
            Email = model.Email
        };
        _dataService.AdicionarComprador(comprador);
        return CreatedAtAction(nameof(GetById), new { id = comprador.Id }, comprador);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dataService.Compradores);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var comprador = _dataService.Compradores.FirstOrDefault(c => c.Id == id);
        if (comprador == null)
        {
            return NotFound();
        }
        return Ok(comprador);
    }
}



public class CompradorInputModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
}
