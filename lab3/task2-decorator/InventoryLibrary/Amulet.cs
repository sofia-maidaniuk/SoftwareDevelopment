using HeroesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLibrary
{
    public class Amulet : HeroDecorator
    {
        public Amulet(IHero hero) : base(hero) { }

        public override string GetDescription() => _baseHero.GetDescription() + ", wearing a Amulet";
        public override int GetMagicPower() => _baseHero.GetMagicPower() + 10;
    }
}
