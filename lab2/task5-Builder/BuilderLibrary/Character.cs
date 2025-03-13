using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary
{
    public class Character
    {
        public string Name { get;  set; }
        public int Height { get;  set; }
        public string BodyType { get;  set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Outfit { get; set; }
        public string Inventory { get; set; }
        public List<string> Actions { get; set; } = new List<string>();

        public Character(string name, int height, string bodyType, string hairColor, string eyeColor, string outfit, string inventory, List<string> actions)
        {
            Name = name;
            Height = height;
            BodyType = bodyType;
            HairColor = hairColor;
            EyeColor = eyeColor;
            Outfit = outfit;
            Inventory = inventory;
            Actions = actions;
        }

        public string GetCharacterInfo()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("Character Information")
                .AppendLine($"Name: {Name}")
                .AppendLine($"Height: {Height} cm")
                .AppendLine($"Body Type: {BodyType}")
                .AppendLine($"Hair Color: {HairColor}")
                .AppendLine($"Eye Color: {EyeColor}")
                .AppendLine($"Outfit: {Outfit}")
                .AppendLine($"Inventory: {Inventory}")
                .AppendLine($"Actions: {string.Join(", ", Actions)}");

            return info.ToString();
        }
    }
}
