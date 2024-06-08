using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class LancesController : ControllerBase
{
    private readonly DataService _dataService;

    public LancesController(DataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public IActionResult Create(int itemId, decimal valor, int? compradorId)
    {
        var item = _dataService.ObterItemPorId(itemId);

        if (item == null)
        {
            return NotFound("Item não encontrado");
        }

        Comprador comprador = null;
        if (compradorId.HasValue)
        {
            comprador = _dataService.Compradores.FirstOrDefault(c => c.Id == compradorId.Value);
            if (comprador == null)
            {
                return NotFound("Comprador não encontrado");
            }
        }

        if (item.HistoricoDeLances.Any())
        {
            var ultimoLance = item.HistoricoDeLances.OrderByDescending(l => l.Data).First();
            if (valor <= ultimoLance.Valor)
            {
                return BadRequest("O novo lance deve ser maior que o lance anterior");
            }
        }
        
        var lance = new Lance
        {
            Id = _dataService.Lances.Count + 1,
            Valor = valor,
            CompradorID = compradorId ?? 0, 
            ItemID = itemId,
            Data = DateTime.Now

        };

        item.HistoricoDeLances.Add(lance);
        item.MaiorLance = Math.Max(item.MaiorLance, valor);

        _dataService.AdicionarLance(lance);
        
        return Ok("Lance registrado com sucesso");
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dataService.Lances);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var lance = _dataService.Lances.FirstOrDefault(l => l.Id == id);
        if (lance == null)
        {
            return NotFound();
        }
        return Ok(lance);
    }
}


