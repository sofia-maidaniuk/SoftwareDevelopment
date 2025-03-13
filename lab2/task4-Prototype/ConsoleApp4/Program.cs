using System;
using Prototype;

class Program
{
    static void Main()
    {
        var ancestor = new Virus(10, 8, "Origin", "AlphaVirus");

        var parent1 = new Virus(7, 5, "Delta", "BetaVirus");
        var parent2 = new Virus(6, 4, "Gamma", "BetaVirus");

        var child1 = new Virus(3, 3, "Lambda", "GammaVirus");
        var child2 = new Virus(2, 2, "Omicron", "GammaVirus");
        var child3 = new Virus(4, 2, "Sigma", "GammaVirus");

        parent1.AddChild(child1);
        parent2.AddChild(child2);
        parent2.AddChild(child3);

        ancestor.AddChild(parent1);
        ancestor.AddChild(parent2);

        Console.WriteLine("Original Virus Family");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(ancestor.GetInfo());

        // Глибоке клонування всієї ієрархії
        Virus clone = ancestor.DeepClone();

        Console.WriteLine("\nCloned Virus Family");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(clone.GetInfo());

        // Зміна параметрів клонованого вірусу
        clone.Age = 12;
        clone.Weight = 20;

        Console.WriteLine("\nOriginal Virus Family (After Clone Change)");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(ancestor.GetInfo());

        Console.WriteLine("\nAltered Cloned Virus Family");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(clone.GetInfo());
    }
}
