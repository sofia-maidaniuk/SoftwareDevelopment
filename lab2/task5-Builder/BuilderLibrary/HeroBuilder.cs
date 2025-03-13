using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary
{
    public class HeroBuilder : ICharacterBuilder
    {
        private Character hero = new Character("", 0, "", "", "", "", "", new List<string>());

        public ICharacterBuilder SetName(string name)
        {
            hero.Name = name;
            return this;
        }

        public ICharacterBuilder SetHeight(int height)
        {
            hero.Height = height;
            return this;
        }

        public ICharacterBuilder SetBodyType(string bodyType)
        {
            hero.BodyType = bodyType;
            return this;
        }

        public ICharacterBuilder SetHairColor(string hairColor)
        {
            hero.HairColor = hairColor;
            return this;
        }

        public ICharacterBuilder SetEyeColor(string eyeColor)
        {
            hero.EyeColor = eyeColor;
            return this;
        }

        public ICharacterBuilder SetOutfit(string outfit)
        {
            hero.Outfit = outfit;
            return this;
        }

        public ICharacterBuilder SetInventory(string inventory)
        {
            hero.Inventory = inventory;
            return this;
        }

        public ICharacterBuilder AddAction(string action)
        {
            hero.Actions.Add($"Good deed: {action}");
            return this;
        }

        public Character GetCharacter()
        {
            Character result = hero;
            hero = new Character("", 0, "", "", "", "", "", new List<string>()); // Reset for reuse
            return result;
        }
    }
}
