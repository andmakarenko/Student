using System;

class Aspirant : Student
{
    public string DessertationTopic
    { 
        get; set; 
    }

    public Aspirant():
        this("defAspName", "defAspName", "defAspTopic")
    { }

    public Aspirant(string name, string lastName, string dessertationTopic):
        this(name, lastName, dessertationTopic, new Address(), DateTime.Now)
    { }

    public Aspirant(string name, string lastName, string dessertationTopic, Address address, DateTime birthDate):
        base(name, lastName, address, birthDate)
    {
        DessertationTopic = dessertationTopic;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nDessertation topic: {DessertationTopic}\n";
    }
}


