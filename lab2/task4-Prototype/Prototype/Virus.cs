using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class Virus : IPrototype<Virus>
    {
        public int Weight { get; set; }
        public int Age { get; set; }
        public string Name { get; }
        public string Species { get; }
        public Virus Parent { get; private set; } 

        private HashSet<Virus> children;  // Унікальні діти

        public Virus(int weight, int age, string name, string species)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Species = species;
            children = new HashSet<Virus>();
        }

        public void AddChild(Virus child)
        {
            if (child != null)
            {
                child.Parent = this; // Призначення батьківського вірусу
                children.Add(child);
            }
        }

        public Virus DeepClone()
        {
            Virus clone = new Virus(Weight, Age, Name, Species);

            foreach (Virus child in children)
            {
                clone.AddChild(child.DeepClone());
            }

            return clone;
        }

        public string GetInfo(int level = 0)
        {
            StringBuilder info = new StringBuilder();
            string indent = new string(' ', level * 4); 
            info.AppendLine($"{indent} Virus Info:")
                .AppendLine($"{indent} Name: {Name}")
                .AppendLine($"{indent} Species: {Species}")
                .AppendLine($"{indent} Weight: {Weight}")
                .AppendLine($"{indent} Age: {Age}");

            if (Parent != null)
                info.AppendLine($"{indent} Parent: {Parent.Name}");

            info.AppendLine($"{indent} Children ({children.Count}):");

            foreach (Virus child in children)
            {
                info.Append(child.GetInfo(level + 1));
            }

            return info.ToString();
        }
    }
}
