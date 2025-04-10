using HeroesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLibrary
{
    public class Shield : HeroDecorator
    {
        public Shield(IHero hero) : base(hero) { }

        public override string GetDescription() => _baseHero.GetDescription() + ", carrying a Shield";
        public override int GetDefensePower() => _baseHero.GetDefensePower() + 10;
    }
}
