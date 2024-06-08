using System;
using System.Collections.Generic;
using System.Linq;

public class DataService
{
    public List<Comprador> Compradores { get; private set; }
    public List<Item> Itens { get; private set; }
    public List<Lance> Lances { get; private set; }

    public DataService()
    {
        Compradores = new List<Comprador>();
        Itens = new List<Item>();
        Lances = new List<Lance>();
    }

    public void AdicionarComprador(Comprador comprador)
    {
        Compradores.Add(comprador);
    }

    public void AdicionarItem(Item item)
    {
        Itens.Add(item);
    }

    public void AdicionarLance(Lance lance)
    {
        Lances.Add(lance);
    }

    public Item ObterItemPorId(int itemId)
    {
        return Itens.FirstOrDefault(i => i.Id == itemId);
    }
}
