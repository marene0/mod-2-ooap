using System;
using System.Collections.Generic;

// Originator 
class ProductionLine
{
    public string State { get; set; }

    public ProductionLine(string state)
    {
        State = state;
    }

    public ProductionLineMemento CreateMemento()
    {
        return new ProductionLineMemento(State);
    }

    public void RestoreMemento(ProductionLineMemento memento)
    {
        State = memento.State;
    }
}

// Memento
class ProductionLineMemento
{
    public string State { get; }

    public ProductionLineMemento(string state)
    {
        State = state;
    }
}

// Caretaker
class ProductionLineCaretaker
{
    private readonly List<ProductionLineMemento> _mementos = new List<ProductionLineMemento>();

    public void AddMemento(ProductionLineMemento memento)
    {
        _mementos.Add(memento);
    }

    public ProductionLineMemento GetMemento(int index)
    {
        return _mementos[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        var productionLine = new ProductionLine("Початковий стан");
        var caretaker = new ProductionLineCaretaker();
        caretaker.AddMemento(productionLine.CreateMemento());
        productionLine.State = "Змінений стан";
        caretaker.AddMemento(productionLine.CreateMemento());
        productionLine.RestoreMemento(caretaker.GetMemento(0));
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Поточний стан лінії виробництва: " + productionLine.State);
    }
}
