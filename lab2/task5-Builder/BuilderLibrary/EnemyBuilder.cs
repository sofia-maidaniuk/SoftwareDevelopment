using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary
{
    public class EnemyBuilder : ICharacterBuilder
    {
        private Character villain = new Character("", 0, "", "", "", "", "", new List<string>());

        public ICharacterBuilder SetName(string name)
        {
            villain.Name = name;
            return this;
        }

        public ICharacterBuilder SetHeight(int height)
        {
            villain.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            villain.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            villain.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            villain.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetOutfit(string outfit)
        {
            villain.Outfit = outfit;
            return this;
        }

        public ICharacterBuilder SetInventory(string inventory)
        {
            villain.Inventory = inventory;
            return this;
        }

        public ICharacterBuilder AddAction(string action)
        {
            villain.Actions.Add($"Evil deed: {action}");
            return this;
        }

        public Character GetCharacter()
        {
            Character result = villain;
            villain = new Character("", 0, "", "", "", "", "", new List<string>()); 
            return result;
        }
    }
}
