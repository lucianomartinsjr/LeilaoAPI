using System;
using System.Collections.Generic;

public class Item
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal LanceInicial { get; set; }
    public DateTime DataFim { get; set; }
    public decimal MaiorLance { get; set; }
    public List<Lance> HistoricoDeLances { get; set; } = new List<Lance>();
}
