using HeroesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLibrary
{
    public class Sword : HeroDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override string GetDescription() => _baseHero.GetDescription() + ", with a Sword";
        public override int GetAttackPower() => _baseHero.GetAttackPower() + 10;
    }
}
