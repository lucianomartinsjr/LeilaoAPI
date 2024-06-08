using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ItensController : ControllerBase
{
    private readonly DataService _dataService;

    public ItensController(DataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public IActionResult Create(ItemInputModel model)
    {
        var item = new Item
        {
            Id = _dataService.Itens.Count + 1, 
            Descricao = model.Descricao,
            LanceInicial = model.LanceInicial,
            DataFim = model.DataFim,
            MaiorLance = 0, 
            HistoricoDeLances = new List<Lance>() 
        };

        _dataService.AdicionarItem(item);

        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dataService.Itens);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = _dataService.Itens.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
}



public class ItemInputModel
{
    public string Descricao { get; set; }
    public decimal LanceInicial { get; set; }
    public DateTime DataFim { get; set; }
}
